using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult>  Index()
        {
            return View ( await _db.SubCategories.Include(x=>x.Category).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
           ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                await _db.SubCategories.AddAsync(subCategory);
               await  _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
                SubCategory subCategory = new SubCategory();

                subCategory = _db.SubCategories.Find(id);
            
            if (subCategory == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList = new SelectList(_db.Categories.ToList(), "Id", "Name");

            
            return View(subCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubCategory subcategory)
        {
            if (id != subcategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(subcategory);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subcategory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _db.SubCategories.Include(x=>x.Category).Where(x=>x.Id==id).FirstOrDefaultAsync();
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        //POST Delete for the better security
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategory = await _db.SubCategories.FindAsync(id);
            _db.SubCategories.Remove(subcategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}
