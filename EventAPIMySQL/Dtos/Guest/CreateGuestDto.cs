using EventAPIMySQL.Dtos.Allergy;

namespace EventAPIMySQL.Dtos.Guest
{
    public class CreateGuestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        //optional, can have many
        public List<CreateAllergyDto> Allergies { get; set; } = new List<CreateAllergyDto>();

    }
}
