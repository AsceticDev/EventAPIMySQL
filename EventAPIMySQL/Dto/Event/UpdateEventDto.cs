namespace EventAPIMySQL.Dto.Event
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
