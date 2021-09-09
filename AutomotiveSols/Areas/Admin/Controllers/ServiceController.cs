using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using AutomotiveSols.BLL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.IO;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Hosting;
using AutomotiveSols.BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public ServiceVM ServiceVM { get; set; }

        public ServiceController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment
            , UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostEnvironment = hostingEnvironment;
            _userManager = userManager;

         }
        public async Task<IActionResult> Index()
        {
            var services = _db.Services.Include(s => s.ServiceType);
            return View(await services.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ServiceVM();
            ViewBag.ServiceTypes = new SelectList(_db.ServiceTypes.ToList(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceVM serviceVM)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceVM);
            }
            var applicationUser = await _userManager.GetUserAsync(User);
            serviceVM.Services.ApplicationUserId = applicationUser.Id;
            serviceVM.Services.Status = false;
            _db.Services.Add(serviceVM.Services);
            await _db.SaveChangesAsync();

            //Image being saved

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var serviceFromDb = _db.Services.Find(serviceVM.Services.Id);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, serviceVM.Services.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                serviceFromDb.ImageUrl = @"\" + StaticDetails.ImageFolder + @"\" + serviceVM.Services.Id + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder + @"\" + StaticDetails.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.ImageFolder + @"\" + serviceVM.Services.Id + ".png");
                serviceFromDb.ImageUrl = @"\" + StaticDetails.ImageFolder + @"\" + serviceVM.Services.Id + ".png";
            }
            await _db.SaveChangesAsync();


            ViewBag.ServiceTypes = new SelectList(_db.ServiceTypes.ToList(), "Id", "Name");

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new ServiceVM();
            ViewBag.ServiceTypes = new SelectList(_db.ServiceTypes.ToList(), "Id", "Name");


            model.Services = await _db.Services.Include(x => x.ServiceType).SingleOrDefaultAsync(m => m.Id == id);
            
            if (model.Services == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var serviceFromDb = _db.Services.Where(m => m.Id == ServiceVM.Services.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                    var new_extension = Path.GetExtension(files[0].FileName);
                    var old_extension = Path.GetExtension(serviceFromDb.ImageUrl);

                    if (System.IO.File.Exists(Path.Combine(uploads, ServiceVM.Services.Id + old_extension)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ServiceVM.Services.Id + old_extension));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ServiceVM.Services.Id + new_extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    ServiceVM.Services.ImageUrl = @"\" + StaticDetails.ImageFolder + @"\" + ServiceVM.Services.Id + new_extension;
                }

                if (ServiceVM.Services.ImageUrl != null)
                {
                    serviceFromDb.ImageUrl = ServiceVM.Services.ImageUrl;
                }

                serviceFromDb.Name = ServiceVM.Services.Name;
                serviceFromDb.Price = ServiceVM.Services.Price;
                serviceFromDb.ServiceTypeId = ServiceVM.Services.ServiceTypeId;
                serviceFromDb.Description = ServiceVM.Services.Description;
                serviceFromDb.SellerComments = ServiceVM.Services.SellerComments;

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(ServiceVM);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new ServiceVM();
            ViewBag.ServiceTypes = new SelectList(_db.ServiceTypes.ToList(), "Id", "Name");


            model.Services = await _db.Services.Include(x => x.ServiceType).SingleOrDefaultAsync(m => m.Id == id);

            if (model.Services == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new ServiceVM();
            ViewBag.ServiceTypes = new SelectList(_db.ServiceTypes.ToList(), "Id", "Name");


            model.Services = await _db.Services.Include(x => x.ServiceType).SingleOrDefaultAsync(m => m.Id == id);

            if (model.Services == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            Services services = await _db.Services.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                var extension = Path.GetExtension(services.ImageUrl);

                if (System.IO.File.Exists(Path.Combine(uploads, services.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, services.Id + extension));
                }
                _db.Services.Remove(services);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
