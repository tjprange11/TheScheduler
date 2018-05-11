using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheScheduler.Models;

namespace TheScheduler.Controllers
{
    public class FacilityAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacilityAddresses
        public ActionResult Index()
        {
            return View(db.FacilityAddresses.ToList());
        }

        // GET: FacilityAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityAddress facilityAddress = db.FacilityAddresses.Find(id);
            if (facilityAddress == null)
            {
                return HttpNotFound();
            }
            return View(facilityAddress);
        }
        // GET: FacilityAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacilityAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StreetAddress,City,State,Country,PostalCode")] FacilityAddress facilityAddress)
        {
            if (ModelState.IsValid)
            {
                db.FacilityAddresses.Add(facilityAddress);
                db.SaveChanges();
                return RedirectToAction("Create" , "Facilities", new { FacilityAddressId = facilityAddress.ID });
            }

            return View(facilityAddress);
        }

        // GET: FacilityAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityAddress facilityAddress = db.FacilityAddresses.Find(id);
            if (facilityAddress == null)
            {
                return HttpNotFound();
            }
            return View(facilityAddress);
        }

        // POST: FacilityAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StreetAddress,City,State,Country,PostalCode")] FacilityAddress facilityAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facilityAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facilityAddress);
        }

        // GET: FacilityAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacilityAddress facilityAddress = db.FacilityAddresses.Find(id);
            if (facilityAddress == null)
            {
                return HttpNotFound();
            }
            return View(facilityAddress);
        }

        // POST: FacilityAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacilityAddress facilityAddress = db.FacilityAddresses.Find(id);
            db.FacilityAddresses.Remove(facilityAddress);
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
