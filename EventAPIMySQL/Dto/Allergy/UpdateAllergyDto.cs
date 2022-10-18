namespace EventAPIMySQL.Dto.Allergy
{
    public class UpdateAllergyDto
    {
        public int Id { get; set; }
        public string AllergyType { get; set; }
    }
    public static class UpdateAllergyDtoExtensions
    {
        public static UpdateAllergyDto ToUpdateAllergyDto(this Models.Allergy allergy)
        {
            return new UpdateAllergyDto
            {
                Id = allergy.Id,
                AllergyType = allergy.AllergyType
            };
        }
    }

}
