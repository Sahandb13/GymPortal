using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult MyBookings()
        {
            return View();
        }
    }
}