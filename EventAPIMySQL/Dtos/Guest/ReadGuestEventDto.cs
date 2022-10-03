namespace EventAPIMySQL.Dtos.Guest
{
    public class ReadGuestEventDto
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    }
    public static class ReadGuestEventDtoExtensions
    {
        public static ReadGuestEventDto ToReadGuestEventDto(this Models.Guest guest)
        {
            return new ReadGuestEventDto()
            {
                GuestId = guest.GuestId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }

        public static Models.Guest ToGuestModel(this ReadGuestEventDto guest)
        {
            return new Models.Guest ()
            {
                GuestId = guest.GuestId,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }
    }

}
