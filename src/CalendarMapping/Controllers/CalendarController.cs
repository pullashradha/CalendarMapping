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
using Google;

namespace CalendarMapping.Controllers
{
    public class CalendarController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<User> _userManager;

        public CalendarController(UserManager<User> userManager, DBContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //-----------------------------------------------------------------------------------------------------//

        [Authorize(Roles = "SiteBoss, AccountHolder")]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            var calendarsList = _db.Calendars.Where(c => c.User.Id == currentUser.Id);

            return View(calendarsList);
        }

        //Create New Calendar
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> CreateCalendar(string newName, string newPrivacyStatus)
        {
            Calendar newCalendar = new Calendar();
            newCalendar.Name = newName;
            if (newPrivacyStatus == "true")
            {
                newCalendar.PrivacyStatus = true;
            }
            else
            {
                newCalendar.PrivacyStatus = false;
            }
            

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newCalendar.User = currentUser;

            _db.Calendars.Add(newCalendar);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Calendar Details
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        public IActionResult Detail(int calendarId)
        {
            var currentCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            var eventsList = _db.Events.Where(e => e.Calendar == currentCalendar);

            return View(currentCalendar);
        }

        //Edit A Calendar
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public IActionResult EditCalendar(string calendarName, string calendarPrivacyStatus, int calendarId)
        {
            var editedCalendar = _db.Calendars.Where(c => c.Id == calendarId).FirstOrDefault();
            editedCalendar.Name = calendarName;
            if (calendarPrivacyStatus == "true")
            {
                editedCalendar.PrivacyStatus = true;
            }
            else
            {
                editedCalendar.PrivacyStatus = false;
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete A Calendar
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public IActionResult DeleteCalendar(int calendarId)
        {
            var selectedCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            _db.Calendars.Remove(selectedCalendar);

            //Need to delete all events in calendar as well
            var eventsList = _db.Events.Where(e => e.Calendar == selectedCalendar);
            foreach (var individualEvent in eventsList)
            {
                _db.Events.Remove(individualEvent);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-----------------------------------------------------------------------------------------------------//

        //Create New Event
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(string newDescription, DateTime newStartingDateTime, DateTime newEndingDateTime, string newAddress, int calendarId)
        {
            Event newEvent = new Event(newDescription, newStartingDateTime, newEndingDateTime, newAddress);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            newEvent.User = currentUser;

            var currentCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            newEvent.Calendar = currentCalendar;

            _db.Events.Add(newEvent);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //List All Calendar Events
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpGet]
        public IActionResult EventsList(int calendarId)
        {
            var currentCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            var eventsList = _db.Events.Where(e => e.Calendar == currentCalendar).OrderBy(e => e.StartingDateTime).ToList();

            return View(eventsList);
        }

        //Create All Calendar Events Map
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public IActionResult CalendarEventsMap(int calendarId)
        {
            var eventsList = _db.Events.Where(e => e.Calendar.Id == calendarId).ToList();
            return Json(eventsList);
        }
    }
}
