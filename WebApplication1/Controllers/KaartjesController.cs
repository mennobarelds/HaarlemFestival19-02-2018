using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class KaartjesController : Controller
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        // GET: Kaartjes
        public ActionResult Index()
        {
            var kaartjes = db.Kaartjes.Include(k => k.Evenement);
            return View(kaartjes.ToList());
        }

        // GET: Kaartjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaartje kaartje = db.Kaartjes.Find(id);
            if (kaartje == null)
            {
                return HttpNotFound();
            }
            return View(kaartje);
        }

        // GET: Kaartjes/Create
        public ActionResult Create()
        {
            ViewBag.EvenementId = new SelectList(db.Evenements, "EvenementId", "NaamEvenement");
            return View();
        }

        // POST: Kaartjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KaartjeId,TotaalPrijs,Aantal,BijzonderhedenRestaurant,SoortKaartje,EvenementId")] Kaartje kaartje)
        {
            if (ModelState.IsValid)
            {
                db.Kaartjes.Add(kaartje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EvenementId = new SelectList(db.Evenements, "EvenementId", "NaamEvenement", kaartje.EvenementId);
            return View(kaartje);
        }

        // GET: Kaartjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaartje kaartje = db.Kaartjes.Find(id);
            if (kaartje == null)
            {
                return HttpNotFound();
            }
            ViewBag.EvenementId = new SelectList(db.Evenements, "EvenementId", "NaamEvenement", kaartje.EvenementId);
            return View(kaartje);
        }

        // POST: Kaartjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KaartjeId,TotaalPrijs,Aantal,BijzonderhedenRestaurant,SoortKaartje,EvenementId")] Kaartje kaartje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaartje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EvenementId = new SelectList(db.Evenements, "EvenementId", "NaamEvenement", kaartje.EvenementId);
            return View(kaartje);
        }

        // GET: Kaartjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaartje kaartje = db.Kaartjes.Find(id);
            if (kaartje == null)
            {
                return HttpNotFound();
            }
            return View(kaartje);
        }

        // POST: Kaartjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kaartje kaartje = db.Kaartjes.Find(id);
            db.Kaartjes.Remove(kaartje);
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
