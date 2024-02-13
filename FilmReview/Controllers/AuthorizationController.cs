using FilmReview.Data;
using FilmReview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomaniusMVC;
using NuGet.Protocol.Plugins;
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
        [Route("Register/{NickName}/{UserLogin}/{Password}/{Surname}/{Name}/{Patronymic?}")]
        public async Task<IActionResult> Register(string NickName,string UserLogin,string Password,string Surname,string Name,string? Patronymic)
        {
            Users user = new Users();
            user.NickName = NickName;
            user.UserLogin = UserLogin;
            user.Password = Password;
            user.Surname = Surname;
            user.Name = Name;
            user.Patronymic = Patronymic;
            if (_context.Users.FirstOrDefault(p => p.UserLogin == user.UserLogin) == null)
            {
                user.isAdmin = false;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("HomePage", "Home");
            }
            return View("HomePage","Not");
        }
        [Route("Auth/{userid}/{isAdmin}")]
          public IActionResult Auth(string userid,bool isAdmin)
          {
                  HttpContext.AddSession("userid", userid);
                  if (isAdmin == true)
                      HttpContext.setAdmin(true);
                  else
                      HttpContext.setAdmin(false);
                  return RedirectToAction("HomePage","Home");
          }
        
        public IActionResult Exit()
        {
            HttpContext.DeleteAllSessions();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
