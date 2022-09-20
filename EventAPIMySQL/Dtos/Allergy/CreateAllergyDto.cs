using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Allergy
{
    public class CreateAllergyDto
    {
        public string AllergyType { get; set; } = string.Empty;
        public List<CreateGuestDto> Guests { get; set; } = new List<CreateGuestDto>();

    }
}
