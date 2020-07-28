using System.Collections.Generic;
using TicketingSchedule.Models;

namespace TicketingSchedule.ViewModels
{
    public class FollowViewModel
    {
        public IEnumerable<ApplicationUser> Following { get; set; }
    }
}