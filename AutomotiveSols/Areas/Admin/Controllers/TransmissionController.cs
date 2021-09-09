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
    public class TransmissionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransmissionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Transmission
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transmissions.ToListAsync());
        }

        // GET: Admin/Transmission/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // GET: Admin/Transmission/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Transmission/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transmission);
        }

        // GET: Admin/Transmission/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }
            return View(transmission);
        }

        // POST: Admin/Transmission/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Transmission transmission)
        {
            if (id != transmission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransmissionExists(transmission.Id))
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
            return View(transmission);
        }

        // GET: Admin/Transmission/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // POST: Admin/Transmission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transmission = await _context.Transmissions.FindAsync(id);
            _context.Transmissions.Remove(transmission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransmissionExists(int id)
        {
            return _context.Transmissions.Any(e => e.Id == id);
        }
    }
}
