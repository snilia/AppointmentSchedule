using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;
using AppointmentSchedule.ViewModels;

namespace AppointmentSchedule.Controllers
{
    [Authorize(Roles = "Admin,UserControl")]
    public class UserController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: User
        public ActionResult Index(bool showInactive = false)
        {
            //list all users except for admin, also decide if to show active or inactive users
            var users = db.Users.Where(u => u.Username != "Admin" && u.IsActive != showInactive).ToList();
            ViewBag.ShowInactive = showInactive;
            return View(users);
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
                Password = user.Password,
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IsActive,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); // hash password
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
                Selected = userRoles.Contains(role.RoleName)  //Set Selected based on whether the role is one of the user's current roles
            }).ToList();

            var viewModel = new UserEditVM
            {
                ID = user.ID,
                Username = user.Username,
                Password = null,
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
                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(viewModel.Password); //hash password
                }
                user.IsActive = viewModel.IsActive;

                // Remove all roles from user
                foreach (var roleMap in user.UserRoleMaps.ToList())
                {
                    db.UserRoleMaps.Remove(roleMap);
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
