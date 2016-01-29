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
    public class MatieresController : Controller
    {
        private EcoleContext db = new EcoleContext();

        // GET: Matieres
        public ActionResult Index()
        {
            var matieres = db.Matieres.Include(m => m.Enseignant).Include(m => m.Grade);
            return View(matieres.ToList());
        }

        // GET: Matieres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // GET: Matieres/Create
        public ActionResult Create()
        {
            ViewBag.EnseignantID = new SelectList(db.Enseignants, "ID", "Nom");
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion");
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Intitule,EnseignantID,GradeID")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Matieres.Add(matiere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnseignantID = new SelectList(db.Enseignants, "ID", "Nom", matiere.EnseignantID);
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", matiere.GradeID);
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnseignantID = new SelectList(db.Enseignants, "ID", "Nom", matiere.EnseignantID);
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", matiere.GradeID);
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Intitule,EnseignantID,GradeID")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matiere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnseignantID = new SelectList(db.Enseignants, "ID", "Nom", matiere.EnseignantID);
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", matiere.GradeID);
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return HttpNotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matiere matiere = db.Matieres.Find(id);
            db.Matieres.Remove(matiere);
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
