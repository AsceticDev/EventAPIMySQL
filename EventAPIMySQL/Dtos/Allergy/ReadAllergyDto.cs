
namespace EventAPIMySQL.Dtos.Allergy
{
    public class ReadAllergyDto
    {
        public string AllergyType { get; set; } = string.Empty;
    }

    public static class ReadAllergyDtoExtensions
    {
        public static ReadAllergyDto ToReadAllergyDto(this ReadAllergyDto allergy)

        {
            return new ReadAllergyDto
            {
                AllergyType = allergy.AllergyType
            };
        }
    }
}
