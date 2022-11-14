using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zadatak1.Models;

namespace zadatak1.Controllers
{
    public class IspitisController : Controller
    {
        private StudentiDBEntities db = new StudentiDBEntities();

        // GET: Ispitis
        public ActionResult Index()
        {
            var ispitis = db.Ispitis.Include(i => i.Predmeti).Include(i => i.Studenti);
            return View(ispitis.ToList());
        }

        // GET: Ispitis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispiti ispiti = db.Ispitis.Find(id);
            if (ispiti == null)
            {
                return HttpNotFound();
            }
            return View(ispiti);
        }

        // GET: Ispitis/Create
        public ActionResult Create()
        {
            ViewBag.sifraPremeta = new SelectList(db.Predmetis, "sifraPredmeta", "naziv");
            ViewBag.indeks = new SelectList(db.Studentis, "indeks", "ime");
            return View();
        }

        // POST: Ispitis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sifraPremeta,indeks,datum,ocena")] Ispiti ispiti)
        {
            if (ModelState.IsValid)
            {
                db.Ispitis.Add(ispiti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sifraPremeta = new SelectList(db.Predmetis, "sifraPredmeta", "naziv", ispiti.sifraPremeta);
            ViewBag.indeks = new SelectList(db.Studentis, "indeks", "ime", ispiti.indeks);
            return View(ispiti);
        }

        // GET: Ispitis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispiti ispiti = db.Ispitis.Find(id);
            if (ispiti == null)
            {
                return HttpNotFound();
            }
            ViewBag.sifraPremeta = new SelectList(db.Predmetis, "sifraPredmeta", "naziv", ispiti.sifraPremeta);
            ViewBag.indeks = new SelectList(db.Studentis, "indeks", "ime", ispiti.indeks);
            return View(ispiti);
        }

        // POST: Ispitis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sifraPremeta,indeks,datum,ocena")] Ispiti ispiti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ispiti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sifraPremeta = new SelectList(db.Predmetis, "sifraPredmeta", "naziv", ispiti.sifraPremeta);
            ViewBag.indeks = new SelectList(db.Studentis, "indeks", "ime", ispiti.indeks);
            return View(ispiti);
        }

        // GET: Ispitis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispiti ispiti = db.Ispitis.Find(id);
            if (ispiti == null)
            {
                return HttpNotFound();
            }
            return View(ispiti);
        }

        // POST: Ispitis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ispiti ispiti = db.Ispitis.Find(id);
            db.Ispitis.Remove(ispiti);
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
