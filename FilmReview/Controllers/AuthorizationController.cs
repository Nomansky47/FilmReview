using FilmReview.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomaniusMVC;

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
                return RedirectToAction("HomePage","Home");
            }
            else
            {
                ViewData["Message"] = "User not found, wrong login or password";
                return View("AuthorizationPage");
            }
        }
        public IActionResult Exit()
        {
            HttpContext.DeleteAllSessions();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
