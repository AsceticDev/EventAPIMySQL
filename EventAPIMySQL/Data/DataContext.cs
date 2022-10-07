using EventAPIMySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPIMySQL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events{ get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<EventGuest> GuestEvents{ get; set; }
        public DbSet<GuestAllergy> GuestAllergies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestAllergy>()
                .HasKey(ga => new { ga.GuestId, ga.AllergyId});
            modelBuilder.Entity<GuestAllergy>()
                .HasOne(g => g.Guest)
                .WithMany(ga => ga.GuestAllergies)
                .HasForeignKey(a => a.GuestId);

            modelBuilder.Entity<EventGuest>()
                .HasKey(eg => new { eg.EventId, eg.GuestId });
            modelBuilder.Entity<EventGuest>()
                .HasOne(e => e.Event)
                .WithMany(eg => eg.EventGuests)
                .HasForeignKey(e => e.EventId);
        }
    }
}
