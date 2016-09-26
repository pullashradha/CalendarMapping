using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using CalendarMapping.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CalendarMapping.Controllers
{
    public class EventController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<User> _userManager;

        public EventController(UserManager<User> userManager, DBContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //Empty constructor for EventControllerTest BUT needs to be commented out when running program otherwise Event/Index is a blank page
        //public EventController() { }

        [Authorize(Roles = "SiteBoss, AccountHolder")]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            return View(_db.Events.Where(x => x.User.Id == currentUser.Id));
        }

        //Create New Event
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> Create(string newDescription, DateTime newDate, DateTime newStartTime, DateTime newEndTime, string newAddress)
        {
            Event newEvent = new Event(newDescription, newStartTime, newEndTime, newAddress, newDate);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newEvent.User = currentUser;
            _db.Events.Add(newEvent);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete An Event
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public IActionResult Delete(int eventId)
        {
            var selectedEvent = _db.Events.FirstOrDefault(e => e.Id == eventId);
            _db.Events.Remove(selectedEvent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
