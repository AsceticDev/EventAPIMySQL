using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventAPIMySQL.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string EventName { get; set; } = string.Empty;

        public DateTime EventDate { get; set; } = DateTime.MinValue;

        public List<Guest> Guests { get; set; } = new List<Guest>();
    }
}
