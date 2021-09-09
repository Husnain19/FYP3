using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServiceTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType) 
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //POST Edit action Method for The serice type
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //GET Details of the Serice types
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }


        //GET Delete the serive type by passing the id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceType = await _db.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        //POST Delete for the better security
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceType = await _db.ServiceTypes.FindAsync(id);
            _db.ServiceTypes.Remove(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
