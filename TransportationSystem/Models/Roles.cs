namespace TransportationSystem.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } // Optional description for the role
        public bool IsActive { get; set; } = true; // Indicates if the role is currently active
        // Navigation properties can be added here if needed, e.g., for related entities
        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}
