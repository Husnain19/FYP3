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
    public class FeatureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeatureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Feature
        public async Task<IActionResult> Index()
        {
            return View(await _context.Features.ToListAsync());
        }

        // GET: Admin/Feature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // GET: Admin/Feature/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Features features)
        {
            if (ModelState.IsValid)
            {
                _context.Add(features);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(features);
        }

        // GET: Admin/Feature/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features.FindAsync(id);
            if (features == null)
            {
                return NotFound();
            }
            return View(features);
        }

        // POST: Admin/Feature/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Features features)
        {
            if (id != features.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(features);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesExists(features.Id))
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
            return View(features);
        }

        // GET: Admin/Feature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // POST: Admin/Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var features = await _context.Features.FindAsync(id);
            _context.Features.Remove(features);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturesExists(int id)
        {
            return _context.Features.Any(e => e.Id == id);
        }
    }
}
