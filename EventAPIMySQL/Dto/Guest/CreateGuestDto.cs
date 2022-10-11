using EventAPIMySQL.Dto.Allergy;

namespace EventAPIMySQL.Dto.Guest
{
    public class CreateGuestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<CreateAllergyDto>? allergies { get; set; }
    }
    public static class CreateGuestDtoExtensions
    {
        public static Models.Guest ToGuestModel(this CreateGuestDto guest)
        {
            return new Models.Guest
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }
    }

}
