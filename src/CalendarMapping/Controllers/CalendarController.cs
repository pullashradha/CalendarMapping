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
    public class CalendarController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<User> _userManager;

        public CalendarController(UserManager<User> userManager, DBContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            return View(_db.Calendars.Where(c => c.User.Id == currentUser.Id));
        }

        //Create New Calendar
        [HttpPost]
        public async Task<IActionResult> Create(string newName, string newPrivacyStatus)
        {
            Calendar newCalendar = new Calendar();
            newCalendar.Name = newName;

            if (newPrivacyStatus == "True" || newPrivacyStatus == "true")
            {
                newCalendar.PrivacyStatus = true;
            }
            else if (newPrivacyStatus == "False" || newPrivacyStatus == "false")
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

        //Edit A Calendar
        [HttpPost]
        public IActionResult Edit(string calendarName, string calendarPrivacyStatus, int calendarId)
        {
            var editedCalendar = _db.Calendars.Where(c => c.Id == calendarId).FirstOrDefault();
            editedCalendar.Name = calendarName;
            if (calendarPrivacyStatus == "True" || calendarPrivacyStatus == "true")
            {
                editedCalendar.PrivacyStatus = true;
            }
            else if (calendarPrivacyStatus == "False" || calendarPrivacyStatus == "false")
            {
                editedCalendar.PrivacyStatus = false;
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete A Calendar
        [HttpPost]
        public IActionResult Delete(int calendarId)
        {
            var selectedCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            _db.Calendars.Remove(selectedCalendar);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
