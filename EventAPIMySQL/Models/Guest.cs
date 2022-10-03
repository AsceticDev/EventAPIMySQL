using EventAPIMySQL.Dtos.Allergy;
using EventAPIMySQL.Dtos.Guest;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Models
{
    [Index(nameof(Email), IsUnique=true)]
    public class Guest
    {
        public int GuestId { get; set; }

        [StringLength(20, MinimumLength=2, ErrorMessage = "Must be between 2 and 20 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(20, MinimumLength=2, ErrorMessage = "Must be between 2 and 20 characters.")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        //optional, can have many
        public ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();

        //wouldnt add events when creating a character
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
