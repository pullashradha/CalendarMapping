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

namespace CalendarMapping.Controllers
{
    public class EventController : Controller
    {
        private readonly DBContext _db;

        public EventController(DBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var eventsList = _db.Events.ToList();

            return View(eventsList);
        }

        //Create a New Event
        [HttpPost]
        public IActionResult Create(string newDescription, DateTime newDate, string newAddress)
        {
            Event newEvent = new Event(newDescription, newDate, newAddress);
            _db.Events.Add(newEvent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
