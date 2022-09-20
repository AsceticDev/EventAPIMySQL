using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        //optional, can have many
        public List<Allergy> Allergies { get; set; } = new List<Allergy>();

        //wouldnt add events when creating a character
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
