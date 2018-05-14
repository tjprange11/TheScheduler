using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheScheduler.Models;

namespace TheScheduler.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Consumer).Include(r => r.Facility);
            return View(reservations.ToList());
        }

        // Get : Reservations/Id
        public ActionResult OwnerIndex()
        {
            string currentUser = User.Identity.GetUserId();
            int anOwnerId = db.Owners.Where(data => data.UserId == currentUser).Select(data => data.ID).First();

            int aFacilityId = db.Facilities.Where(data => data.OwnerId == anOwnerId).Select(data => data.ID).First();

            var reservations = db.Reservations.Where(data => data.FacilityId == aFacilityId).Include(f => f.Facility.FacilityAddress);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.ConsumerId = new SelectList(db.Consumers, "ID", "UserId");
            ViewBag.FacilityId = new SelectList(db.Facilities, "ID", "Name");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FacilityId,ConsumerId,Accepted,Start,End,Completed")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsumerId = new SelectList(db.Consumers, "ID", "UserId", reservation.ConsumerId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "ID", "Name", reservation.FacilityId);
            return View(reservation);
        }

        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            reservation.Accepted = true;
            db.SaveChanges();
            var facility = db.Facilities.Where(data => data.ID == reservation.FacilityId).First();
            var owner = db.Owners.Where(data => data.ID == facility.OwnerId).First();
            return RedirectToAction("OwnerIndex", new { OwnerId = owner.ID });
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConsumerId = new SelectList(db.Consumers, "ID", "UserId", reservation.ConsumerId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "ID", "Name", reservation.FacilityId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FacilityId,ConsumerId,Accepted,Start,End,Completed")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsumerId = new SelectList(db.Consumers, "ID", "UserId", reservation.ConsumerId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "ID", "Name", reservation.FacilityId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
