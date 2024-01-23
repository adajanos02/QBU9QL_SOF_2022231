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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<TravelController> _logger;
        private readonly ITravelLogic _travelLogic;

        public TravelController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<TravelController> logger, ITravelLogic travelLogic)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _travelLogic = travelLogic;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.RemoveFromRoleAsync(user, "Admin");


            
            return RedirectToAction(nameof(Users));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(ListTravel));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            var ownerId = _userManager.GetUserId(User);
            var travels = _travelLogic.GetTravels(ownerId);
            return View(travels);
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
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDeleteTravel(string uid)
        {
            var ownerId = _userManager.GetUserId(this.User);
            _travelLogic.AdminDeleteTravel(uid, ownerId);

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
