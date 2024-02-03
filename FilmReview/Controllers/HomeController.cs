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
            FilmsAndData FilmsAndData = new FilmsAndData();
            FilmsAndData.Film = films.FirstOrDefault(f => f.FilmID == id);
            FilmsAndData.isAdmin = DataSessions.isAdmin(HttpContext);
            if (HttpContext.GetSession("userid")!=null)
            FilmsAndData.currentUserID = int.Parse(HttpContext.GetSession("userid"));
            return View(FilmsAndData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}