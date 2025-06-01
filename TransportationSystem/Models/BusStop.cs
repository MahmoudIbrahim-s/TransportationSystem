namespace TransportationSystem.Models
{
    public class BusStop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StopOrder { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
        // Navigation properties
        public int BusRouteId { get; set; }
        public BusRoute BusRoute { get; set; } = null!;
       
    }
}
