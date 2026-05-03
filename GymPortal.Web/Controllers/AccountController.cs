using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AboutMe()
        {
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