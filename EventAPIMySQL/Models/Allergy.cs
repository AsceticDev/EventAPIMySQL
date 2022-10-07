using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventAPIMySQL.Models
{
    [Index(nameof(AllergyType), IsUnique=true)]
    public class Allergy
    {
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Must be between 4 and 30 characters.")]
        public string AllergyType { get; set; } = string.Empty;

        //optional
        public ICollection<GuestAllergy> GuestAllergies { get; set; }
    }

}
