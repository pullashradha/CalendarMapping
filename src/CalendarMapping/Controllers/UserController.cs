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
    public class UserController : Controller
    {
        private readonly DBContext _db;
        private readonly SignInManager<User> _signInManager;

        public UserController(SignInManager<User> signInManager, DBContext db)
        {
            _signInManager = signInManager;
            _db = db;
        }

        [Authorize(Roles = "SiteBoss, AccountHolder")]
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var currentUser = _db.Users.SingleOrDefault(u => u.UserName == username);

            string fullName = currentUser.FirstName + " " + currentUser.LastName;
            string userId = currentUser.Id;

            ViewData.Add("FullName", fullName);
            ViewData.Add("Id", userId);

            return View();
        }

        [Authorize(Roles = "SiteBoss")]
        public IActionResult List()
        {
            var usersList = _db.Users.ToList();
            return View(usersList);
        }

        //Delete Current User
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            await _signInManager.SignOutAsync();

            var currentUser = _db.Users.FirstOrDefault(u => u.Id == userId);
            _db.Users.Remove(currentUser);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
