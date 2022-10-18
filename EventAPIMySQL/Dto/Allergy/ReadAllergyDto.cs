using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dto.Allergy
{
    public class ReadAllergyDto
    {
        public int Id { get; set; }
        public string AllergyType { get; set; }
    }
    public static class ReadAllergyDtoExtensions
    {
        public static ReadAllergyDto ToReadAllergyDto(this Models.Allergy allergy)
        {
            return new ReadAllergyDto 
            {
                Id = allergy.Id,
                AllergyType = allergy.AllergyType
            };
        }

        public static ReadAllergyDto GuestAllergyToReadAllergyDto(this GuestAllergy guestAllergy)
        {
            return new ReadAllergyDto
            {
                Id = guestAllergy.AllergyId,
                AllergyType = guestAllergy.Allergy.AllergyType
            };
        }
    }

}
