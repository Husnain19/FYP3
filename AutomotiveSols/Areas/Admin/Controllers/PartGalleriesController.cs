using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomotiveSols.BLL.Models;
using AutomotiveSols.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AutomotiveSols.Static;

namespace AutomotiveSols.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartGalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PartGalleriesController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/PartGalleries
        public async Task<IActionResult> Index() { 
        //{
        //    PartGallery partGallery = new PartGallery();
        //    var displayImg = Path.Combine(_webHostEnvironment.WebRootPath, "parts/gallery");
        //    DirectoryInfo directoryInfo = new DirectoryInfo(displayImg);
        //    FileInfo[] fileInfos = directoryInfo.GetFiles();
        //    partGallery.
            var applicationDbContext = _context.PartGalleries.Include(p => p.AutoPart);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/PartGalleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partGallery = await _context.PartGalleries
                .Include(p => p.AutoPart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partGallery == null)
            {
                return NotFound();
            }

            return View(partGallery);
        }

        // GET: Admin/PartGalleries/Create
        public IActionResult Create()
        {
            ViewData["AutoPartId"] = new SelectList(_context.AutoParts, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutoPartId,Name,URL")] PartGallery partGallery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partGallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoPartId"] = new SelectList(_context.AutoParts, "Id", "Name", partGallery.AutoPartId);
            return View(partGallery);
        }

        // GET: Admin/PartGalleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partGallery = await _context.PartGalleries.Include(x => x.AutoPart)
                .Where(x => x.AutoPartId == id).ToListAsync();
            if (partGallery == null)
            {
                return NotFound();
            }
            ViewData["AutoPartId"] = new SelectList(_context.AutoParts, "Id", "Name");
            return View(partGallery);
        }

        // POST: Admin/PartGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutoPartId,Name,URL")] PartGallery partGallery)
        {
            if (id != partGallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partGallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartGalleryExists(partGallery.Id))
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
            ViewData["AutoPartId"] = new SelectList(_context.AutoParts, "Id", "Name", partGallery.AutoPartId);
            return View(partGallery);
        }

        // GET: Admin/PartGalleries/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var partGallery = await _context.PartGalleries
        //        .Include(p => p.AutoPart)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (partGallery == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(partGallery);
        //}
        public IActionResult Delete(string imgdel)
        {

                string webRootPath = _webHostEnvironment.WebRootPath;


            var partGallery = _context.PartGalleries
                .Include(p => p.AutoPart)
                .FirstOrDefault(m => m.Name == imgdel);
            imgdel = Path.Combine(_webHostEnvironment.WebRootPath, "parts/gallery/", imgdel);
            FileInfo fi = new FileInfo(imgdel);
            if (fi != null)
            {
                System.IO.File.Delete(imgdel);
                fi.Delete();
            }
            _context.PartGalleries.Remove(partGallery);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
            // POST: Admin/PartGalleries/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(int id)
            //{
            //    var partGallery = await _context.PartGalleries.FindAsync(id);
            //    string webRootPath = _webHostEnvironment.WebRootPath;
            //    var imagePath = Path.Combine(webRootPath, partGallery.URL.TrimStart('\\'));
            //    if (System.IO.File.Exists(imagePath))
            //    {
            //        System.IO.File.Delete(imagePath);
            //    }

            //    _context.PartGalleries.Remove(partGallery);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));

 //           }
        
        private bool PartGalleryExists(int id)
        {
            return _context.PartGalleries.Any(e => e.Id == id);
        }
    }
}
