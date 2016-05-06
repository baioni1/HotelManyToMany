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
    public class BookingcsController : Controller
    {
        private HotelManyToManyMVCContext db = new HotelManyToManyMVCContext();

        // GET: Bookingcs
        public ActionResult Index()
        {
            var bookingcs = db.Bookingcs.Include(b => b.CustomerName).Include(b => b.Suite);
            return View(bookingcs.ToList());
        }

        // GET: Bookingcs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookingcs bookingcs = db.Bookingcs.Find(id);
            if (bookingcs == null)
            {
                return HttpNotFound();
            }
            return View(bookingcs);
        }

        // GET: Bookingcs/Create
        public ActionResult Create()
        {
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "FirstName");
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: Bookingcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,StartDate,EndDate,GuestID,RoomID")] Bookingcs bookingcs)
        {
            if (ModelState.IsValid)
            {
                db.Bookingcs.Add(bookingcs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "FirstName", bookingcs.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomId", "RoomId", bookingcs.RoomID);
            return View(bookingcs);
        }

        // GET: Bookingcs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookingcs bookingcs = db.Bookingcs.Find(id);
            if (bookingcs == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "FirstName", bookingcs.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomId", "RoomId", bookingcs.RoomID);
            return View(bookingcs);
        }

        // POST: Bookingcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,StartDate,EndDate,GuestID,RoomID")] Bookingcs bookingcs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingcs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestID = new SelectList(db.Guests, "GuestID", "FirstName", bookingcs.GuestID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomId", "RoomId", bookingcs.RoomID);
            return View(bookingcs);
        }

        // GET: Bookingcs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookingcs bookingcs = db.Bookingcs.Find(id);
            if (bookingcs == null)
            {
                return HttpNotFound();
            }
            return View(bookingcs);
        }

        // POST: Bookingcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookingcs bookingcs = db.Bookingcs.Find(id);
            db.Bookingcs.Remove(bookingcs);
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
