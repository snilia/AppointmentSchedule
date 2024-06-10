using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.Controllers
{
    [Authorize]
    public class WorkerController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: Worker
        public ActionResult Index(bool showInactive = false)
        {
            var workers = db.Workers.Where(w => w.IsActive != showInactive).ToList();
            ViewBag.ShowInactive = showInactive;
            return View(workers);
        }

        // GET: Worker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Worker/Create
        [Authorize(Roles = "Admin,WorkerControl")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,WorkerControl")]
        public ActionResult Create([Bind(Include = "LastName,FirstName,PhoneNumber,IsActive")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = worker.ID });
            }

            return View(worker);
        }

        // GET: Worker/Edit/5
        [Authorize(Roles = "Admin,WorkerControl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Worker/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,WorkerControl")]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,PhoneNumber,IsActive")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = worker.ID });
            }
            return View(worker);
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
