using EventAPIMySQL.Dtos.Allergy;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    public class Allergy
    {
        public int Id { get; set; }
        public string AllergyType { get; set; } = string.Empty;

        public List<Guest> Guests { get; set; } = new List<Guest>();
    }

}
