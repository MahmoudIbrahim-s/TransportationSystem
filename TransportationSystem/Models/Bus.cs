namespace TransportationSystem.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public int uniqueId { get; set; } 
        public string BusName { get; set; }
        public string BusPlate { get; set; } 
        public int Capacity { get; set; }
        public bool IsCapacityFull { get; set; } = false;

        // Foreign keys and navigation properties
        public int BusTypeId { get; set; }  
        public BusType BusType { get; set; } = new BusType();
        public int BusRouteId { get; set; }
        public BusRoute BusRoute { get; set; } = new BusRoute();
        public int DriverId { get; set; }
        public Employees Driver { get; set; } = new Employees();


        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
