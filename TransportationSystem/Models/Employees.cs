
using System.ComponentModel.DataAnnotations;

namespace TransportationSystem.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string? JobDescription { get; set; }
        public DateTime HireDate { get; set; } 
        public decimal Salary { get; set; }
        public ICollection<Bus> AssignedBuses { get; set; } = new List<Bus>();


    }
}
