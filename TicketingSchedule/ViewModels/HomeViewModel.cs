using System.Collections.Generic;
using TicketingSchedule.Models;

namespace TicketingSchedule.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowAction { get; set; }
    }
}