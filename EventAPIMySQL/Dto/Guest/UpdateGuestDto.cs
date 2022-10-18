using EventAPIMySQL.Dto.Allergy;
using EventAPIMySQL.Dto.Event;
using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dto.Guest
{
    public class UpdateGuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<UpdateAllergyDto>? allergies{ get; set; }
        public ICollection<UpdateEventDto>? events{ get; set; } 

    }
    public static class UpdateGuestDtoExtensions
    {
        public static Models.Guest ToGuestModel(this UpdateGuestDto guest)
        {
            return new Models.Guest
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }
    }

}
