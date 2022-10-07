using EventAPIMySQL.Models;

namespace EventAPIMySQL.Interfaces
{
    public interface IGuestRepository
    {
        ICollection<Guest> GetGuests();
        //ICollection<Guest> GetGuest(string lastName);
        Guest GetGuest(int guestId);
        bool GuestExists(int guestId);
        bool CreateGuest(Guest guest);
        bool UpdateGuest(Guest guest);
        bool DeleteGuest(Guest guest);
        bool Save();
    }
}
