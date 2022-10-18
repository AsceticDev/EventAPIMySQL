namespace EventAPIMySQL.Dto.Event
{
    public class ReadEventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

    }

    public static class ReadEventDtoExtensions
    {
        public static ReadEventDto ToReadEventDto(this Models.Event eventObj)
        {
            return new ReadEventDto
            {
                Id = eventObj.Id,
                EventDate = eventObj.EventDate,
                EventName = eventObj.EventName
            };
        }
    }

}
