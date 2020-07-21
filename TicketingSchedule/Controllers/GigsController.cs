using Microsoft.AspNet.Identity;
using System;
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
            var artistId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);
            var genre = _context.Genre.Single(g => g.Id == gigFormViewModel.Genre);

            var gig = new Gig
            {
                Artis = artist,
                DateTime = DateTime.Parse($"{gigFormViewModel.Date} {gigFormViewModel.Time}"),
                Venue = gigFormViewModel.Venue,
                Genre = genre
            };

            _context.Gig.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}