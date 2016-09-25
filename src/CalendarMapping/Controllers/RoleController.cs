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
using Microsoft.EntityFrameworkCore;

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

        //[Authorize(Roles = "SiteBoss")]
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

        //Edit A Role
        //public IActionResult Edit(string roleId)
        //{
        //    var selectedRole = _db.Roles.FirstOrDefault(r => r.Id == roleId);
        //    return View(selectedRole);
        //}

        //[HttpPost]
        //public IActionResult Edit(IdentityRole role)
        //{
        //    _db.Entry(role).State = EntityState.Modified;
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //Delete A Role
        [Authorize(Roles = "SiteBoss")]
        [HttpPost]
        public IActionResult Delete(string roleId)
        {
            var selectedRole = _db.Roles.FirstOrDefault(r => r.Id == roleId);
            _db.Roles.Remove(selectedRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
