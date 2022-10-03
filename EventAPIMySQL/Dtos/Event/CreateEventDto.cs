using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Event
{
    public class CreateEventDto
    {
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.Now;
        public ICollection<CreateGuestEventDto> Guests { get; set; } = new List<CreateGuestEventDto>();
    }

    public static class CreateEventDtoExtensions
    {
        public static Models.Event ToEventModel(this CreateEventDto eventDto)
        {
            return new Models.Event
            {
                EventName = eventDto.EventName,
                EventDate = eventDto.EventDate,
            };
        }
    }
}
