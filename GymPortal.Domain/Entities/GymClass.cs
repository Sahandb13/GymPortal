namespace GymPortal.Domain.Entities;

public class GymClass
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string Instructor { get; set; } = null!;

    public int Capacity { get; set; }

    public List<Booking> Bookings { get; set; } = new();
}