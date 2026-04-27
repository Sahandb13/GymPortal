namespace GymPortal.Domain.Entities;

public class Membership
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Type { get; set; } = null!; // Basic / Premium

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive => EndDate > DateTime.UtcNow;
}