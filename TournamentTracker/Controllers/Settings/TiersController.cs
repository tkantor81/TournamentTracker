using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TournamentTracker.Models;

namespace TournamentTracker.Controllers.Settings
{
    [Authorize(Roles = "admin")]
    public class TiersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tiers
        public ActionResult Index()
        {
            return View(db.Tiers.ToList());
        }

        // GET: Tiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tier tier = db.Tiers.Find(id);
            if (tier == null)
            {
                return HttpNotFound();
            }
            return View(tier);
        }

        // GET: Tiers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] Tier tier)
        {
            if (ModelState.IsValid)
            {
                db.Tiers.Add(tier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tier);
        }

        // GET: Tiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tier tier = db.Tiers.Find(id);
            if (tier == null)
            {
                return HttpNotFound();
            }
            return View(tier);
        }

        // POST: Tiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] Tier tier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tier);
        }

        // GET: Tiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tier tier = db.Tiers.Find(id);
            if (tier == null)
            {
                return HttpNotFound();
            }
            return View(tier);
        }

        // POST: Tiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tier tier = db.Tiers.Find(id);
            db.Tiers.Remove(tier);
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
