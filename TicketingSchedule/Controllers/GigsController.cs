using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using TicketingSchedule.Models;
using TicketingSchedule.ViewModels;

namespace TicketingSchedule.Controllers
{
    public class GigsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {

            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genre.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel gigFormViewModel)
        {
            var gig = new Gig
            {
                ArtisId = User.Identity.GetUserId(),
                DateTime = gigFormViewModel.DateTime,
                Venue = gigFormViewModel.Venue,
                GenreId = gigFormViewModel.Genre 
            };

            _context.Gig.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}