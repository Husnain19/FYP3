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

namespace AutomotiveSols.Areas.Admin.Controllers
{
   // [Authorize(Roles = "Admin,Workshop")]
    [Area("Admin")]

    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentController(ApplicationDbContext db,UserManager<ApplicationUser> userManager)
        {
            _db = db;
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
            if (User.IsInRole("Workshop"))
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(x => x.SalesPersonId == saleperson.Id).ToList();
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.SalePersons = new SelectList(_db.ApplicationUsers.ToList(), "Id", "Name"); ;

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

                ViewBag.SalePersons = new SelectList(_db.ApplicationUsers.ToList(), "Id", "Name"); ;
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));


            }

            return View(objAppointmentVM);
        }

    }
}
