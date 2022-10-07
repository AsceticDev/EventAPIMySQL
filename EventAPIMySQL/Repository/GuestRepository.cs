using EventAPIMySQL.Data;
using EventAPIMySQL.Interfaces;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataContext _context;

        public GuestRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Guest> GetGuests()
        {
            return _context.Guests
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Guest GetGuest(int guestId)
        {
            return _context.Guests
                .Where(g => g.Id == guestId)
                .FirstOrDefault();
        }

        public Guest GetGuest(string lastName)
        {
            return _context.Guests
                .Where(g => g.LastName == lastName)
                .FirstOrDefault(); 
        }

        public bool GuestExists(int guestId)
        {
            return _context.Guests
                .Any(g => g.Id == guestId);
        }

        public bool CreateGuest(Guest guest)
        {
            _context.Add(guest);
            return Save();
        }
        public bool UpdateGuest(Guest guest)
        {
            _context.Update(guest);
            return Save();
        }
        
        public bool DeleteGuest(Guest guest)
        {
            _context.Remove(guest);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
