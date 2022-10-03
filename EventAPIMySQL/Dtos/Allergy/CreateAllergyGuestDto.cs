using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Allergy
{
    public class CreateAllergyGuestDto
    {
        public string AllergyType { get; set; } = string.Empty;

    }

    public static class CreateGuestAllergyDtoExtensions
    {
        public static CreateAllergyGuestDto ToCreateAllergyGuestDto(this ReadAllergyDto allergy)
        {
            return new CreateAllergyGuestDto
            {
                AllergyType = allergy.AllergyType
            };
        }
    }
}
