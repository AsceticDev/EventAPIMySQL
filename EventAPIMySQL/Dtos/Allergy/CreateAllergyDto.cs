using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Allergy
{
    public class CreateAllergyDto
    {
        public string AllergyType { get; set; } = string.Empty;
        public List<CreateGuestDto> Guests { get; set; } = new List<CreateGuestDto>();

    }

    public static class CreateAllergyDtoExtensions
    {
        public static CreateAllergyDto ToCreateAllergyDto(this ReadAllergyDto allergy)
        {
            return new CreateAllergyDto
            {
                AllergyType = allergy.AllergyType
            };
        }
    }
}
