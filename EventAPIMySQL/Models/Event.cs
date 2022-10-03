using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    [Index(nameof(EventName), IsUnique=true)]
    public class Event
    {
        public int EventId { get; set; }

        [StringLength(30, MinimumLength=4, ErrorMessage = "Must be between 4 and 30 characters.")]
        public string EventName { get; set; } = string.Empty;

        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]
        public DateTime EventDate { get; set; } = DateTime.MinValue;

        public ICollection<Guest> Guests { get; set; } = new List<Guest>();
    }
}
