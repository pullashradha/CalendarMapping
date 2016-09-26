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
    public class HomeController : Controller
    {
        private readonly DBContext _db;
        public HomeController(DBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
