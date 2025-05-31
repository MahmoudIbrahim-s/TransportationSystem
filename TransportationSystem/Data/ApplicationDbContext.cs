using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TransportationSystem.Models;

namespace TransportationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BusType> BusTypes { get; set; }
       
        
    }
}
