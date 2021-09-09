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
    public class CarCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public CarAppointmentVM CarAppointmentVM { get; set; }
        public CarCartController(ApplicationDbContext db)
        {
            _db = db;
            CarAppointmentVM = new CarAppointmentVM()
            {
                Cars = new List<AutomotiveSols.BLL.Models.Car>()
            };
        }

        public async Task<IActionResult> Index()
        {
            List<int> carCart = HttpContext.Session.Get<List<int>>("carCart");
            if (carCart.Count > 0)
            {
                foreach (int cartItem in carCart)
                {
                    Car car = await _db.Cars.Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                     .Where(p => p.Id == cartItem).FirstOrDefaultAsync();
                    CarAppointmentVM.Cars.Add(car);
                }
            }
            return View(CarAppointmentVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("carCart");

            CarAppointmentVM.Appointments.AppointmentDate = CarAppointmentVM.Appointments.AppointmentDate
                                                            .AddHours(CarAppointmentVM.Appointments.AppointmentTime.Hour)
                                                            .AddMinutes(CarAppointmentVM.Appointments.AppointmentTime.Minute);

            Appointments appointments = CarAppointmentVM.Appointments;
            _db.Appointments.Add(appointments);
            _db.SaveChanges();

            int appointmentId = appointments.Id;

            foreach (int carId in lstCartItems)
            {
                CarAppointment carsSelectedForAppointment = new CarAppointment()
                {
                    AppointmentId = appointmentId,
                    CarId = carId
                };
                _db.CarAppointments.Add(carsSelectedForAppointment);

            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("carCart", lstCartItems);

            return RedirectToAction("AppointmentConfirmation", "CarCart", new { Id = appointmentId });

        }

        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("carCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("carCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AppointmentConfirmation(int id)
        {
            CarAppointmentVM.Appointments = _db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            List<CarAppointment> objCarsList = _db.CarAppointments.Where(p => p.AppointmentId == id).ToList();

            foreach (CarAppointment carAptObj in objCarsList)
            {
                CarAppointmentVM.Cars.Add(_db.Cars.Include(x => x.Brand)
                                    .Include(x => x.Model)
                                    .Include(x => x.Mileage)
                                    .Include(x => x.Transmission)
                                    .Include(x => x.Trim)
                                    .Include(x => x.RegistrationCity)
                                    .Include(x => x.Year)
                                    .Where(p => p.Id == carAptObj.CarId).FirstOrDefault());
            }

            return View(CarAppointmentVM);
        }

    }
}
