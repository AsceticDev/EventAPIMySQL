using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPIMySQL.Models
{
    public class GuestEvent
    {
        [Key, Column(Order = 1)]
        public int GuestId { get; set; }
        
        [Key, Column(Order = 2)]
        public int EventId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest{ get; set; } = new Guest();

        [ForeignKey("EventId")]
        public Event Event{ get; set; } = new Event();
    }
}
