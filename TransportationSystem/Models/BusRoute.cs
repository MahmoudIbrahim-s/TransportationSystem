namespace TransportationSystem.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string RouteName { get; set; } 
        public string StartLocation { get; set; } 
        public string EndLocation { get; set; } 
        public string Schedule { get; set; }
        
      
      public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public ICollection<BusStop> Stops { get; set; } = new List<BusStop>();




    }
}
