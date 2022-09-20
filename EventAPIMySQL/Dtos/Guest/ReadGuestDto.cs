using EventAPIMySQL.Dtos.Allergy;
using EventAPIMySQL.Dtos.Event;

namespace EventAPIMySQL.Dtos.Guest
{
    public class ReadGuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        //optional, can have many
        public List<ReadAllergyDto> Allergies { get; set; }

        //wouldnt add events when creating a character
        public List<ReadEventDto> Events { get; set; }

    }
}
