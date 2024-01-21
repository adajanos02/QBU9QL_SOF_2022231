using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Logic;
using QBU9QL_szerveroldali.Models;

namespace QBU9QL_szerveroldali.Controllers
{
    [Authorize]
    public class TravelController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<TravelController> _logger;
        private readonly ITravelLogic _travelLogic;

        public TravelController(UserManager<SiteUser> userManager, ILogger<TravelController> logger, ITravelLogic travelLogic)
        {
            _userManager = userManager;
            _logger = logger;
            _travelLogic = travelLogic;
        }

        public IActionResult ListTravel()
        {
            var ownerId = _userManager.GetUserId(User);
            var travels = _travelLogic.GetTravels(ownerId);
            return View(travels);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTravel(Travel travel)
        {
            var ownerId = _userManager.GetUserId(this.User).ToString();
            _travelLogic.AddTravel(travel, ownerId);

            return RedirectToAction(nameof(ListTravel));
        }

        [Authorize]
        public IActionResult DeleteTravel(string uid)
        {
            var ownerId = _userManager.GetUserId(this.User);
            _travelLogic.DeleteTravel(uid, ownerId);

            return RedirectToAction(nameof(ListTravel));
        }

        [Authorize]
        public IActionResult AddTravel()
        {
            return View();
        }

        public async Task<IActionResult> GetImage(string userid)
        {

            var user = _userManager.Users.FirstOrDefault(t => t.Id == userid);
            return new FileContentResult(user.Data, user.ContentType);
        }
    }
}
