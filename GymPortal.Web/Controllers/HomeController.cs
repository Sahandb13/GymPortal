
using GymPortal.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers;

public class GymClassesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GymClassesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var classes = await _context.GymClasses
            .OrderBy(c => c.Date)
            .ThenBy(c => c.StartTime)
            .ToListAsync();

        return View(classes);
    }
}