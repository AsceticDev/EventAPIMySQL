using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Event;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dto.Guest
{
    public class ReadGuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<ReadAllergyDto> Allergies { get; set; }
        public ICollection<ReadEventDto> Events { get; set; }

    }

    public static class ReadGuestDtoExtensions
    {
        public static ReadGuestDto ToReadGuestDto(this Models.Guest guest)
        {
            return new ReadGuestDto
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
                Allergies = guest.GuestAllergies.Select(ga=>ga.ToReadAllergyDto()).ToList(),
                Events = guest.GuestEvents.Select(ga=>ga.ToReadEventDto()).ToList()
            };
        }
    }
}
