using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CalendarMapping.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DBContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        //-----------------------------------------------------------------------------------------------------//

        //Register New Account
        [HttpPost]
        public async Task<IActionResult> Register(string newFirstName, string newLastName, string newEmail, string newPhoneNumber, string newUsername, string newPassword, string confirmPassword)
        {
            if (!(_db.Users.Any(u => u.UserName == newUsername)) && !(_db.Users.Any(u => u.Email == newEmail)))
            {
                if (newPassword == confirmPassword)
                {
                    var newUser = new User { FirstName = newFirstName, LastName = newLastName, Email = newEmail, PhoneNumber = newPhoneNumber, UserName = newUsername };
                    IdentityResult registeredUser = await _userManager.CreateAsync(newUser, newPassword);
                    IdentityResult userAddedToRole = await _userManager.AddToRoleAsync(newUser, "AccountHolder");
                    //Create new private calendar
                    var calendarName = newUser.FirstName + "'s Calendar";
                    Calendar firstCalendar = new Calendar();
                    firstCalendar.Name = calendarName;
                    firstCalendar.PrivacyStatus = true;
                    firstCalendar.User = newUser;
                    _db.Calendars.Add(firstCalendar);
                    _db.SaveChanges();
                    if (registeredUser.Succeeded && userAddedToRole.Succeeded)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(newUsername, newPassword, isPersistent: true, lockoutOnFailure: false);
                        string message = "succeeded";
                        return Json(message);
                    }
                    else
                    {
                        string message = "failed";
                        return Json(message);
                    }
                }
                else
                {
                    string message = "failed";
                    return Json(message);
                }
            }
            else
            {
                string message = "failed";
                return Json(message);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        //Log In User
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
