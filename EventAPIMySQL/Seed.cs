using EventAPIMySQL.Data;
using EventAPIMySQL.Models;

namespace EventAPIMySQL
{
    public class Seed
    {
        //prepopulate db with data
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            //if (!dataContext.GuestAllergies.Any())
            //{
            //    dataContext.GuestAllergies.AddRange(guestAllergies);
            //    dataContext.SaveChanges();
            //}
        }
    }
}
