using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSchedule.Models
{
    public class Attendence
    {
        public Gig Gig { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Column(Order =1)]
        public int GigId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}