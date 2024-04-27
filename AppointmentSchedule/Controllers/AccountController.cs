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
           // using (AppSchContext db = new AppSchContext())
           // {
                bool IsValidUser = db.Users.Any(user => user.Username.ToLower() ==
                     model.Username.ToLower() && user.Password == model.Password);
                if (IsValidUser) //if username and password correct, make an authcookie
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);  //passes username to the cookie... unsafe?! gp uses it too, so probably fine///////////////////
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
           // }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}