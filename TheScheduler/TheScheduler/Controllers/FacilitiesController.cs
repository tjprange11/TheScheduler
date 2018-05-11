using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheScheduler.Models;

namespace TheScheduler.Controllers
{
    public class FacilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facilities
        public ActionResult Index()
        {
            var facilities = db.Facilities.Include(f => f.FacilityAddress).Include(f => f.Owner);
            return View(facilities.ToList());
        }
        // GET: Facilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }
        // GET: Facilities/Create
        public ActionResult Create(int FacilityAddressId)
        {
            ViewBag.FacilityAddressId = FacilityAddressId;
            ViewBag.FacilityAddress = db.FacilityAddresses.Where(data => data.ID == FacilityAddressId).Select(data => data).First();
            Owner Owner = db.Owners.Where(owner => owner.ID == 1).First();
            ViewBag.OwnerId = Owner.ID;
            ViewBag.Owner = Owner;
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FacilityAddressID,OwnerId,Name,Sport,Indoor")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacilityAddressId = new SelectList(db.FacilityAddresses, "ID", "StreetAddress", facility.FacilityAddressId);
            ViewBag.OwnerId = new SelectList(db.Owners, "ID", "UserId", facility.OwnerId);
            return View(facility);
        }

        // GET: Facilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacilityAddressId = new SelectList(db.FacilityAddresses, "ID", "StreetAddress", facility.FacilityAddressId);
            ViewBag.OwnerId = new SelectList(db.Owners, "ID", "UserId", facility.OwnerId);
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FacilityAddressId,OwnerId,Name,Sport,Indoor")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacilityAddressId = new SelectList(db.FacilityAddresses, "ID", "StreetAddress", facility.FacilityAddressId);
            ViewBag.OwnerId = new SelectList(db.Owners, "ID", "UserId", facility.OwnerId);
            return View(facility);
        }

        // GET: Facilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);
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
