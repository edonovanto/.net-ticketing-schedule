using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gig
                .Where(a => a.ArtisId == userId && a.DateTime > DateTime.Now)
                .Include(g=>g.Genre)
                .Include(g=>g.Artis)
                .ToList();

            return View(gig);
        }



        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendences
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g=>g.Artis)
                .Include(g=>g.Genre)
                .ToList()
                ;

            var viewModel = new HomeViewModel()
            {
                UpcomingGigs = gigs,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var person = _context.Followings
                .Where(a => a.followerId == userId)
                .Select(a => a.followee)
                .ToList();

            var viewModel = new FollowViewModel()
            {
                Following = person
            };

            return View(viewModel);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel gigFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                gigFormViewModel.Genres = _context.Genre.ToList();
                return View(gigFormViewModel);
            }

            var gig = new Gig
            {
                ArtisId = User.Identity.GetUserId(),
                DateTime = gigFormViewModel.GetDateTime(),
                Venue = gigFormViewModel.Venue,
                GenreId = gigFormViewModel.Genre 
            };

            _context.Gig.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}