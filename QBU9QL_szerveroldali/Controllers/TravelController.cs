using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Controllers
{
    public class TravelController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<TravelController> _logger;
        private readonly ApplicationDbContext _context;

        public TravelController(UserManager<SiteUser> userManager, ILogger<TravelController> logger, ApplicationDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Travels);
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Travel travel)
        {
            travel.OwnerId = _userManager.GetUserId(this.User);

            var old = _context.Travels.FirstOrDefault(t => t.Destination == travel.Destination && t.OwnerId == travel.OwnerId);
            if (old == null)
            {
                _context.Travels.Add(travel);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string uid)
        {
            var item = _context.Travels.FirstOrDefault(t => t.Id == uid);
            if (item != null && item.OwnerId == _userManager.GetUserId(this.User))
            {
                _context.Travels.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
