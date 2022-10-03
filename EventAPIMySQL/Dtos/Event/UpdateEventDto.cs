using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Event
{
    public class UpdateEventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public ICollection<ReadGuestEventDto> Guests { get; set; } = new List<ReadGuestEventDto>();

    }
    public static class UpdateEventDtoExtensions
    {
        public static Models.Event ToEventModel (this UpdateEventDto eventDto)
        {
            return new Models.Event()
            {
                EventId = eventDto.EventId,
                EventName = eventDto.EventName,
                EventDate = eventDto.EventDate,
                Guests = eventDto.Guests.Select(a => a.ToGuestModel()).ToList()
            };
        }
    }

}
