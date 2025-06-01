namespace TransportationSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; } // e.g., "Credit Card", "Cash", etc.
        public string? Notes { get; set; } 
    }
}
