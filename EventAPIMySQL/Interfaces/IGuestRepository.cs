using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Guest;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Interfaces
{
    public interface IGuestRepository
    {
        ICollection<Guest> GetGuests();
        //ICollection<Guest> GetGuest(string lastName);
        ICollection<Guest> GetGuestByAllergy(string allergyType);
        ICollection<Guest> GetGuestByEvent(int eventId);

        bool AddAllergiesToGuest(int guestId, List<CreateAllergyDto> allergies);
        Guest GetGuestByEmailTrimToUpper(CreateGuestDto guestCreate);
        Guest GetGuest(int guestId);
        bool GuestExists(int guestId);
        bool CreateGuest(Guest guest);
        bool UpdateGuest(Guest guest);
        bool DeleteGuest(Guest guest);
        bool Save();
    }
}
