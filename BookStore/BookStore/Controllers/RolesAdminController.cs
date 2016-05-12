﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookStore.Models;
using System.Threading;
using System.Globalization;
namespace BookStore.Controllers
{
    
    public class RolesAdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: RolesAdmin
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        // GET: RolesAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.ResultMesage = "Role created successfully! ";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesAdmin/Edit/5
        public ActionResult Edit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }

        // POST: RolesAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesAdmin/Delete/5
        public ActionResult Delete(string RoleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("RolesAdmin/Index");
        }

        // POST: RolesAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ManageUserRoles()
        {
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();


            //var account = new AccountController();
            UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = _userManager.AddToRole(user.Id, RoleName);

            //account.UserManager.AddToRole(user.Id, RoleName);
            ViewBag.ResultMessage = "Role created successfully !";
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
            return View("ManageUserRoles");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if(!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                //var account = new AccountController();
                UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var idResult = _userManager.GetRoles(user.Id);
                ViewBag.RolesForThisUser = idResult;
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }
            return ViewBag("ManageUserRoles");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult WebUserList(string UserName)
        //{
        //    //var list = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
        //    //ViewBag.WebUsers = list;
        //    var UserList = context.Users.OrderBy(r => r.UserName).ToList();
        //    ViewBag.WebUsers = UserList;
        //    return ViewBag("ManageUserRoles");

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            //var account = new AccountController();
            UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCulture)).FirstOrDefault();
            if ( _userManager.IsInRole(user.Id, RoleName))
            {
                _userManager.RemoveFromRole(user.Id, RoleName);
                TempData["ResultMessage"] = "Role removed"; ;
            }
            else
            {
                TempData["ResultMessage"] = "This user doesnt belong to selected role.";
            }
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;
             var UserList = context.Users.OrderBy(r => r.UserName).ToList();
             ViewBag.WebUsers = UserList;
            return View("ManageUserRoles");
        }
    }
}