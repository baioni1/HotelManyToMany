using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManyToManyMVC.Models;

namespace HotelManyToManyMVC.Controllers
{
    public class GuestsController : Controller
    {
        private HotelManyToManyMVCContext db = new HotelManyToManyMVCContext();

        // GET: Guests
        public ActionResult Index()
        {
            return View(db.Guests.ToList());
        }

        // GET: Guests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guests guests = db.Guests.Find(id);
            if (guests == null)
            {
                return HttpNotFound();
            }
            return View(guests);
        }

        // GET: Guests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestID,FirstName,LastName,Occupancy")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guests);
        }

        // GET: Guests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guests guests = db.Guests.Find(id);
            if (guests == null)
            {
                return HttpNotFound();
            }
            return View(guests);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestID,FirstName,LastName,Occupancy")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guests);
        }

        // GET: Guests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guests guests = db.Guests.Find(id);
            if (guests == null)
            {
                return HttpNotFound();
            }
            return View(guests);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guests guests = db.Guests.Find(id);
            db.Guests.Remove(guests);
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
