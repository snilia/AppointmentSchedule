﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;

namespace AppointmentSchedule.Controllers
{
    public class AppointmentController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: Appointment
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
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "LastName");
            return View();
        }
        /*
        public ActionResult Create(int? workerId, DateTime? start, DateTime? end)
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName");
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "LastName");
            // Create a new appointment model and pre-populate dates if provided
            var appointment = new Appointment();
            if (start.HasValue)
            {
                appointment.AppointmentDateTime = start.Value;
            }
            if (end.HasValue)
            {
                // Optionally handle the end time if your model supports it
                // For instance, you might calculate the duration based on the end time
            }
            return View(appointment);
        }
        */
        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WorkerID,ClientID,Status,AppointmentDateTime,LengthInHours,TextBox")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "LastName", appointment.WorkerID);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
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
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "LastName", appointment.WorkerID);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WorkerID,ClientID,Status,AppointmentDateTime,LengthInHours,TextBox")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "LastName", appointment.ClientID);
            ViewBag.WorkerID = new SelectList(db.Workers, "ID", "LastName", appointment.WorkerID);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
