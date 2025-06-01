using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TransportationSystem.Models;

namespace TransportationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BusType> BusTypes { get; set; }    
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }

        // Configuring the model relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring BusType
            modelBuilder.Entity<BusType>()
                .HasMany(bt => bt.Buses)
                .WithOne(b => b.BusType)
                .HasForeignKey(b => b.BusTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Configuring BusRoute
            modelBuilder.Entity<BusRoute>()
                .HasMany(br => br.Buses)
                .WithOne(b => b.BusRoute)
                .HasForeignKey(b => b.BusRouteId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BusRoute>()
                .HasMany(br => br.Stops)
                .WithOne(bs => bs.BusRoute)
                .HasForeignKey(bs => bs.BusRouteId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configuring Bus
            modelBuilder.Entity<Bus>()
                .HasOne(b => b.Driver)
                .WithMany(e => e.AssignedBuses)
                .HasForeignKey(b => b.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configuring Booking
            modelBuilder.Entity<Booking>()
                .HasOne(bk => bk.Student)
                .WithMany(s => s.Bookings)
                .HasForeignKey(bk => bk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Booking>()
                .HasOne(bk => bk.Bus)
                .WithMany(b => b.Bookings)
                .HasForeignKey(bk => bk.BusId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configuring Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configuring Student
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Bookings)
                .WithOne(bk => bk.Student)
                .HasForeignKey(bk => bk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            // Configuring bus stop
            modelBuilder.Entity<BusStop>()
                .HasOne(bs => bs.BusRoute)
                .WithMany(br => br.Stops)
                .HasForeignKey(bs => bs.BusRouteId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}