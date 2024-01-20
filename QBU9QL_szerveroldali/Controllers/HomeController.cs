using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace QBU9QL_szerveroldali.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _ctx;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext ctx)
        {
            _logger = logger;
            _userManager = userManager;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var contacts = _ctx.Contacts.Where(c => c.OwnerId == userId).ToList();
            return View(contacts);
        }
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            contact.OwnerId = _userManager.GetUserId(this.User).ToString();

            var old = _ctx.Contacts.FirstOrDefault(t => t.Name == contact.Name && t.Id == contact.Id);
            if (old == null)
            {
                _ctx.Contacts.Add(contact);
                _ctx.SaveChanges();
            }




            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(string uid)
        {
            var item = _ctx.Contacts.FirstOrDefault(t => t.Id == uid);
            if (item != null && item.PhoneNumber == _userManager.GetUserId(this.User))
            {
                _ctx.Contacts.Remove(item);
                _ctx.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}