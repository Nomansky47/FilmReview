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
    public class VideosController : Controller
    {
        private readonly MyContext _context;

        public VideosController(MyContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Videos.Include(v => v.Films);
            return View(await myContext.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .Include(v => v.Films)
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["FilmID"] = new SelectList(_context.Films, "FilmID", "About");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,FilmID,Link")] Videos videos)
        {
                _context.Add(videos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos.FindAsync(id);
            if (videos == null)
            {
                return NotFound();
            }
            ViewData["FilmID"] = new SelectList(_context.Films, "FilmID", "About", videos.FilmID);
            return View(videos);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,FilmID,Link")] Videos videos)
        {
            if (id != videos.VideoID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(videos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideosExists(videos.VideoID))
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

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var videos = await _context.Videos
                .Include(v => v.Films)
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (videos == null)
            {
                return NotFound();
            }

            return View(videos);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'MyContext.Videos'  is null.");
            }
            var videos = await _context.Videos.FindAsync(id);
            if (videos != null)
            {
                _context.Videos.Remove(videos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideosExists(int id)
        {
          return (_context.Videos?.Any(e => e.VideoID == id)).GetValueOrDefault();
        }
    }
}
