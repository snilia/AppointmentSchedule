using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;
using AppointmentSchedule.ViewModels;

namespace AppointmentSchedule.Controllers
{
    public class UserController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            var user = db.Users.Include("UserRoleMaps.Role").FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UserDetailsVM
            {
                ID = user.ID,
                Username = user.Username,
                Password = user.Password,  // Decide if i want to keep password here /////////////
                IsActive = user.IsActive,
                Roles = user.UserRoleMaps.Select(ur => ur.Role.RoleName).ToList()
            };

            return View(viewModel);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IsActive,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
      
        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Include("UserRoleMaps.Role").FirstOrDefault(u => u.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            //list of roles the user currently has
            var userRoles = user.UserRoleMaps.Select(ur => ur.Role.RoleName).ToList();


            var allRoles = db.Roles.ToList().Select(role => new SelectListItem
            {
                Value = role.RoleName,
                Text = role.RoleName,
                Selected = userRoles.Contains(role.RoleName)  // Set Selected based on whether the role is one of the user's current roles////////
            }).ToList();

            var viewModel = new UserEditVM
            {
                ID = user.ID,
                Username = user.Username,
                Password = user.Password, // Password, not sure if to display////////////////////
                IsActive = user.IsActive,
                SelectedRoles = userRoles,
                AvailableRoles = allRoles
            };

            return View(viewModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Include("UserRoleMaps.Role").FirstOrDefault(u => u.ID == viewModel.ID);
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Update user details
                user.Username = viewModel.Username;
                user.Password = viewModel.Password; // Password, not sure if to have it here/////////////
                user.IsActive = viewModel.IsActive;

                // Remove all roles from user
                foreach (var roleMap in user.UserRoleMaps.ToList())
                {
                    db.UserRoleMaps.Remove(roleMap); // Removing UserRoleMap entity completely
                }

                //add selected roles to user
                var newRoles = db.Roles.Where(r => viewModel.SelectedRoles.Contains(r.RoleName)).ToList();
                foreach (var role in newRoles)
                {
                    user.UserRoleMaps.Add(new UserRoleMap { User = user, Role = role });
                }

                db.SaveChanges();
                return RedirectToAction("Details", new { id = user.ID });
            }

            // If failed, redisplay form
            viewModel.AvailableRoles = db.Roles.Select(r => new SelectListItem
            {
                Value = r.RoleName,
                Text = r.RoleName,
                Selected = viewModel.SelectedRoles.Contains(r.RoleName)
            }).ToList();

            return View(viewModel);
        }

        /*  no deleting users
        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
