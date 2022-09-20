using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; } = DateTime.MinValue;

        [JsonIgnore]
        [Required]
        public List<Guest> Guests { get; set; } = new List<Guest>();
    }
}
