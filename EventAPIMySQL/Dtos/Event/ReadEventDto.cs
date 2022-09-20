using EventAPIMySQL.Dtos.Guest;

namespace EventAPIMySQL.Dtos.Event
{
    public class ReadEventDto
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }
    }
}
