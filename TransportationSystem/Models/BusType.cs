namespace TransportationSystem.Models
{
    public class BusType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Description { get; set; }
       public ICollection<Bus> Buses { get; set; } = new List<Bus>();
    }
}
