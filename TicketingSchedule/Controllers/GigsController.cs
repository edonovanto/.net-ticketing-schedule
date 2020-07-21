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

        public ActionResult Create()
        {

            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genre.ToList()
            };

            return View(viewModel);
        }
    }
}