using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Guest;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Interfaces
{
    public interface IGuestRepository
    {
        ICollection<Guest> GetGuests();
        //ICollection<Guest> GetGuest(string lastName);
        ICollection<Guest> GetGuestsByAllergy(string allergyType);
        ICollection<Guest> GetGuestsByEvent(int eventId);
        Guest GetGuestByEmailTrimToUpper(CreateGuestDto guestCreate);
        Guest GetGuest(int guestId);
        bool AddAllergiesToGuest(int guestId, List<CreateAllergyDto> allergies);
        bool UpdateGuestAllergies(UpdateGuestDto updatedGuest, List<UpdateAllergyDto> allergyListToAdd, List<UpdateAllergyDto> allergyListToRemove);
        bool GuestExists(int guestId);
        bool CreateGuest(Guest guest);
        bool UpdateGuest(Guest guest);
        bool DeleteGuest(Guest guest);
        bool Save();
    }
}
