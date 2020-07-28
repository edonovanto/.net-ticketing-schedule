using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingSchedule.Models
{
    public class Following
    {
        public ApplicationUser followee { get; set; }
        public ApplicationUser follower { get; set; }

        [Key]
        [Column(Order = 1)]
        public string followeeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string followerId { get; set; }
    }
}