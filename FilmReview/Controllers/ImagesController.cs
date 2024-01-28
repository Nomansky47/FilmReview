using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmReview.Data;
using FilmReview.Models;

namespace FilmReview.Controllers
{
    public class ImagesController : Controller
    {
        private readonly MyContext _context;

        public ImagesController(MyContext context)
        {
            _context = context;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Images.Include(i => i.Films);
            return View(await myContext.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .Include(i => i.Films)
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            ViewData["FilmID"] = new SelectList(_context.Films, "FilmID", "Country");
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageID,FilmID,Name,ImageLink")] Images images)
        {
                _context.Add(images);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }
            ViewData["FilmID"] = new SelectList(_context.Films, "FilmID", "Country", images.FilmID);
            return View(images);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageID,FilmID,Name,ImageLink")] Images images)
        {
            if (id != images.ImageID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(images);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagesExists(images.ImageID))
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

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .Include(i => i.Films)
                .FirstOrDefaultAsync(m => m.ImageID == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'MyContext.Images'  is null.");
            }
            var images = await _context.Images.FindAsync(id);
            if (images != null)
            {
                _context.Images.Remove(images);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagesExists(int id)
        {
          return (_context.Images?.Any(e => e.ImageID == id)).GetValueOrDefault();
        }
    }
}
