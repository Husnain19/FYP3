using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistrationCitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationCitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/RegistrationCities
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrationCities.ToListAsync());
        }

        // GET: Admin/RegistrationCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationCity = await _context.RegistrationCities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationCity == null)
            {
                return NotFound();
            }

            return View(registrationCity);
        }

        // GET: Admin/RegistrationCities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RegistrationCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RegistrationCity registrationCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationCity);
        }

        // GET: Admin/RegistrationCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationCity = await _context.RegistrationCities.FindAsync(id);
            if (registrationCity == null)
            {
                return NotFound();
            }
            return View(registrationCity);
        }

        // POST: Admin/RegistrationCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RegistrationCity registrationCity)
        {
            if (id != registrationCity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationCityExists(registrationCity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registrationCity);
        }

        // GET: Admin/RegistrationCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationCity = await _context.RegistrationCities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationCity == null)
            {
                return NotFound();
            }

            return View(registrationCity);
        }

        // POST: Admin/RegistrationCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationCity = await _context.RegistrationCities.FindAsync(id);
            _context.RegistrationCities.Remove(registrationCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationCityExists(int id)
        {
            return _context.RegistrationCities.Any(e => e.Id == id);
        }
    }
}
