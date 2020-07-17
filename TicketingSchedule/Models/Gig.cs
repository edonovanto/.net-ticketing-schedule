using System;

namespace TicketingSchedule.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public ApplicationUser Artis { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
    }
}