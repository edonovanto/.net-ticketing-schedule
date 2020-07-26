using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TicketingSchedule.Dtos;
using TicketingSchedule.Models;

namespace TicketingSchedule.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var users = User.Identity.GetUserId();

            if (_context.Followings.Any(m => m.followeeId == users || m.followeeId == dto.FolloweeId))
            {
                return BadRequest("You already follow this person");
            }

            var follow = new Following
            {
                followeeId = dto.FolloweeId,
                followerId = users
            };

            _context.Followings.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
