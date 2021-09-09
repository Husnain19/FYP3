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
    public class TrimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Trim
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trims.ToListAsync());
        }

        // GET: Admin/Trim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trim = await _context.Trims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trim == null)
            {
                return NotFound();
            }

            return View(trim);
        }

        // GET: Admin/Trim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Trim trim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trim);
        }

        // GET: Admin/Trim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trim = await _context.Trims.FindAsync(id);
            if (trim == null)
            {
                return NotFound();
            }
            return View(trim);
        }

        // POST: Admin/Trim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Trim trim)
        {
            if (id != trim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrimExists(trim.Id))
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
            return View(trim);
        }

        // GET: Admin/Trim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trim = await _context.Trims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trim == null)
            {
                return NotFound();
            }

            return View(trim);
        }

        // POST: Admin/Trim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trim = await _context.Trims.FindAsync(id);
            _context.Trims.Remove(trim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrimExists(int id)
        {
            return _context.Trims.Any(e => e.Id == id);
        }
    }
}
