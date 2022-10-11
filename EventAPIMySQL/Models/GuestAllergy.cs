using EventAPIMySQL.Dto.Allergy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Models
{
    public class GuestAllergy
    {
        public int GuestId { get; set; }
        public Guest Guest { get; set; } 

        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }

    }
    public static class GuestAllergyExtensions
    {
        public static ReadAllergyDto ToReadAllergyDto(this GuestAllergy guestAllergy)
        {
            return new ReadAllergyDto
            {
                id = guestAllergy.AllergyId,
                AllergyType = guestAllergy.Allergy.AllergyType
            };
        }
    }

}
