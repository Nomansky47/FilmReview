using FilmReview.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmReview.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly MyContext _context;
        public AuthorizationController(MyContext context)
        {
            _context = context;
        }
        public IActionResult AuthorizationPage()
        {
            return View();
        }
        public async  Task<IActionResult> Authorize(string Login,string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.UserLogin == Login&&p.Password==Password);
            if (user != null)
            {
                if (user.isAdmin == true)
                    HttpContext.setAdmin(true);
                else
                    HttpContext.setAdmin(false);
                return View("~/Views/Home/HomePage.cshtml");
            }
            else
            {
                ViewData["Message"] = "User not found, wrong login or password";
                return View("AuthorizationPage");
            }
        }
    }
}
