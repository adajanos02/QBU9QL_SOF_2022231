﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QBU9QL_szerveroldali.Data;
using QBU9QL_szerveroldali.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using QBU9QL_szerveroldali.Logic;

namespace QBU9QL_szerveroldali.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _ctx;
        private readonly IContactLogic _logic;

        // Existing constructor

        public HomeController(IContactLogic logic, ILogger<HomeController> logger, UserManager<SiteUser> userManager, ApplicationDbContext ctx)
        {
            _logic = logic;
            _logger = logger;
            _userManager = userManager;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var contacts = _logic.GetContacts(userId);
            return View(contacts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            var ownerId = _userManager.GetUserId(this.User).ToString();
            _logic.AddContact(contact, ownerId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string uid)
        {
            var ownerId = _userManager.GetUserId(this.User);
            _logic.DeleteContact(uid, ownerId);

            return RedirectToAction(nameof(Index));
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
        
       
       






        
    }
}