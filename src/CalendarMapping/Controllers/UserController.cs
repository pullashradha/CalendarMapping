using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using CalendarMapping.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace UsersRoles.Controllers
{
    public class UserController : Controller
    {
        private readonly DBContext _db;

        public UserController(DBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var currentUser = _db.Users.SingleOrDefault(u => u.UserName == username);
            string fullName = currentUser.FirstName + " " + currentUser.LastName;
            ViewData.Add("FullName", fullName);

            return View();
        }
    }
}
