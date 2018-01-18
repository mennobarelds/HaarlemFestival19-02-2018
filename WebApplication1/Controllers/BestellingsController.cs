using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BestellingsController : Controller
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        // GET: Bestellings
        public ActionResult Index()
        {
            var bestelling = db.Bestelling.Include(b => b.Klant);
            return View(bestelling.ToList());
        }

        // GET: Bestellings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelling bestelling = db.Bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            return View(bestelling);
        }

        // GET: Bestellings/Create
        public ActionResult Create()
        {
            ViewBag.KlantId = new SelectList(db.Klants, "KlantId", "KlantId");
            return View();
        }

        // POST: Bestellings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BestellingId,Betaald,BestelCode,TotaalPrijs,KlantId")] Bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                db.Bestelling.Add(bestelling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlantId = new SelectList(db.Klants, "KlantId", "KlantId", bestelling.KlantId);
            return View(bestelling);
        }

        // GET: Bestellings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelling bestelling = db.Bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlantId = new SelectList(db.Klants, "KlantId", "KlantId", bestelling.KlantId);
            return View(bestelling);
        }

        // POST: Bestellings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BestellingId,Betaald,BestelCode,TotaalPrijs,KlantId")] Bestelling bestelling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bestelling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlantId = new SelectList(db.Klants, "KlantId", "KlantId", bestelling.KlantId);
            return View(bestelling);
        }

        // GET: Bestellings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestelling bestelling = db.Bestelling.Find(id);
            if (bestelling == null)
            {
                return HttpNotFound();
            }
            return View(bestelling);
        }

        // POST: Bestellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bestelling bestelling = db.Bestelling.Find(id);
            db.Bestelling.Remove(bestelling);
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
