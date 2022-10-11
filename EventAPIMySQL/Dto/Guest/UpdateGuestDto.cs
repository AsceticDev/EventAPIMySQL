using EventAPIMySQL.Models;

namespace EventAPIMySQL.Dto.Guest
{
    public class UpdateGuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
