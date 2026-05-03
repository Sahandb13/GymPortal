using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}