using FilmReview.Data;
using FilmReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomaniusMVC;
using System.Diagnostics;

namespace FilmReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> HomePage()
        {
            return View(await _context.Films.ToListAsync());
        }

        public async Task<IActionResult> FilmDetails(int id)
        {
            var films = await _context.Films.ToListAsync();
            FilmsAndData dataFilm = new FilmsAndData();
            dataFilm.Film = films.FirstOrDefault(f => f.FilmID == id);
            dataFilm.isAdmin = DataSessions.isAdmin(HttpContext);
            return View(dataFilm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}