using EventAPIMySQL.Dtos.Event;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Dtos.Guest
{
    public class CreateGuestEventDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int GuestId { get; set; }
    }

    public static class CreateGuestEventDtoExtensions
    {
        public static Models.Guest ToGuestModel(this CreateGuestEventDto guest)
        {
            return new Models.Guest
            {
                GuestId = guest.GuestId
            };
        }
    }

}
