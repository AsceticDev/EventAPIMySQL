using EventAPIMySQL.Models;
using System.ComponentModel.DataAnnotations;

namespace EventAPIMySQL.Dtos
{
    public class CreateEventDto
    {
        [Required]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; } = DateTime.Now;
    }
}
