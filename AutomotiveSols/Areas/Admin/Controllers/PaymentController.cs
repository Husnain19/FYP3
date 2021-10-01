using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using AutomotiveSols.EmailServices;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;
        public PaymentController(IWebHostEnvironment _hostEnvironment, UserManager<ApplicationUser> _userManager,
            ApplicationDbContext _db,
            IEmailSender emailSender)
        {
            this._hostEnvironment = _hostEnvironment;
            this._userManager = _userManager;
            this._db = _db;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var qrs = _db.Payments.ToList();

            return View(qrs);
        }

        [HttpGet]
        public IActionResult Create(bool isSuccess = false)
        {
            var model = new Payment();
            ViewBag.IsSuccess = isSuccess;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                return View(payment);
            }
            else
            {
                payment.ApplicationUserId = applicationUser.Id;
                _db.Payments.Add(payment);
                await _db.SaveChangesAsync();
                //Image being saved

                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var qrFromDb = _db.Payments.Find(payment.Id);

                if (files.Count != 0)
                {
                    //Image has been uploaded
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolderPayment);
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, payment.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    qrFromDb.PaymentImage = @"\" + StaticDetails.ImageFolderPayment + @"\" + payment.Id + extension;
                    await _emailSender.SendEmailAsync(applicationUser.Email, "Status: Pending",
                      $"Your request is forward to the team, Please wait we will let you through email.");

                    await _emailSender.SendEmailAsync("husnainakbar140@gmail.com", "Confirm the transaction",
                      $"Mr/Miss '{applicationUser.Name}' has uploaded the payment slip/invoice . Please review and verify.Please confirm your account by clicking this link: <a href='https://localhost:44363/Admin/Car/Requests'>link</a>");
                }
                else
                {
                    //when user does not upload image
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolderPayment + @"\" + StaticDetails.DefaultProductImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.ImageFolderPayment + @"\" + payment.Id + ".png");
                    qrFromDb.PaymentImage = @"\" + StaticDetails.ImageFolderPayment + @"\" + payment.Id + ".png";
                }
                await _db.SaveChangesAsync();




                return RedirectToAction(nameof(Create), new
                {
                    IsSuccess = true
                });

            }



        }
    }
}