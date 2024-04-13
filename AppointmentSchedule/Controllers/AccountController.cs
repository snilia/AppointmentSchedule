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
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            using (AppSchContext db = new AppSchContext())
            {
                bool IsValidUser = db.Users.Any(user => user.Username.ToLower() ==
                     model.Username.ToLower() && user.Password == model.Password);
                if (IsValidUser) //if username and password correct, make an authcookie
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);  //passes username to the cookie... unsafe?!///////////////////
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        /*
        [Authorize]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Signup(User model)
        {
            using (AppSchContext db = new AppSchContext())
            {
                db.Users.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        */
    }
}