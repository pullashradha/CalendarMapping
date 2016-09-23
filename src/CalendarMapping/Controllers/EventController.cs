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
        /*
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<ApplicationEvent> _eventManager;

        public EventController(RoleManager<ApplicationEvent> eventManager, ApplicationDbContext db)
        {
            _eventManager = eventManager;
            _db = db;
        }
        public IActionResult Index()
        {
            var eventsList = _db.Events.ToList();
            return View(eventsList);
        }

        //Create Event

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel model)
        {
            var newEvent = new ApplicationEvent ();
            newEvent.Description = model.Description;
            newEvent.Date = model.Date;
            newEvent.Address = model.Address;
            IdentityResult createdEvent = await _eventManager.CreateAsync(newEvent);
            if (createdEvent.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }*/
    }
}
