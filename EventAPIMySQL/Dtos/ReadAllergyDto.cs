using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dtos
{
    public class ReadAllergyDto
    {
        public string AllergyType { get; set; } 

        public List<Guest> Guests { get; set; } 

    }
}
