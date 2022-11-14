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
    public class PredmetisController : Controller
    {
        private StudentiDBEntities db = new StudentiDBEntities();

        // GET: Predmetis
        public ActionResult Index()
        {
            return View(db.Predmetis.ToList());
        }

        // GET: Predmetis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
            return View(predmeti);
        }

        // GET: Predmetis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Predmetis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sifraPredmeta,naziv")] Predmeti predmeti)
        {
            if (ModelState.IsValid)
            {
                db.Predmetis.Add(predmeti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predmeti);
        }

        // GET: Predmetis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
            return View(predmeti);
        }

        // POST: Predmetis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sifraPredmeta,naziv")] Predmeti predmeti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predmeti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predmeti);
        }

        // GET: Predmetis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predmeti predmeti = db.Predmetis.Find(id);
            if (predmeti == null)
            {
                return HttpNotFound();
            }
            return View(predmeti);
        }

        // POST: Predmetis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predmeti predmeti = db.Predmetis.Find(id);
            db.Predmetis.Remove(predmeti);
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
