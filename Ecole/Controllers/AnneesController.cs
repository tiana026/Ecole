using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecole.DAL;
using Ecole.Models;

namespace Ecole.Controllers
{
    public class AnneesController : Controller
    {
        private EcoleContext db = new EcoleContext();

        // GET: Annees
        public ActionResult Index()
        {
            return View(db.Annees.ToList());
        }

        // GET: Annees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annee annee = db.Annees.Find(id);
            if (annee == null)
            {
                return HttpNotFound();
            }
            return View(annee);
        }

        // GET: Annees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Annees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnneeNom")] Annee annee)
        {
            if (ModelState.IsValid)
            {
                db.Annees.Add(annee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(annee);
        }

        // GET: Annees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annee annee = db.Annees.Find(id);
            if (annee == null)
            {
                return HttpNotFound();
            }
            return View(annee);
        }

        // POST: Annees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnneeNom")] Annee annee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(annee);
        }

        // GET: Annees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annee annee = db.Annees.Find(id);
            if (annee == null)
            {
                return HttpNotFound();
            }
            return View(annee);
        }

        // POST: Annees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annee annee = db.Annees.Find(id);
            db.Annees.Remove(annee);
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
