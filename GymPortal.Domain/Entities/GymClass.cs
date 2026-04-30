namespace GymPortal.Domain.Entities
{
    public class GymClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Instructor { get; set; }
        public string? Category { get; set; }
    }
}