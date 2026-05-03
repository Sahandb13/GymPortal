using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class CustomerServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}