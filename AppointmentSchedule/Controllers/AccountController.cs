using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;
using AppointmentSchedule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppointmentSchedule.Controllers
{
    public class AccountController : Controller
    {
        private AppSchContext db = new AppSchContext();


        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // Post: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            //find user by name
            var user = db.Users.FirstOrDefault(u => u.Username.ToLower() == model.Username.ToLower());
            
            //if username and passowrd are correct, and the user is active, log in (make a cookie)
            if (user != null && !string.IsNullOrEmpty(model.Password) && BCrypt.Net.BCrypt.Verify(model.Password, user.Password) && user.IsActive) 
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);  //creates cookie
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        // GET: Account/ChangePassword
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                // Get the current user
                var username = User.Identity.Name;
                var user = db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

                if (user != null && BCrypt.Net.BCrypt.Verify(model.CurrentPassword, user.Password))
                {
                    // Current password is correct
                    user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
                    db.SaveChanges();

                    TempData["Message"] = "Password changed successfully.";
                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect.");
                }
            }
            return View(model);
        }

        // GET: Account/Profile
        [Authorize]
        public ActionResult Profile()
        {
            var user = db.Users.FirstOrDefault(u => u.Username == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.Username = user.Username;
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}