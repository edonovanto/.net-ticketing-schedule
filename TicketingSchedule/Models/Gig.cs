using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TicketingSchedule.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artis { get; set; }

        [DisplayName("Date / Time")]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)] 
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }

    public class GigDbContext : DbContext
    {
        public DbSet<Gig> Gig { get; set; }
    }
}