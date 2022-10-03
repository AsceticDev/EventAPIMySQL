using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Models
{
    public class GuestAllergy
    {
        [Key, Column(Order = 1)]
        public int GuestId { get; set; }
        
        [Key, Column(Order = 2)]
        public int AllergyId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; } = new Guest();

        [ForeignKey("AllergyId")]
        public Allergy Allergy { get; set; } = new Allergy();


    }
}
