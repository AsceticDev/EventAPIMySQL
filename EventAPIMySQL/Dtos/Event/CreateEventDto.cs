using EventAPIMySQL.Models;
using System.ComponentModel.DataAnnotations;

namespace EventAPIMySQL.Dtos.Event
{
    public class CreateEventDto
    {
        public string EventName { get; set; } = string.Empty;

        public DateTime EventDate { get; set; } = DateTime.Now;
    }
}
