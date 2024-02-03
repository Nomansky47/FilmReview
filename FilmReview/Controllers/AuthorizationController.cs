using FilmReview.Data;
using FilmReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomaniusMVC;
using System.Net;

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
            ViewData["Authorization"] = "Welcome to Authorization Page";
            return View();
        }
        public IActionResult RegistrationPage()
        {
            ViewData["Registration"] = "Welcome to Authorization Page";
            return View();
        }

        public async Task<IActionResult> Register([Bind("UserID,UserLogin,Password,isAdmin,Surname,Name,Patronymic")] Users user)
        {
            if (_context.Users.FirstOrDefault(p => p.UserLogin == user.UserLogin) == null)
            {
                ViewData["Registration"] = "Welcome to Authorization Page";
                user.isAdmin = false;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("HomePage", "Home");
            }
            ViewData["Registration"] = "Пользователь с таким логином уже существует";
            return View("RegistrationPage");
        }
        public async  Task<IActionResult> Authorize(string Login,string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.UserLogin == Login&&p.Password==Password);
            if (user != null)
            {
                HttpContext.AddSession("userid", user.UserID.ToString());
                if (user.isAdmin == true)
                    HttpContext.setAdmin(true);
                else
                    HttpContext.setAdmin(false);
                return RedirectToAction("HomePage","Home");
            }
            else
            {
                ViewData["Authorization"] = "User not found, wrong login or password";
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
