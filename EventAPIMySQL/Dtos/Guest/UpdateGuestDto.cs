using EventAPIMySQL.Dtos.Allergy;

namespace EventAPIMySQL.Dtos.Guest
{
    public class UpdateGuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }

    public static class UpdateGuestDtoExtensions
    {
        public static Models.Guest ToGuestModel(this UpdateGuestDto guest)
        {
            return new Models.Guest
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }

        public static UpdateGuestDto ToUpdateGuestDto(this Models.Guest guest)
        {
            return new UpdateGuestDto
            {
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                DateOfBirth = guest.DateOfBirth,
            };
        }
    }
}
