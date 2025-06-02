namespace TransportationSystem.DTOs.BusDTO
{
    public class BusCreateDto
    {
        public int UniqueId { get; set; }
        public int BusNumber { get; set; }
        public string BusPlate { get; set; }
        public int Capacity { get; set; }
        public bool IsCapacityFull { get; set; } = false;
        public int BusTypeId { get; set; }
        public int BusRouteId { get; set; }
        public int DriverId{get; set;}
    }
}
