using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.BLL.ViewModels;
using AutomotiveSols.Data;
using AutomotiveSols.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveSols.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TempCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ServiceCartVM ServiceCartVM { get; set; }
        public TempCartController(ApplicationDbContext db)
        {
            _db = db;
            ServiceCartVM = new ServiceCartVM()
            {
                Services = new List<AutomotiveSols.BLL.Models.Services>()
            };
         }
        public async Task<IActionResult> Index()
        {
            List<int> tempCart = HttpContext.Session.Get<List<int>>("tempCart");
            if (tempCart.Count > 0)
            {
                foreach (int cartItem in tempCart)
                {
                    Services service = await _db.Services.Include(p => p.ServiceType).Where(p => p.Id == cartItem).FirstOrDefaultAsync();
                    ServiceCartVM.Services.Add(service);
                }
            }
            return View(ServiceCartVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("tempCart");

            ServiceCartVM.Appointments.AppointmentDate = ServiceCartVM.Appointments.AppointmentDate
                                                            .AddHours(ServiceCartVM.Appointments.AppointmentTime.Hour)
                                                            .AddMinutes(ServiceCartVM.Appointments.AppointmentTime.Minute);

            Appointments appointments = ServiceCartVM.Appointments;
            _db.Appointments.Add(appointments);
            _db.SaveChanges();

            int appointmentId = appointments.Id;

            foreach (int productId in lstCartItems)
            {
                ServicesAppointment productsSelectedForAppointment = new ServicesAppointment()
                {
                    AppointmentId = appointmentId,
                    ServiceId = productId
                };
                _db.ServicesAppointments.Add(productsSelectedForAppointment);

            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("tempCart", lstCartItems);

            return RedirectToAction("AppointmentConfirmation", "TempCart", new { Id = appointmentId });

        }

        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("tempCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("tempCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AppointmentConfirmation(int id)
        {
            ServiceCartVM.Appointments = _db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            List<ServicesAppointment> objServicesList = _db.ServicesAppointments.Where(p => p.AppointmentId == id).ToList();

            foreach (ServicesAppointment serviceAptObj in objServicesList)
            {
                ServiceCartVM.Services.Add(_db.Services.Include(p => p.ServiceType).Where(p => p.Id == serviceAptObj.ServiceId).FirstOrDefault());
            }

            return View(ServiceCartVM);
        }

    }
}