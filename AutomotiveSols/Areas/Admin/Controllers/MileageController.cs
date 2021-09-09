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
    public class MileageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MileageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Mileage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mileages.ToListAsync());
        }

        // GET: Admin/Mileage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileage = await _context.Mileages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mileage == null)
            {
                return NotFound();
            }

            return View(mileage);
        }

        // GET: Admin/Mileage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mileage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberKm")] Mileage mileage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mileage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mileage);
        }

        // GET: Admin/Mileage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileage = await _context.Mileages.FindAsync(id);
            if (mileage == null)
            {
                return NotFound();
            }
            return View(mileage);
        }

        // POST: Admin/Mileage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumberKm")] Mileage mileage)
        {
            if (id != mileage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mileage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MileageExists(mileage.Id))
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
            return View(mileage);
        }

        // GET: Admin/Mileage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileage = await _context.Mileages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mileage == null)
            {
                return NotFound();
            }

            return View(mileage);
        }

        // POST: Admin/Mileage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mileage = await _context.Mileages.FindAsync(id);
            _context.Mileages.Remove(mileage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MileageExists(int id)
        {
            return _context.Mileages.Any(e => e.Id == id);
        }
    }
}
