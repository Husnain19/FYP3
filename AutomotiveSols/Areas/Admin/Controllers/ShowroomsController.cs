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
    public class ShowroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Showrooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Showrooms.ToListAsync());
        }

        // GET: Admin/Showrooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showrooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showroom == null)
            {
                return NotFound();
            }

            return View(showroom);
        }

        // GET: Admin/Showrooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Showrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StreetAddress,City,State,PostalCode,PhoneNumber,IsAuthorizedCompany")] Showroom showroom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showroom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showroom);
        }

        // GET: Admin/Showrooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showrooms.FindAsync(id);
            if (showroom == null)
            {
                return NotFound();
            }
            return View(showroom);
        }

        // POST: Admin/Showrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StreetAddress,City,State,PostalCode,PhoneNumber,IsAuthorizedCompany")] Showroom showroom)
        {
            if (id != showroom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showroom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowroomExists(showroom.Id))
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
            return View(showroom);
        }

        // GET: Admin/Showrooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showroom = await _context.Showrooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showroom == null)
            {
                return NotFound();
            }

            return View(showroom);
        }

        // POST: Admin/Showrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showroom = await _context.Showrooms.FindAsync(id);
            _context.Showrooms.Remove(showroom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowroomExists(int id)
        {
            return _context.Showrooms.Any(e => e.Id == id);
        }
    }
}
