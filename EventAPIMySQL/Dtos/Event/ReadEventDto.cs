using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Event
{
    public class ReadEventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public ICollection<ReadGuestEventDto> Guests { get; set; } = new List<ReadGuestEventDto>();
    }

    public static class ReadEventDtoExtensions
    {
        public static ReadEventDto ToReadEventDto(this Models.Event eventModel)
        {
            return new ReadEventDto()
            {
                EventId = eventModel.EventId,
                EventName = eventModel.EventName,
                EventDate = eventModel.EventDate,
                Guests = eventModel.Guests.Select(a => a.ToReadGuestEventDto()).ToList()
            };
        }
    }
}
