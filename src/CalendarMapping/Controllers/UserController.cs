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

            ViewData.Add("FullName", fullName);

            return View();
        }

        [Authorize(Roles = "SiteBoss")]
        public IActionResult List()
        {
            var usersList = _db.Users.ToList();
            return View(usersList);
        }

        //User Profile
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        public IActionResult Profile()
        {
            var username = User.Identity.Name;
            var currentUser = _db.Users.SingleOrDefault(u => u.UserName == username);

            return View(currentUser);
        }

        //Edit User Info
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public IActionResult Edit(string firstName, string lastName, string email, string phoneNumber, string userId)
        {
            var editedUser = _db.Users.Where(u => u.Id == userId).FirstOrDefault();
            editedUser.FirstName = firstName;
            editedUser.LastName = lastName;
            editedUser.Email = email;
            editedUser.NormalizedEmail = email.ToUpper();
            editedUser.PhoneNumber = phoneNumber;
            _db.SaveChanges();

            return RedirectToAction("Profile");
        }

        //Edit Username
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> EditUsername(string username, string userId)
        {
            //Logs out current user before changing username
            await _signInManager.SignOutAsync();

            var editedUser = _db.Users.Where(u => u.Id == userId).FirstOrDefault();
            editedUser.UserName = username;
            editedUser.NormalizedUserName = username.ToUpper();
            _db.SaveChanges();

            return RedirectToAction("Login", "Account");

        }

        //Reset Password
        //[Authorize(Roles = "SiteBoss, AccountHolder")]
        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(string password, string confirmPassword, string userId)
        //{
        //    if (password == confirmPassword)
        //    {
        //        await _signInManager.SignOutAsync();

        //        var editedUser = _db.Users.Where(u => u.Id == userId).FirstOrDefault();
        //        editedUser.PasswordHash = password; //Need to Hash password
        //        _db.SaveChanges();

        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Profile");
        //    }
        //}

        //Delete Current User
        [Authorize(Roles = "SiteBoss, AccountHolder")]
        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            //Logs out current user before deleting account
            await _signInManager.SignOutAsync();

            var currentUser = _db.Users.FirstOrDefault(u => u.Id == userId);
            _db.Users.Remove(currentUser);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //Delete User
        [Authorize(Roles = "SiteBoss")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var currentUser = _db.Users.FirstOrDefault(u => u.Id == userId);
            if (currentUser.Id == "1e24830b-22d4-48f3-aa09-b3311e552e72")
            {
                //Can't allow SiteBoss to delete own account without logging out
                return RedirectToAction("List");
            }
            else
            {
                _db.Users.Remove(currentUser);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
