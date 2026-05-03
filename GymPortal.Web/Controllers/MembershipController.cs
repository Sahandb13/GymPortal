using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}