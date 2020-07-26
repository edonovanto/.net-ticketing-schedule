using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TicketingSchedule.Dtos;
using TicketingSchedule.Models;

namespace TicketingSchedule.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exist");
            }

            var attendance = new Attendence
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendences.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
