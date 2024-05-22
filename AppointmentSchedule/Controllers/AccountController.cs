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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}