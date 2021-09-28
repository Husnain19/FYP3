using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using Microsoft.EntityFrameworkCore;
using AutomotiveSols.Extensions;
using AutomotiveSols.BLL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutomotiveSols.EmailServices;
using Microsoft.AspNetCore.Hosting;

namespace AutomotiveSols.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private IndexViewModel IndexVM;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger, ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
        }

        //[HttpGet]
        //public async Task<ActionResult> Index(string searchName)
        //{
        //    ViewBag.BrandList = new SelectList(_db.Brands.ToList(), "Id", "Name");
        //    ViewBag.ModelList = new SelectList(_db.Models.ToList(), "Id", "Name");
        //    ViewBag.MileageList = new SelectList(_db.Mileages.ToList(), "Id", "NumberKm");
        //    ViewBag.RegistrationCityList = new SelectList(_db.RegistrationCities.ToList(), "Id", "Name");
        //    ViewBag.TransmissionList = new SelectList(_db.Transmissions.ToList(), "Id", "Name");
        //    ViewBag.TrimList = new SelectList(_db.Trims.ToList(), "Id", "Name");
        //    ViewBag.YearList = new SelectList(_db.Years.ToList(), "Id", "SolarYear");

        //    var features = _db.Features.ToList();

        //    ViewData["searchName"] = searchName;
        //    if (!string.IsNullOrEmpty(searchName)) {

        //        IndexVM = new IndexViewModel()
        //        {
        //            TotalCars = _db.Cars.Count(x => x.Status == true),
        //            //TotalCars = 10,
        //            TotalServices = _db.Services.ToList().Count(x => x.Status == true),

        //            TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

        //            TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),

        //            CategoryList = await _db.Categories.ToListAsync(),
        //            AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
        //                            .Include(x => x.SubCategory)
        //                            .Include(x => x.PartGalleries)
        //                            .Where(x=>x.Name.Contains(searchName) || x.Description.Contains(searchName))
        //                            .ToListAsync(),
        //            ServiceTypes = await _db.ServiceTypes.ToListAsync(),
        //            Services = await _db.Services.Include(x => x.ApplicationUser)
        //                            .Include(x => x.ServiceType)
        //                            .Where(x=>x.Name.Contains(searchName) || x.Description.Contains(searchName))
        //                            .ToListAsync(),
        //            Brands = await _db.Brands.ToListAsync(),

        //            Cars = await _db.Cars.Include(x => x.ApplicationUser)
        //                            .Include(x => x.Brand)
        //                            .Include(x => x.Model)
        //                            .Include(x => x.Mileage)
        //                            .Include(x => x.Transmission)
        //                            .Include(x => x.Trim)
        //                            .Include(x => x.RegistrationCity)
        //                            .Include(x => x.Year)
        //                            .Where(x=>x.Brand.Name.Contains(searchName) || x.Mileage.NumberKm.Contains(searchName)
        //                            || x.RegistrationCity.Name.Contains(searchName) || x.Transmission.Name.Contains(searchName)
        //                            || x.Trim.Name.Contains(searchName ) || x.Year.SolarYear.Contains(searchName))
        //                            .ToListAsync(),

        //            FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
        //            {
        //                FeatureId = s.Id,
        //                FeatureName = s.Name,
        //                Assigned = false
        //            }).ToList()




        //        };


        //        var applicationUser = await _userManager.GetUserAsync(User);
        //        if (applicationUser != null)
        //        {
        //            var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
        //            HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
        //        }

        //        return View(IndexVM);
        //    }
        //    else
        //    {
        //        IndexVM = new IndexViewModel()
        //        {
        //            TotalCars = _db.Cars.Count(x => x.Status == true),
        //            //TotalCars = 10,
        //            TotalServices = _db.Services.ToList().Count(x => x.Status == true),

        //            TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

        //            TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),


        //            CategoryList = await _db.Categories.ToListAsync(),
        //            AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
        //                            .Include(x => x.SubCategory)
        //                            .Include(x => x.PartGalleries)
        //                            .ToListAsync(),
        //            ServiceTypes = await _db.ServiceTypes.ToListAsync(),
        //            Services = await _db.Services.Include(x => x.ApplicationUser)
        //                            .Include(x => x.ServiceType)
        //                            .ToListAsync(),
        //            Brands = await _db.Brands.ToListAsync(),

        //            Cars = await _db.Cars.Include(x => x.ApplicationUser)
        //                            .Include(x => x.Brand)
        //                            .Include(x => x.Model)
        //                            .Include(x => x.Mileage)
        //                            .Include(x => x.Transmission)
        //                            .Include(x => x.Trim)
        //                            .Include(x => x.RegistrationCity)
        //                            .Include(x => x.Year)
        //                            .ToListAsync(),

        //            FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
        //            {
        //                FeatureId = s.Id,
        //                FeatureName = s.Name,
        //                Assigned = false
        //            }).ToList()


        //        };
        //        var applicationUser = await _userManager.GetUserAsync(User);
        //        if (applicationUser != null)
        //        {
        //            var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
        //            HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
        //        }

        //        return View(IndexVM);
        //    }


        //}
        [HttpGet]
        public async Task<ActionResult> Index(string searchName = null, string searchCategory = null)
        {
            ViewBag.BrandList = new SelectList(_db.Brands.ToList(), "Id", "Name");
            ViewBag.ModelList = new SelectList(_db.Models.ToList(), "Id", "Name");
            ViewBag.MileageList = new SelectList(_db.Mileages.ToList(), "Id", "NumberKm");
            ViewBag.RegistrationCityList = new SelectList(_db.RegistrationCities.ToList(), "Id", "Name");
            ViewBag.TransmissionList = new SelectList(_db.Transmissions.ToList(), "Id", "Name");
            ViewBag.TrimList = new SelectList(_db.Trims.ToList(), "Id", "Name");
            ViewBag.YearList = new SelectList(_db.Years.ToList(), "Id", "SolarYear");

            var features = _db.Features.ToList();



            IndexVM = new IndexViewModel()
            {
                TotalCars = _db.Cars.Count(x => x.Status == true),
                //TotalCars = 10,
                TotalServices = _db.Services.ToList().Count(x => x.Status == true),

                TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

                TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),

                CategoryList = await _db.Categories.ToListAsync(),
                AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                .Include(x => x.SubCategory)
                                .Include(x => x.PartGalleries)

                                .ToListAsync(),
                ServiceTypes = await _db.ServiceTypes.ToListAsync(),
                Services = await _db.Services.Include(x => x.ApplicationUser)
                                .Include(x => x.ServiceType)

                                .ToListAsync(),
                Brands = await _db.Brands.ToListAsync(),

                Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                .Include(x => x.Brand)
                                .Include(x => x.Model)
                                .Include(x => x.Mileage)
                                .Include(x => x.Transmission)
                                .Include(x => x.Trim)
                                .Include(x => x.RegistrationCity)
                                .Include(x => x.Year)

                                .ToListAsync(),

                FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
                {
                    FeatureId = s.Id,
                    FeatureName = s.Name,
                    Assigned = false
                }).ToList()




            };


            var applicationUser = await _userManager.GetUserAsync(User);
            if (applicationUser != null)
            {
                var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == applicationUser.Id).ToList().Count();
                HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);
            }

            if (searchCategory != null)
            {
                IndexVM = new IndexViewModel()
                {
                    TotalCars = _db.Cars.Count(x => x.Status == true),
                    //TotalCars = 10,
                    TotalServices = _db.Services.ToList().Count(x => x.Status == true),

                    TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

                    TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),

                    CategoryList = await _db.Categories.Where(x => x.Name.Contains(searchCategory)).ToListAsync(),
                    AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .Where(x => x.Category.Name.Contains(searchCategory) || x.Description.Contains(searchCategory))
                                    .ToListAsync(),
                    ServiceTypes = await _db.ServiceTypes.Where(x => x.Name.Contains(searchCategory)).ToListAsync(),
                    Services = await _db.Services.Include(x => x.ApplicationUser)
                                    .Include(x => x.ServiceType)
                                    .Where(x => x.ServiceType.Name.Contains(searchCategory) || x.Description.Contains(searchName))
                                    .ToListAsync(),
                    Brands = await _db.Brands.Where(x => x.Name.Contains(searchCategory)).ToListAsync(),

                    Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(x => x.Brand.Name.Contains(searchCategory)
                                    || x.RegistrationCity.Name.Contains(searchCategory) || x.Transmission.Name.Contains(searchCategory)
                                    || x.Trim.Name.Contains(searchCategory) || x.Year.SolarYear.Contains(searchCategory))
                                    .ToListAsync(),

                    FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
                    {
                        FeatureId = s.Id,
                        FeatureName = s.Name,
                        Assigned = false
                    }).ToList()




                };

            }
            if (searchName != null)
            {
                IndexVM = new IndexViewModel()
                {
                    TotalCars = _db.Cars.Count(x => x.Status == true),
                    //TotalCars = 10,
                    TotalServices = _db.Services.ToList().Count(x => x.Status == true),

                    TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

                    TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),

                    CategoryList = await _db.Categories.ToListAsync(),
                    AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .Where(x => x.Name.Contains(searchName) || x.Description.Contains(searchName))
                                    .ToListAsync(),
                    ServiceTypes = await _db.ServiceTypes.ToListAsync(),
                    Services = await _db.Services.Include(x => x.ApplicationUser)
                                    .Include(x => x.ServiceType)
                                    .Where(x => x.Name.Contains(searchName) || x.Description.Contains(searchName))
                                    .ToListAsync(),
                    Brands = await _db.Brands.ToListAsync(),

                    Cars = await _db.Cars.Include(x => x.ApplicationUser)
                                    .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(x => x.Brand.Name.Contains(searchName) || x.Mileage.NumberKm.Contains(searchName)
                                    || x.RegistrationCity.Name.Contains(searchName) || x.Transmission.Name.Contains(searchName)
                                    || x.Trim.Name.Contains(searchName) || x.Year.SolarYear.Contains(searchName))
                                    .ToListAsync(),

                    FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
                    {
                        FeatureId = s.Id,
                        FeatureName = s.Name,
                        Assigned = false
                    }).ToList()




                };
            }

            //if (searchPrice != null && searchPrice2 !=null)
            //{
            //    IndexVM = new IndexViewModel()
            //    {
            //        //TotalCars = _db.Cars.Count(x => x.Status == true),
            //        //TotalCars = 10,
            //        //TotalServices = _db.Services.ToList().Count(x => x.Status == true),

            //       // TotalSpareParts = _db.AutoParts.Count(x => x.Status == true),

            //      //  TotalUsers = _db.ApplicationUsers.Count(x => x.LockoutEnabled == true),

            //        CategoryList = await _db.Categories.ToListAsync(),
            //        AutoPartList = await _db.AutoParts.Include(x => x.ApplicationUser).Include(x => x.Category)
            //                        .Include(x => x.SubCategory)
            //                        .Include(x => x.PartGalleries)
            //                        .Where(x => x.Price >= Convert.ToInt32(searchPrice ) || x.Price <= Convert.ToInt32(searchPrice2))
            //                        .ToListAsync(),
            //        ServiceTypes = await _db.ServiceTypes.ToListAsync(),
            //        Services = await _db.Services.Include(x => x.ApplicationUser)
            //                        .Include(x => x.ServiceType)
            //                        .Where(x => x.Price >= Convert.ToInt32(searchPrice) || x.Price <= Convert.ToInt32(searchPrice2))
            //                        .ToListAsync(),
            //        Brands = await _db.Brands.ToListAsync(),

            //        Cars = await _db.Cars.Include(x => x.ApplicationUser)
            //                        .Include(x => x.Brand)
            //                        .Include(x => x.Model)
            //                        .Include(x => x.Mileage)
            //                        .Include(x => x.Transmission)
            //                        .Include(x => x.Trim)
            //                        .Include(x => x.RegistrationCity)
            //                        .Include(x => x.Year)
            //                        .Where(x => x.Price >= Convert.ToInt32(searchPrice) || x.Price <= Convert.ToInt32(searchPrice2))
            //                        .ToListAsync(),

            //        FeatureAssignedToCar = features.Select(s => new FeatureAssignedToCar()
            //        {
            //            FeatureId = s.Id,
            //            FeatureName = s.Name,
            //            Assigned = false
            //        }).ToList()




            //    };
            //}

            return View(IndexVM);


        }

        [HttpGet]
        public async Task<IActionResult> Validate()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Validate(DecisionVM  decisionVM)
        {

            if(decisionVM.SaleOwn== true)
            {
                Random r = new Random();
                int num = r.Next();
                HttpContext.Session.SetInt32(StaticDetails.Code, num);
                await _emailSender.SendEmailAsync("husnainakbar140@gmail.com", "Confirm your activity",
                       $" This is your Validation Code {num}");


                return RedirectToAction(nameof(Verify));
            }
            else
            {

                return RedirectToAction(nameof(QRAd));
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> QRAd()
        {
           var qr =   _db.QRs.OrderByDescending(x=>x.Id)
                .Take(1)
                .ToList()
                .FirstOrDefault();

            return View(qr);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult>   Verify()
        {

            return View();
        }

        [HttpPost]
        public  IActionResult Verify(CodeVM codeVM)
        {
           int? codeSession =  HttpContext.Session.GetInt32(StaticDetails.Code);
            if (codeVM != null)
            {
                if (codeVM.Code == codeSession)
                {
                    return RedirectToAction(nameof(UserAd));//////////////
                }
                else
                {
                    return RedirectToAction(nameof(UserAd));//////////////
                }
            }
            else
            {
                return RedirectToAction(nameof(UserAd));//////
            }
        }
        [Authorize]
        public async Task<IActionResult> UserAd(bool isSuccess = false, int carId = 0)
        {
            ViewBag.BrandList = new SelectList(_db.Brands.ToList(), "Id", "Name");
            ViewBag.ModelList = new SelectList(_db.Models.ToList(), "Id", "Name");
            ViewBag.MileageList = new SelectList(_db.Mileages.ToList(), "Id", "NumberKm");
            ViewBag.RegistrationCityList = new SelectList(_db.RegistrationCities.ToList(), "Id", "Name");
            ViewBag.TransmissionList = new SelectList(_db.Transmissions.ToList(), "Id", "Name");
            ViewBag.TrimList = new SelectList(_db.Trims.ToList(), "Id", "Name");
            ViewBag.YearList = new SelectList(_db.Years.ToList(), "Id", "SolarYear");
            ViewBag.ShowroomList = new SelectList(_db.Showrooms.ToList(), "Id", "Name");

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

        

        public async Task<IActionResult> DetailsPart(int id)
        {
            var partFromDb =await _db.AutoParts.Include(x => x.ApplicationUser)
                                    .Include(x => x.Category)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.PartGalleries)
                                    .FirstOrDefaultAsync(x=>x.Id ==id);
             ShoppingCart cartObj = new ShoppingCart()
            {
                AutoPart = partFromDb,
                AutoPartId = partFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         [Authorize]
        public async Task<IActionResult> DetailsPart(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                //then we will add to cart
                var applicationUser = await _userManager.GetUserAsync(User);
                CartObject.ApplicationUserId = applicationUser.Id;

                ShoppingCart cartFromDb = await _db.ShoppingCarts.Where(u => u.ApplicationUserId == CartObject.ApplicationUserId
                && u.AutoPartId == CartObject.AutoPartId).Include(x => x.AutoPart).Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync();
                   

                if (cartFromDb == null)
                {
                    //no records exists in database for that product for that user
                    _db.ShoppingCarts.Add(CartObject);
                }
                else
                {
                    cartFromDb.Count += CartObject.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                await _db.SaveChangesAsync();


                var count = _db.ShoppingCarts.Where(x => x.ApplicationUserId == CartObject.ApplicationUserId)
                    .ToList().Count();
                    


                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(StaticDetails.ssShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var partFromDb = await _db.AutoParts.Where(x => x.Id == CartObject.AutoPartId)
                    .Include(x => x.Category)
                    .Include(x => x.SubCategory).FirstOrDefaultAsync();

                ShoppingCart cartObj = new ShoppingCart()
                {
                    AutoPart = partFromDb,
                    AutoPartId = partFromDb.Id
                };
                return View(cartObj);
            }


        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DetailsCar(int id)
        {
            var car = await _db.Cars.Include(m => m.ApplicationUser)
                .Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(m => m.Id == id).FirstOrDefaultAsync();
           return View(car);
        }

        [HttpPost, ActionName("DetailsCar")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsCarPost(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("carCart");
            if (tempCart == null)
            {
                tempCart = new List<int>();
            }
            tempCart.Add(id);
            HttpContext.Session.Set("carCart", tempCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }
        public IActionResult RemoveCar(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("carCart");
            if (tempCart.Count > 0)
            {
                if (tempCart.Contains(id))
                {
                    tempCart.Remove(id);
                }
            }

            HttpContext.Session.Set("carCart", tempCart);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _db.Services.Include(m => m.ServiceType).Where(m => m.Id == id).FirstOrDefaultAsync();


            return View(service);
        }
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("tempCart");
            if (tempCart == null)
            {
                tempCart = new List<int>();
            }
            tempCart.Add(id);
            HttpContext.Session.Set("tempCart", tempCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }

        public IActionResult Remove(int id)
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("tempCart");
            if (tempCart.Count > 0)
            {
                if (tempCart.Contains(id))
                {
                    tempCart.Remove(id);
                }
            }

            HttpContext.Session.Set("tempCart", tempCart);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
