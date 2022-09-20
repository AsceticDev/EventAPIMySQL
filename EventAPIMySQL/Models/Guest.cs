using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        //optional, can have many
        public List<Allergy>? Allergies { get; set; } = new List<Allergy>();
        public List<Event>? Events { get; set; } = new List<Event>();
    }
}
