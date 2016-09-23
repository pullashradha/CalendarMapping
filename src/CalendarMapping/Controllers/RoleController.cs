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
    public class RoleController : Controller
    {
        private readonly DBContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController (RoleManager<IdentityRole> roleManager, UserManager<User> userManager, DBContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        [Authorize(Roles = "SiteBoss")]
        public IActionResult Index()
        {
            var rolesList = _db.Roles.ToList();

            var userRolesList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = userRolesList;

            return View(rolesList);
        }

        //Create New Role
        [Authorize(Roles = "SiteBoss")]
        [HttpPost]
        public async Task<IActionResult> Create(string newName)
        {
            var newRole = new IdentityRole();
            newRole.Name = newName;
            IdentityResult result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Add User to Role
        [Authorize(Roles = "SiteBoss")]
        [HttpPost]
        public async Task<IActionResult> AddUser(string username, string roleName)
        {
            User user = _db.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var rolesList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = rolesList;
                return View();
            }
        }


        
        //public IActionResult UsersRoles()
        //{
        //    var combinedList = _db.UserRoles.ToList();
        //    return View(combinedList);
        //}
        //public IActionResult AddUser()
        //{
        //    var rolesList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
        //    ViewBag.Roles = rolesList;
        //    return View();
        //}
    }
}
