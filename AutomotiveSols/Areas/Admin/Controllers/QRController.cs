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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QRController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public QRController(IWebHostEnvironment _hostEnvironment, UserManager<ApplicationUser> _userManager,
            ApplicationDbContext _db)
        {
            this._hostEnvironment = _hostEnvironment;
            this._userManager = _userManager;
            this._db =_db;
        }
        public IActionResult Index()
        {
            var qrs = _db.QRs.ToList();

            return View(qrs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new QR();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(QR qr)
        {
            if (!ModelState.IsValid)
            {
                return View(qr);
            }
            else
            {
               
                _db.QRs.Add(qr);
                await _db.SaveChangesAsync();

                //Image being saved

                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var qrFromDb = _db.QRs.Find(qr.Id);

                if (files.Count != 0)
                {
                    //Image has been uploaded
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolderQR);
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, qr.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    qrFromDb.QRCode = @"\" + StaticDetails.ImageFolderQR + @"\" + qr.Id + extension;
                }
                else
                {
                    //when user does not upload image
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolderQR + @"\" + StaticDetails.DefaultProductImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.ImageFolderQR + @"\" + qr.Id + ".png");
                    qrFromDb.QRCode = @"\" + StaticDetails.ImageFolderQR + @"\" + qr.Id + ".png";
                }
                await _db.SaveChangesAsync();


                

                return RedirectToAction(nameof(Index));

            }


            
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new QR();



         //   model = await _db.QRs.SingleOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QR qR)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var qrFromDb = _db.QRs.Where(m => m.Id == qR.Id ).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolderQR);
                    var new_extension = Path.GetExtension(files[0].FileName);
                    var old_extension = Path.GetExtension(qrFromDb.QRCode);

                    if (System.IO.File.Exists(Path.Combine(uploads, qR.Id + old_extension)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, qR.Id + old_extension));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, qR.Id + new_extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    qR.QRCode = @"\" + StaticDetails.ImageFolderQR + @"\" + qR.Id + new_extension;
                }

                if (qR.QRCode != null)
                {
                    qrFromDb.QRCode = qR.QRCode;
                }

                qrFromDb.Name = qR.Name;
                qrFromDb.price = qR.price;
                
               

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(qR);
        }
    }
}
