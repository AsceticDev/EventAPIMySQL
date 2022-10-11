using EventAPIMySQL.Dto.Event;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Models
{
    public class EventGuest
    {
        public int EventId { get; set; }
        public Event Event{ get; set; } 

        public int GuestId { get; set; }
        public Guest Guest{ get; set; }
    }

    public static class EventGuestExtensions
    {
        public static ReadEventDto ToReadEventDto(this EventGuest eventGuest)
        {
            return new ReadEventDto
            {
                Id = eventGuest.EventId,
                EventName = eventGuest.Event.EventName,
                EventDate = eventGuest.Event.EventDate
            };
        }
    }
}
