using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult AboutMe()
        {
            ViewBag.Email = User.Identity?.Name;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SetPassword()
        {
            return View();
        }
    }
}