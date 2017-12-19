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
    public class WandelingsController : Controller
    {
        private HaarlemFilmDBContext db = new HaarlemFilmDBContext();

        // GET: Wandelings
        public ActionResult Index()
        {
            //var evenements = db.Evenements.Include(w => w.Begeleider);
            return View(db.Wandelings.ToList());
        }

        // GET: Wandelings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wandeling wandeling = (Wandeling)db.Evenements.Find(id);
            if (wandeling == null)
            {
                return HttpNotFound();
            }
            return View(wandeling);
        }

        // GET: Wandelings/Create
        public ActionResult Create()
        {
            ViewBag.BegeleiderId = new SelectList(db.Begeleiders, "BegeleiderId", "Naam");
            return View();
        }

        // POST: Wandelings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvenementId,Duur,BeginTijd,Dag,NaamEvenement,MaxPlaatsen,Prijs,Locatie,BegeleiderId")] Wandeling wandeling)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(wandeling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BegeleiderId = new SelectList(db.Begeleiders, "BegeleiderId", "Naam", wandeling.BegeleiderId);
            return View(wandeling);
        }

        // GET: Wandelings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wandeling wandeling = (Wandeling)db.Evenements.Find(id);
            if (wandeling == null)
            {
                return HttpNotFound();
            }
            ViewBag.BegeleiderId = new SelectList(db.Begeleiders, "BegeleiderId", "Naam", wandeling.BegeleiderId);
            return View(wandeling);
        }

        // POST: Wandelings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvenementId,Duur,BeginTijd,Dag,NaamEvenement,MaxPlaatsen,Prijs,Locatie,BegeleiderId")] Wandeling wandeling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wandeling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BegeleiderId = new SelectList(db.Begeleiders, "BegeleiderId", "Naam", wandeling.BegeleiderId);
            return View(wandeling);
        }

        // GET: Wandelings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wandeling wandeling = (Wandeling)db.Evenements.Find(id);
            if (wandeling == null)
            {
                return HttpNotFound();
            }
            return View(wandeling);
        }

        // POST: Wandelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wandeling wandeling = (Wandeling)db.Evenements.Find(id);
            db.Evenements.Remove(wandeling);
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
