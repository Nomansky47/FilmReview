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
        [Route("Exit")]
        public IActionResult Exit()
        {
            HttpContext.DeleteAllSessions();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
