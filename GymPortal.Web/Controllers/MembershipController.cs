using GymPortal.Domain.Entities;
using GymPortal.Infrastructure.Data;
using GymPortal.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers
{
    public class MembershipController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MembershipController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyMembership()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(x => x.UserId == user.Id);

            return View(membership);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(string type)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var exists = await _context.Memberships
                .AnyAsync(x => x.UserId == user.Id);

            if (exists)
                return RedirectToAction("MyMembership");

            var membership = new Membership
            {
                UserId = user.Id,
                Type = type,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1)
            };

            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyMembership");
        }
    }
}