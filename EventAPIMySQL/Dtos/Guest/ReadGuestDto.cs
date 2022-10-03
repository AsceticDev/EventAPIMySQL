using EventAPIMySQL.Dtos.Allergy;
using EventAPIMySQL.Dtos.Event;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dtos.Guest
{
    public class ReadGuestDto
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        //optional, can have many
        public ICollection<ReadAllergyDto> Allergies { get; set; } = new List<ReadAllergyDto>();

        //will not add events when creating a guest, will add them when creating the event itself
        public ICollection<ReadEventDto> Events { get; set; } = new List<ReadEventDto>();
    }
    public static class ReadGuestDtoExtensions
    {
        public static ReadGuestDto ToReadGuestDto(this Models.Guest guest)
        {
            return new ReadGuestDto
            {
                GuestId = guest.GuestId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
                Allergies = guest.Allergies.Select(a => a.ToReadAllergyDto()).ToList()
            };
        }
        public static Models.Guest ToGuestModel(this ReadGuestDto guest)
        {
            return new Models.Guest
            {
                GuestId = guest.GuestId
            };
        }

    }


}


