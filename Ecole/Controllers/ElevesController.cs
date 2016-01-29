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
    public class ElevesController : Controller
    {
        private EcoleContext db = new EcoleContext();

        // GET: Eleves
        public ActionResult Index()
        {
            var eleves = db.Eleves.Include(e => e.Grade).Include(e => e.Parent);
            return View(eleves.ToList());
        }

        // GET: Eleves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleves/Create
        public ActionResult Create()
        {
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion");
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Nom");
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Postnom,Prenom,DateNaissance,LieuNaissance,Adresse,DateInscription,Sexe,ParentID,GradeID")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleves.Add(eleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", eleve.GradeID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Nom", eleve.ParentID);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", eleve.GradeID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Nom", eleve.ParentID);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Postnom,Prenom,DateNaissance,LieuNaissance,Adresse,DateInscription,Sexe,ParentID,GradeID")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradeID = new SelectList(db.Grades, "ID", "Promotion", eleve.GradeID);
            ViewBag.ParentID = new SelectList(db.Parents, "ID", "Nom", eleve.ParentID);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eleve eleve = db.Eleves.Find(id);
            db.Eleves.Remove(eleve);
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
