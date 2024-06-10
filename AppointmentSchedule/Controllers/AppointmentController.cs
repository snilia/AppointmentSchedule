using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;
using AppointmentSchedule.ViewModels;

namespace AppointmentSchedule.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: Appointment
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Client).Include(a => a.Worker);
            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult Create(int? workerId, int? clientId)
        {
            // All clients sorted by FirstName and LastName
            var clients = db.Clients
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();

            if (clientId.HasValue && clients.Any(c => c.ID == clientId.Value))
            {
                ViewBag.ClientID = new SelectList(clients, "ID", "FullName", clientId);
            }
            else
            {
                ViewBag.ClientID = new SelectList(clients, "ID", "FullName");
            }


            // Active workers only, sorted by FirstName and LastName
            var activeWorkers = db.Workers
                .Where(w => w.IsActive)
                .OrderBy(w => w.FirstName)
                .ThenBy(w => w.LastName)
                .ToList();

            if (workerId.HasValue && activeWorkers.Any(w => w.ID == workerId.Value))
            {
                ViewBag.WorkerID = new SelectList(activeWorkers, "ID", "FullName", workerId);
            }
            else
            {
                ViewBag.WorkerID = new SelectList(activeWorkers, "ID", "FullName");
            }

            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult Create([Bind(Include = "ID,WorkerID,ClientID,Status,AppointmentDateTime,LengthInHours,TextBox")] Appointment appointment)
        {
            if (ModelState.IsValid && db.Workers.Any(w => w.ID == appointment.WorkerID && w.IsActive))
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = appointment.ID });
            }

            ViewBag.ClientID = new SelectList(db.Clients.OrderBy(c => c.FirstName).ThenBy(c => c.LastName), "ID", "FullName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers.Where(w => w.IsActive).OrderBy(w => w.FirstName).ThenBy(w => w.LastName), "ID", "FullName", appointment.WorkerID);

            return View(appointment);
        }

        // GET: Appointment/Edit/5
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients.OrderBy(c => c.FirstName).ThenBy(c => c.LastName), "ID", "FullName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers.Where(w => w.IsActive).OrderBy(w => w.FirstName).ThenBy(w => w.LastName), "ID", "FullName", appointment.WorkerID);

            return View(appointment);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult Edit([Bind(Include = "ID,WorkerID,ClientID,Status,AppointmentDateTime,LengthInHours,TextBox")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = appointment.ID });
            }
            ViewBag.ClientID = new SelectList(db.Clients.OrderBy(c => c.FirstName).ThenBy(c => c.LastName), "ID", "FullName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers.Where(w => w.IsActive).OrderBy(w => w.FirstName).ThenBy(w => w.LastName), "ID", "FullName", appointment.WorkerID);

            return View(appointment);
        }

        // GET: Appointment/LimitedEdit/5
        [Authorize(Roles = "Admin,AppointmentEnd,AppointmentControl")]
        public ActionResult LimitedEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Appointment appointment = db.Appointments.Include(a => a.Worker).Include(a => a.Client).FirstOrDefault(a => a.ID == id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            LimitedEditVM viewModel = new LimitedEditVM
            {
                ID = appointment.ID,
                Status = appointment.Status,
                TextBox = appointment.TextBox,
                WorkerFullName = appointment.Worker != null ? appointment.Worker.FirstName + " " + appointment.Worker.LastName : "No worker assigned",
                ClientFullName = appointment.Client != null ? appointment.Client.FirstName + " " + appointment.Client.LastName : "No client assigned"
            };

            return View(viewModel);
        }

        // POST: Appointment/LimitedEdit/5
        [Authorize(Roles = "Admin,AppointmentEnd,AppointmentControl")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LimitedEdit(LimitedEditVM viewModel)
        {
            if (ModelState.IsValid)
            {
                Appointment appointment = db.Appointments.Find(viewModel.ID);
                if (appointment == null)
                {
                    return HttpNotFound();
                }

                appointment.Status = viewModel.Status;
                appointment.TextBox = viewModel.TextBox;

                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = appointment.ID });
            }

            return View(viewModel);
        }

        // GET: Appointment/Delete/5
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,AppointmentControl")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet] 
        public ActionResult WorkerSchedule(int workerId)
        {
            Worker worker = db.Workers.Find(workerId);
            ViewBag.WorkerId = workerId; 
            ViewBag.WorkerName = worker.FirstName + " " + worker.LastName;
            return View();
        }

        [HttpGet]
        public JsonResult GetWorkerAppointments(int workerId, DateTime start, DateTime end)
        {
            //calculates timezone difference, because Json sirialization doesnt take that into account
            TimeZoneInfo israelTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            int timezoneToAdd = (int)israelTimeZone.GetUtcOffset(DateTime.UtcNow).TotalHours; 

            var appointments = db.Appointments
                .Where(a => a.WorkerID == workerId && a.AppointmentDateTime >= start && a.AppointmentDateTime <= end)
                .Select(a => new {
                    id = a.ID,
                    title = a.Client.FirstName + " " + a.Client.LastName,
                    start = DbFunctions.AddHours(a.AppointmentDateTime, timezoneToAdd),
                    end = DbFunctions.AddHours(a.AppointmentDateTime, a.LengthInHours + timezoneToAdd) 
                    }).ToList();

            return Json(appointments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ClientAppointments(int clientId)
        {
            Client client = db.Clients.Find(clientId);
            if (client == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClientId = clientId;
            ViewBag.ClientName = client.FirstName + " " + client.LastName;
            return View();
        }

        public JsonResult GetClientAppointments(int clientId, DateTime start, DateTime end)
        {
            TimeZoneInfo israelTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            int timezoneToAdd = (int)israelTimeZone.GetUtcOffset(DateTime.UtcNow).TotalHours;

            var appointments = db.Appointments
                .Where(a => a.ClientID == clientId && a.AppointmentDateTime >= start && a.AppointmentDateTime <= end)
                .Select(a => new {
                    id = a.ID,
                    title = a.Worker.FirstName + " " + a.Worker.LastName,
                    start = DbFunctions.AddHours(a.AppointmentDateTime, timezoneToAdd),
                    end = DbFunctions.AddHours(a.AppointmentDateTime, a.LengthInHours + timezoneToAdd)
                }).ToList();

            return Json(appointments, JsonRequestBehavior.AllowGet);
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
