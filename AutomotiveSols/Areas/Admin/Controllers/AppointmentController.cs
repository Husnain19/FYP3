using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutomotiveSols.Static;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Reporting;

namespace AutomotiveSols.Areas.Admin.Controllers
{
   // [Authorize(Roles = "Admin,Workshop")]
    [Area("Admin")]

    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AppointmentController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext db,UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            var saleperson = await _userManager.GetUserAsync(User);
            AppointmentVM appointmentVM = new AppointmentVM()
            {
                Appointments = new List<Appointments>()
            };
            appointmentVM.Appointments = _db.Appointments.Include(x => x.SalesPerson).ToList();
          
            if (User.IsInRole("Workshop") )
            {
                appointmentVM.Appointments = _db.Appointments.Include(x => x.SalesPerson).Where(x => x.SalesPersonId == saleperson.Id
                && x.isService == true  ).ToList();
            }
            else if(User.IsInRole(StaticDetails.Role_Super_Workshop)){

                appointmentVM.Appointments = _db.Appointments.Include(x => x.SalesPerson ).
                    Where(x=>x.isService == true).ToList();
            }
            else if(User.IsInRole(StaticDetails.Role_Admin))
            {
                appointmentVM.Appointments = _db.Appointments.Include(x => x.SalesPerson).ToList();
            }
            else {
                appointmentVM.Appointments = new List<Appointments>();
            }
            if (searchName != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerPhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.AppointmentDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }

            }


            return View(appointmentVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users = _db.ApplicationUsers.ToList();
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            for (int i = 0; i < users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(users[i].Id);
                if ((await _userManager.IsInRoleAsync(user, StaticDetails.Role_Workshop)))
                {
                    // add the user
                    applicationUsers.Add(user);
                }
            }

            ViewBag.SalePersons = new SelectList(applicationUsers, "Id", "Name"); ;



            var serviceList = (IEnumerable<Services>)(from p in _db.Services
                                                      join a in _db.ServicesAppointments
                                                      on p.Id equals a.ServiceId
                                                      where a.AppointmentId == id
                                                      select p).Include(x => x.ServiceType);

           
            AppointmentDetailsVM objAppointmentVM = new AppointmentDetailsVM()
            {
                Appointments = await _db.Appointments.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefaultAsync(),
                Services = serviceList.ToList()
            };
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (var item in serviceList)
            {
                if (serviceList.Count() < 1)
                {
                    parameters.Add("rp1", item.Name);
                    parameters.Add("rp2", item.Price.ToString());
                }
                if(serviceList.Count() < 2)
                {
                    parameters.Add("rp3", item.Name);
                    parameters.Add("rp4", item.Price.ToString());
                }
            }
            parameters.Add("rp5", objAppointmentVM.Appointments.CustomerName);
            parameters.Add("rp6", objAppointmentVM.Appointments.CustomerEmail);
            parameters.Add("rp7", objAppointmentVM.Appointments.CustomerPhoneNumber);
            parameters.Add("rp8", objAppointmentVM.Appointments.AppointmentDate.ToString());
            parameters.Add("rp9", objAppointmentVM.Appointments.AppointmentTime.ToString());
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
           // return View(objAppointmentVM);

        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var users =  _db.ApplicationUsers.ToList();
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            for (int i = 0; i < users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(users[i].Id);
                if ((await _userManager.IsInRoleAsync(user, StaticDetails.Role_Workshop)))
                {
                    // add the user
                    applicationUsers.Add(user);
                }
            }

            ViewBag.SalePersons = new SelectList(applicationUsers, "Id", "Name"); ;



            var serviceList = (IEnumerable<Services>)(from p in _db.Services
                                                      join a in _db.ServicesAppointments
                                                      on p.Id equals a.ServiceId
                                                      where a.AppointmentId == id
                                                      select p).Include(x=>x.ServiceType);

            AppointmentDetailsVM objAppointmentVM = new AppointmentDetailsVM()
            {
                Appointments = await _db.Appointments.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefaultAsync(),
                Services = serviceList.ToList()
            };

            return View(objAppointmentVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentDetailsVM objAppointmentVM)
        {
            if (ModelState.IsValid)
            {
                objAppointmentVM.Appointments.AppointmentDate = objAppointmentVM.Appointments.AppointmentDate
                                    .AddHours(objAppointmentVM.Appointments.AppointmentTime.Hour)
                                    .AddMinutes(objAppointmentVM.Appointments.AppointmentTime.Minute);

                var appointmentFromDb = await _db.Appointments.Where(a => a.Id == objAppointmentVM.Appointments.Id).FirstOrDefaultAsync();

                appointmentFromDb.CustomerName = objAppointmentVM.Appointments.CustomerName;
                appointmentFromDb.CustomerEmail = objAppointmentVM.Appointments.CustomerEmail;
                appointmentFromDb.CustomerPhoneNumber = objAppointmentVM.Appointments.CustomerPhoneNumber;
                appointmentFromDb.AppointmentDate = objAppointmentVM.Appointments.AppointmentDate;
                appointmentFromDb.isConfirmed = objAppointmentVM.Appointments.isConfirmed;
                if (User.IsInRole("Admin"))
                {
                    appointmentFromDb.SalesPersonId = objAppointmentVM.Appointments.SalesPersonId;
                }
                var users = _db.ApplicationUsers.ToList();
                List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
                for (int i = 0; i < users.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(users[i].Id);
                    if ((await _userManager.IsInRoleAsync(user, StaticDetails.Role_Workshop)))
                    {
                        // add the user
                        applicationUsers.Add(user);
                    }
                }

                ViewBag.SalePersons = new SelectList(applicationUsers, "Id", "Name"); ;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));


            }

            return View(objAppointmentVM);
        }

    }
}
