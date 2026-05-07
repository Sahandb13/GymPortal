using GymPortal.Domain.Entities;
using GymPortal.Infrastructure.Data;
using GymPortal.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyBookings()
        {
            var user = await _userManager.GetUserAsync(User);

            var bookings = await _context.Bookings
                .Include(b => b.GymClass)
                .Where(b => b.UserId == user!.Id)
                .ToListAsync();

            return View(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int gymClassId)
        {
            var user = await _userManager.GetUserAsync(User);

            var alreadyBooked = await _context.Bookings
                .AnyAsync(b => b.UserId == user!.Id && b.GymClassId == gymClassId);

            if (!alreadyBooked)
            {
                var booking = new Booking
                {
                    UserId = user!.Id,
                    GymClassId = gymClassId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyBookings");
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == user!.Id);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MyBookings");
        }
    }
}