using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmReview.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult AuthorizationPage()
        {
            return View();
        }
    }
}
