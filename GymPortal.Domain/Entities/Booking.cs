namespace GymPortal.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int GymClassId { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.UtcNow;
    }
}