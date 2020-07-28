using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketingSchedule.Models
{
    public class Gig
    {
        public int Id { get; set; }

        
        public ApplicationUser Artis { get; set; }
        [Required]
        public string ArtisId { get; set; }

        [DisplayName("Date / Time")]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)] 
        public string Venue { get; set; }

        
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}