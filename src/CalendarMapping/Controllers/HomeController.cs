using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CalendarMapping.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _db;
        public HomeController(DBContext db)
        {
            _db = db;
        }

        //-----------------------------------------------------------------------------------------------------//

        public IActionResult Index()
        {
            var publicCalendarsList = _db.Calendars.Where(c => c.PrivacyStatus == false).ToList();
            var finalCalendarsList = new Dictionary<Calendar, string>() { };

            foreach (var calendar in publicCalendarsList)
            {
                var foundCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendar.Id);
                var foundEventsList = _db.Events.Where(e => e.Calendar == foundCalendar).ToList();

                if (foundEventsList.Count > 0)
                {
                    var calendarUser = foundCalendar.User.UserName;
                    finalCalendarsList.Add(foundCalendar, calendarUser);
                }
            }

            return View(finalCalendarsList);
        }

        //List All Calendar Events
        [HttpGet]
        public IActionResult EventsList(int calendarId)
        {
            var currentCalendar = _db.Calendars.FirstOrDefault(c => c.Id == calendarId);
            var eventsList = _db.Events.Where(e => e.Calendar == currentCalendar).OrderBy(e => e.StartingDateTime).ToList();

            return View(eventsList);
        }
    }
}
