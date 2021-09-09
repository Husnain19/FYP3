using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    public class AutoPartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public AutoPartController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment,
             UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_db.AutoParts.Include(x=>x.Category)
                .Include(x=>x.SubCategory)
                .Include(x=>x.ApplicationUser)
                .Include(x=>x.PartGalleries).ToList());
        }

        

        public IActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");

            var data =  _db.AutoParts.Include(x => x.Category).Include(x => x.SubCategory).Include(x => x.PartGalleries)
                .Where(x => x.Id == id).FirstOrDefault();

            AutoPart autoPart = new AutoPart()
            {
                Id =data.Id,
                Name =data.Name,
                ListPrice = data.ListPrice,
                Price =data.Price,
                Price50 =data.Price50,
                Price100 =data.Price100,
                CategoryId = data.CategoryId,
                SubCategoryId = data.SubCategoryId,
                MainImageUrl = data.MainImageUrl,
                Description =data.Description,
                SellerComments =data.SellerComments,
                CreatedOn = data.CreatedOn,
                UpdatedOn = data.UpdatedOn,
                ApplicationUserId = data.ApplicationUserId
            };
            return View(autoPart);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutoPart autoPart)
        {

            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                var applicationUser = await _userManager.GetUserAsync(User);

                var serviceFromDb = _db.AutoParts.Where(m => m.Id == autoPart.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, StaticDetails.partsimage);
                    var new_extension = Path.GetExtension(files[0].FileName);
                    var old_extension = Path.GetExtension(serviceFromDb.MainImageUrl);

                    if (System.IO.File.Exists(Path.Combine(uploads, autoPart.Id + old_extension)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, autoPart.Id + old_extension));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, autoPart.Id + new_extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    autoPart.MainImageUrl = @"\" + StaticDetails.ImageFolder + @"\" + autoPart.Id + new_extension;
                }

                if (autoPart.MainImageUrl != null)
                {
                    serviceFromDb.MainImageUrl = autoPart.MainImageUrl;
                }
                serviceFromDb.Name = autoPart.Name;
                serviceFromDb.ListPrice = autoPart.ListPrice;
                serviceFromDb.Price = autoPart.Price;
                serviceFromDb.Price50 = autoPart.Price50;
                serviceFromDb.Price100 = autoPart.Price100;
                serviceFromDb.Description = autoPart.Description;
                serviceFromDb.SellerComments = autoPart.SellerComments;
                serviceFromDb.MainImageUrl = autoPart.MainImageUrl;
                serviceFromDb.UpdatedOn = DateTime.UtcNow;
                serviceFromDb.CategoryId = autoPart.CategoryId;
                serviceFromDb.SubCategoryId = autoPart.SubCategoryId;
                serviceFromDb.ApplicationUserId = applicationUser.Id;


                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(autoPart);
        }



        //[HttpPost]
        //public async Task<IActionResult> Edit( AutoPart partModel)
        //{
        //    //ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
        //    //ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");
        //    //var applicationUser = await _userManager.GetUserAsync(User);


        //    //if (id != partModel.Id)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    _db.Update(partModel);
        //    //    await _db.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(GetPart), new { id = id });
        //    //}
        //    //return View(partModel);

        //    if (ModelState.IsValid)
        //    {
        //        string webRootPath = _webHostEnvironment.WebRootPath;
        //        var files = HttpContext.Request.Form.Files;
        //        if (files.Count > 0)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            var uploads = Path.Combine(webRootPath, @"parts\cover");
        //            var extenstion = Path.GetExtension(files[0].FileName);

        //            if (partModel.MainImageUrl != null)
        //            {
        //                //this is an edit and we need to remove old image
        //                var imagePath = Path.Combine(webRootPath, partModel.MainImageUrl.TrimStart('\\'));
        //                if (System.IO.File.Exists(imagePath))
        //                {
        //                    System.IO.File.Delete(imagePath);
        //                }
        //            }

        //            using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
        //            {
        //                files[0].CopyTo(filesStreams);
        //            }
        //            partModel.MainImageUrl = @"\parts\cover\" + fileName + extenstion;
        //        }
        //        else
        //        {
        //            //update when they do not change the image
        //            if (partModel.Id != 0)
        //            {
        //                AutoPart objFromDb = _db.AutoParts.Where(x => x.Id == partModel.Id).FirstOrDefault();
        //                partModel.MainImageUrl = objFromDb.MainImageUrl;
        //            }
        //        }


        //        if (partModel.Id == 0)
        //        {
        //            _db.AutoParts.Add(partModel);

        //        }
        //        else
        //        {
        //            _db.AutoParts.Update(partModel);
        //        }
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
        //        ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");
        //        if (partModel.Id != 0)
        //        {
        //            partModel = _db.AutoParts.Where(x => x.Id == partModel.Id).FirstOrDefault();
        //        }
        //    }
        //    return View(partModel);

        //}

        public IActionResult AddNewPart(bool isSuccess = false, int partId = 0)
        {
            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");


            AutoPartViewModel autoPartViewModel = new AutoPartViewModel();

            var model = autoPartViewModel;
            ViewBag.IsSuccess = isSuccess;
            ViewBag.PartId = partId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewPart(AutoPartViewModel partModel)
        {
            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");
            var applicationUser = await _userManager.GetUserAsync(User);

            partModel.autoPart.Status = false;
            if (ModelState.IsValid)
            {
                //if (partModel.CoverPhoto != null)
                //{
                //    string folder = "parts/cover/";

                //    //partModel.CoverImageUrl = await UploadImage(partModel, partModel.CoverPhoto);
                //}
               
                if (partModel.GalleryFiles != null)
                {
                    string folder = "parts/gallery/";

                    partModel.Gallery = new List<GalleryModel>();

                    foreach (var file in partModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImageGallery(folder, file)
                        };
                        partModel.Gallery.Add(gallery);
                    }
                }

                //    var newPart = new AutoPart()
                //    {

                //        Name = partModel.autoPart.Name,
                //        ListPrice = partModel.autoPart.ListPrice,
                //        Price = partModel.autoPart.Price,
                //        Price50 = partModel.autoPart.Price50,
                //        Price100 = partModel.autoPart.Price100,
                //        Description = partModel.autoPart.Description,
                //        SellerComments = partModel.autoPart.SellerComments,
                //       // MainImageUrl = partModel.CoverImageUrl,
                //        CreatedOn = DateTime.UtcNow,
                //        CategoryId = partModel.autoPart.CategoryId,
                //        SubCategoryId = partModel.autoPart.SubCategoryId,
                //        ApplicationUserId = applicationUser.Id

                //};
                partModel.autoPart.CreatedOn = DateTime.Now;
                partModel.autoPart.ApplicationUserId = applicationUser.Id;
                partModel.autoPart.PartGalleries = new List<PartGallery>();

                foreach (var file in partModel.Gallery)
                {
                    partModel.autoPart.PartGalleries.Add(new PartGallery()
                    {
                        Name = file.Name,
                        URL = file.URL
                    });
                }

                await _db.AutoParts.AddAsync(partModel.autoPart);



                await _db.SaveChangesAsync();
                string webRootPath = _webHostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var serviceFromDb = _db.AutoParts.Find(partModel.autoPart.Id);

                if (files.Count != 0)
                {
                    //Image has been uploaded
                    var uploads = Path.Combine(webRootPath, StaticDetails.partsimage);
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, partModel.autoPart.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    serviceFromDb.MainImageUrl = @"\" + StaticDetails.partsimage + @"\" + partModel.autoPart.Id + extension;
                }
                else
                {
                    //when user does not upload image
                    var uploads = Path.Combine(webRootPath, StaticDetails.partsimage + @"\" + StaticDetails.DefaultProductImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.partsimage + @"\" + partModel.autoPart.Id + ".png");
                    serviceFromDb.MainImageUrl = @"\" + StaticDetails.partsimage + @"\" + partModel.autoPart.Id + ".png";
                }

                await _db.SaveChangesAsync();

                int id = partModel.autoPart.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewPart), new { isSuccess = true, bookId = id });
                }
            }

            return View(partModel);
        }

        public async Task<ViewResult> GetPart(int id)
        {
            var data = await _db.AutoParts.Include(x => x.Category).Include(x => x.SubCategory).Include(x => x.PartGalleries)
                .Where(x => x.Id == id).FirstOrDefaultAsync();


            var autopartViewModel = new AutoPartViewModel()
            {
                autoPart = data,
                CoverImageUrl = data.MainImageUrl,
                Gallery = data.PartGalleries     .Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList(),
            };

            return View(autopartViewModel);
        }

        //private async Task<string> UploadImage(string folderPath, IFormFile file)
        //{

        //    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath );

        //    await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //    return "/" + folderPath;
        //}

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            


            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        private async Task<string> UploadImageGallery(string folderPath, IFormFile file)
        {

            //  folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            folderPath +=   file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new AutoPart();
            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");
            ViewBag.SubCategoryList = new SelectList(_db.SubCategories.ToList(), "Id", "Name");


            model = await _db.AutoParts.Include(x => x.PartGalleries).SingleOrDefaultAsync(m => m.Id == id);

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
            AutoPart autoPart = await _db.AutoParts.FindAsync(id);

            if (autoPart == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, StaticDetails.partsimage);
                var extension = Path.GetExtension(autoPart.MainImageUrl);

                if (System.IO.File.Exists(Path.Combine(uploads, autoPart.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, autoPart.Id + extension));
                }
                _db.AutoParts.Remove(autoPart);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }


    }
}



