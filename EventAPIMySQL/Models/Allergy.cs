using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    public class Allergy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AllergyType { get; set; } = string.Empty;


        [JsonIgnore]
        public List<Guest>? Guests { get; set; } = new List<Guest>();
    }
}
