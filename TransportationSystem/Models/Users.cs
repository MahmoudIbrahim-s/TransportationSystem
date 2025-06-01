namespace TransportationSystem.Models
{
    public class Users
    {
        public  int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true; // Indicates if the user account is active
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp for when the user was created
        public DateTime? LastLoginAt { get; set; } // Timestamp for the last login, nullable if never logged in
        // Navigation properties can be added here if needed, e.g., for related entities
       public ICollection<Roles> Roles { get; set; } = new List<Roles>();
    }
}
