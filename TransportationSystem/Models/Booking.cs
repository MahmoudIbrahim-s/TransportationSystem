namespace TransportationSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int BusId { get; set; }
        public Bus Bus { get; set; } = null!;

        public DateTime BookingDate { get; set; }
        public string? Notes { get; set; }
    }
}
