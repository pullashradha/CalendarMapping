using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMapping.Models;
using CalendarMapping.ViewModels;
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

        //Register New Account
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!(_db.Users.Any(u => u.UserName == model.Username)) && !(_db.Users.Any(u => u.Email == model.Email)))
            {
                var newUser = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, PhoneNumber = model.PhoneNumber, UserName = model.Username };
                IdentityResult registeredUser = await _userManager.CreateAsync(newUser, model.Password);
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
                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        //Log In User
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);
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
