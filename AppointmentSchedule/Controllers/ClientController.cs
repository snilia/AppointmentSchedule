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
using PagedList;

namespace AppointmentSchedule.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private AppSchContext db = new AppSchContext();

        // GET: Client
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last_name" ? "last_name_desc" : "last_name";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var clients = from c in db.Clients
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.LastName.Contains(searchString)
                                       || c.FirstName.Contains(searchString) || c.PhoneNumber.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(c => c.FirstName);
                    break;
                case "last_name":
                    clients = clients.OrderBy(c => c.LastName);
                    break;
                case "last_name_desc":
                    clients = clients.OrderByDescending(c => c.LastName);
                    break;
                default:
                    clients = clients.OrderBy(c => c.FirstName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(clients.ToPagedList(pageNumber, pageSize));
        }



        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult Create([Bind(Include = "LastName,FirstName,PhoneNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = client.ID });
            }

            return View(client);
        }

        // GET: Client/Edit/5
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,PhoneNumber")] Client client)  
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = client.ID });
            }
            return View(client);
        }

        // GET: Client/Delete/5
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,ClientControl")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
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
