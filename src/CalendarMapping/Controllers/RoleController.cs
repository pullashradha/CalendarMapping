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
        public IActionResult Index()
        {
            var rolesList = _db.Roles.ToList();
            return View(rolesList);
        }

        //Create Role
        [Authorize(Roles = "UltimateAdmin, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "UltimateAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            var newRole = new IdentityRole();
            newRole.Name = model.Name;
            IdentityResult createdRole = await _roleManager.CreateAsync(newRole);
            if (createdRole.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Add Role to User
        public IActionResult AddUser()
        {
            var rolesList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolesList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string UserName, string roleName)
        {
            User selectedUser = _db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            IdentityResult result = await _userManager.AddToRoleAsync(selectedUser, roleName);
            if (result.Succeeded)
            {
                return RedirectToAction("UsersRoles");
            }
            else
            {
                var rolesList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = rolesList;
                return View();
            }
        }
        /*
        public IActionResult UsersRoles()
        {
            var combinedList = _db.UserRoles.ToList();
            return View(combinedList);
        }*/
    }
}
