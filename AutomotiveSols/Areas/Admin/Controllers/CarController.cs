using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.Data;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment,
             UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_db.Cars.Include(x=>x.Brand)
                .Include(x=>x.Transmission)
                .Include(x=>x.Trim)
                .Include(x=>x.RegistrationCity)
                .Include(x=>x.Year)
                .Include(x=>x.Model)
                .Include(x=>x.CarGalleries)
                .Include(x=>x.GetCarFeatures).Include(x=>x.ApplicationUser).ToList());
        }

        [HttpGet]
        public IActionResult AddNewCar(bool isSuccess = false, int carId = 0)
        {
            ViewBag.BrandList = new SelectList(_db.Brands.ToList(), "Id", "Name");
            ViewBag.ModelList = new SelectList(_db.Models.ToList(), "Id", "Name");
            ViewBag.MileageList = new SelectList(_db.Mileages.ToList(), "Id", "NumberKm");
            ViewBag.RegistrationCityList = new SelectList(_db.RegistrationCities.ToList(), "Id", "Name");
            ViewBag.TransmissionList = new SelectList(_db.Transmissions.ToList(), "Id", "Name");
            ViewBag.TrimList = new SelectList(_db.Trims.ToList(), "Id", "Name");
            ViewBag.YearList = new SelectList(_db.Years.ToList(), "Id", "SolarYear");

            var features = _db.Features.ToList();
            CarViewModel carViewModel = new CarViewModel()
            {
                FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
                {
                    FeatureId = s.Id,
                    FeatureName = s.Name,
                    Assigned = false
                }).ToList()
            };

            var model = carViewModel;
            ViewBag.IsSuccess = isSuccess;
            ViewBag.CarId = carId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCar(CarViewModel carModel)
        {
            ViewBag.BrandList = new SelectList(_db.Brands.ToList(), "Id", "Name");
            ViewBag.ModelList = new SelectList(_db.Models.ToList(), "Id", "Name");
            ViewBag.MileageList = new SelectList(_db.Mileages.ToList(), "Id", "NumberKm");
            ViewBag.RegistrationCityList = new SelectList(_db.RegistrationCities.ToList(), "Id", "Name");
            ViewBag.TransmissionList = new SelectList(_db.Transmissions.ToList(), "Id", "Name");
            ViewBag.TrimList = new SelectList(_db.Trims.ToList(), "Id", "Name");
            ViewBag.YearList = new SelectList(_db.Years.ToList(), "Id", "SolarYear");
            var applicationUser = await _userManager.GetUserAsync(User);

            //carModel.autoPart.Status = false;
            if (ModelState.IsValid)
            {
                //if (partModel.CoverPhoto != null)
                //{
                //    string folder = "parts/cover/";

                //    //partModel.CoverImageUrl = await UploadImage(partModel, partModel.CoverPhoto);
                //}

                if (carModel.GalleryFiles != null)
                {
                    string folder = "cars/gallery/";

                    carModel.Gallery = new List<GalleryModel>();

                    foreach (var file in carModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImageGallery(folder, file)
                        };
                        carModel.Gallery.Add(gallery);
                    }
                }

                carModel.Car.ApplicationUserId = applicationUser.Id;
                carModel.Car.CarGalleries = new List<CarGallery>();

                foreach (var file in carModel.Gallery)
                {
                    carModel.Car.CarGalleries.Add(new CarGallery()
                    {
                        Name = file.Name,
                        URL = file.URL
                    });
                }

                await _db.Cars.AddAsync(carModel.Car);
                await _db.SaveChangesAsync();
                var carId = carModel.Car.Id;
                var carFeatures = new List<CarFeature>();
                if (carModel.FeatureAssignedToCar != null)
                {
                    foreach (var data in carModel.FeatureAssignedToCar)
                    {
                        if (data.Assigned)
                        {
                            //courseAssignment.Add(new CourseAssignment(){CourseId = data.CourseId,InstructorId = instructorId});
                            _db.CarFeatures.Add(new CarFeature()
                            { FeatureId = data.FeatureId, Id = carId });
                        }
                    }
                }
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var carFromDb = _db.Cars.Find(carModel.Car.Id);

                if (files.Count != 0)
                {
                    //Image has been uploaded
                    var uploads = Path.Combine(webRootPath, StaticDetails.carimage);
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, carModel.Car.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    carFromDb.MainImage = @"\" + StaticDetails.carimage + @"\" + carModel.Car.Id + extension;
                }
                else
                {
                    //when user does not upload image
                    var uploads = Path.Combine(webRootPath, StaticDetails.carimage + @"\" + StaticDetails.DefaultProductImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.carimage + @"\" + carModel.Car.Id + ".png");
                    carFromDb.MainImage = @"\" + StaticDetails.carimage + @"\" + carModel.Car.Id + ".png";
                }

                await _db.SaveChangesAsync();

                int id = carModel.Car.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewCar), new { isSuccess = true, bookId = id });
                }
            }

            return View(carModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var data = _db.Cars.Include(x => x.Brand)
                .Include(x => x.Transmission)
                .Include(x => x.Trim)
                .Include(x => x.RegistrationCity)
                .Include(x => x.Year)
                .Include(x => x.Model)
                .Include(x => x.CarGalleries)
                .Include(x => x.GetCarFeatures).FirstOrDefault(x=>x.Id==id);

            //Car car = new Car()
            //{
            //    Id = data.Id,
            //    Price = data.Price,
            //    MainImage = data.MainImage,
            //    BranId = data.BranId,
            //    ModelId= data.ModelId,
            //    MileageId = data.MileageId,
            //    RegistrationCityId = data.RegistrationCityId,
            //    TransmissionId = data.TransmissionId,
            //    TrimId = data.TrimId,
            //    YearId= data.YearId
            //};
            IEnumerable<Brand> brands = _db.Brands.ToList();
            IEnumerable<Model> models = _db.Models.ToList();
            IEnumerable<Mileage> mileage = _db.Mileages.ToList();
            IEnumerable<RegistrationCity> registrationCities = _db.RegistrationCities.ToList();
            IEnumerable<Transmission> transmissions = _db.Transmissions.ToList();
            IEnumerable<Trim> trim = _db.Trims.ToList();
            IEnumerable<Year> year = _db.Years.ToList();

            var features = _db.Features.ToList();
            var featureSelected = _db.CarFeatures.Include(x => x.Features).Where(x => x.Id == data.Id).ToList();
            var model = new CarViewModel()
            {
                Car = data,
                BrandList = brands.Select(i=>new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
                ModelList = models.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
                MileageList = mileage.Select(i => new SelectListItem
                {
                    Text = i.NumberKm,
                    Value = i.Id.ToString()

                }),
                RegistrationCityList=registrationCities.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
                TransmissionList = transmissions.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
                TrimList = trim.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),
                YearList = year.Select(i => new SelectListItem
                {
                    Text = i.SolarYear,
                    Value = i.Id.ToString()

                }),
                FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
                {
                    FeatureId = s.Id,
                    FeatureName =s.Name,
                    Assigned =featureSelected.Exists(f=>f.Features.Id==s.Id)
                }).OrderBy(x=>x.FeatureName).ToList()
            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarViewModel carViewModel)
        {


            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                var applicationUser = await _userManager.GetUserAsync(User);

                var serviceFromDb = _db.Cars.Where(m => m.Id == carViewModel.Car.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, StaticDetails.carimage);
                    var new_extension = Path.GetExtension(files[0].FileName);
                    var old_extension = Path.GetExtension(serviceFromDb.MainImage);

                    if (System.IO.File.Exists(Path.Combine(uploads, carViewModel.Car.Id + old_extension)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, carViewModel.Car.Id + old_extension));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, carViewModel.Car.Id + new_extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    carViewModel.Car.MainImage = @"\" + StaticDetails.carimage + @"\" + carViewModel.Car.Id + new_extension;
                }

                if (carViewModel.Car.MainImage != null)
                {
                    serviceFromDb.MainImage = carViewModel.Car.MainImage;
                }
                serviceFromDb.Price = carViewModel.Car.Price;
                serviceFromDb.MainImage = carViewModel.Car.MainImage;
                serviceFromDb.UpdatedOn = DateTime.UtcNow;
                serviceFromDb.BranId = carViewModel.Car.BranId;
                serviceFromDb.ModelId = carViewModel.Car.ModelId;

                serviceFromDb.MileageId = carViewModel.Car.MileageId;

                serviceFromDb.TrimId = carViewModel.Car.TrimId;

                serviceFromDb.TransmissionId = carViewModel.Car.TransmissionId;

                serviceFromDb.RegistrationCityId = carViewModel.Car.RegistrationCityId;

                serviceFromDb.YearId = carViewModel.Car.YearId;
                serviceFromDb.ApplicationUserId = applicationUser.Id;


                await _db.SaveChangesAsync();

                var carId = carViewModel.Car.Id;
                if (carViewModel.FeatureAssignedToCar != null)
                {
                    foreach (var data in carViewModel.FeatureAssignedToCar)
                    {
                        if (data.Assigned)
                        {
                            var isExist = IsExist(_db.CarFeatures.ToList(), carId, data.FeatureId);
                            if (!isExist)
                            {
                                _db.CarFeatures.Add(new CarFeature()
                                { FeatureId = data.FeatureId, Id = carId });

                            }
                            _db.SaveChanges();
                        }
                        else
                        {

                            var isExist = IsExist(_db.CarFeatures.ToList(), carId, data.FeatureId);

                            if (isExist)
                            {
                                var filter = GetByFiler(x => x.FeatureId == data.FeatureId && x.Id == carId)
                                    .FirstOrDefault();
                                _db.CarFeatures.Remove(filter);
                               
                            }
                            _db.SaveChanges();

                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    carViewModel.BrandList = _db.Brands.ToList().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()

                    });
                    carViewModel.ModelList = _db.Models.ToList().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()

                    });
                    carViewModel.MileageList = _db.Mileages.ToList().Select(i => new SelectListItem
                    {
                        Text = i.NumberKm,
                        Value = i.Id.ToString()

                    });
                    carViewModel.RegistrationCityList = _db.RegistrationCities.ToList().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()

                    });
                    carViewModel.TransmissionList = _db.Transmissions.ToList().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()

                    });
                    carViewModel.TrimList = _db.Trims.ToList().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()

                    });
                    carViewModel.YearList = _db.Years.ToList().Select(i => new SelectListItem
                    {
                        Text = i.SolarYear,
                        Value = i.Id.ToString()

                    });
                    if (carViewModel.Car.Id != 0)
                    {
                        carViewModel.Car = _db.Cars.FirstOrDefault(x => x.Id == carViewModel.Car.Id);
                    }
                }

            }
            return View(carViewModel);

        }


        private bool IsExist(IEnumerable<CarFeature> source, int carId, int featureId)
        {
            return source.Where(x => x.Id == carId).Any(c => c.FeatureId == featureId);
        }
        public IEnumerable<CarFeature> GetByFiler(Func<CarFeature, bool> predicate)
        {
            return _db.Set<CarFeature>().Where(predicate).ToList();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new Car();
            

            model = await _db.Cars.Include(x => x.CarGalleries)
                                        .Include(x=>x.ApplicationUser)
                                        .Include(x=>x.Brand)
                                        .Include(x=>x.Model)
                                        .Include(x=>x.Mileage)
                                        .Include(x=>x.RegistrationCity)
                                        .Include(x=>x.Transmission)
                                        .Include(x=>x.Trim).SingleOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            Car car = await _db.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, StaticDetails.carimage);
                var extension = Path.GetExtension(car.MainImage);

                if (System.IO.File.Exists(Path.Combine(uploads, car.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, car.Id + extension));
                }
                _db.Cars.Remove(car);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
        private async Task<string> UploadImageGallery(string folderPath, IFormFile file)
        {

            //  folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            folderPath += file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }


    }
}
