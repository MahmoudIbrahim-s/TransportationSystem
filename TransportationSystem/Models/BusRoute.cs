namespace TransportationSystem.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string RouteName { get; set; } 
        public string StartPoint { get; set; } 
        public string EndPoint { get; set; } 
        public string Schedule { get; set; }
        
      
      public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public ICollection<BusStop> Stops { get; set; } = new List<BusStop>();

    }
}
