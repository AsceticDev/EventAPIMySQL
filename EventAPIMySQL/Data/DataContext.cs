using EventAPIMySQL.Models;
using Microsoft.AspNetCore.Mvc;
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

            modelBuilder.Entity<GuestAllergy>().HasKey(ga => new { ga.GuestId, ga.AllergyId});

            modelBuilder.Entity<GuestAllergy>()
                .HasOne(ga => ga.Guest)
                .WithMany(g => g.GuestAllergies)
                .HasForeignKey(ga => ga.GuestId);
            modelBuilder.Entity<GuestAllergy>()
                .HasOne(g=>g.Allergy)
                .WithMany(ga => ga.GuestAllergies)
                .HasForeignKey(ga => ga.AllergyId);


            modelBuilder.Entity<EventGuest>().HasKey(eg => new { eg.EventId, eg.GuestId });

            modelBuilder.Entity<EventGuest>()
                .HasOne(e => e.Guest)
                .WithMany(eg => eg.GuestEvents)
                .HasForeignKey(e => e.GuestId);
            modelBuilder.Entity<EventGuest>()
                .HasOne(g=>g.Event)
                .WithMany(ga => ga.GuestEvents)
                .HasForeignKey(ga => ga.EventId);

        }
    }
}
