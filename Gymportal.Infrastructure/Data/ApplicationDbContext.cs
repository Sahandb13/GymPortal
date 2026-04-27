using GymPortal.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Gymportal.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Membership> Memberships { get; set; }
    public DbSet<GymClass> GymClasses { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}