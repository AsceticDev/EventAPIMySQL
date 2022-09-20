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
    }
}
