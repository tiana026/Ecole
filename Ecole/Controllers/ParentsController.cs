﻿using System;
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
    public class ParentsController : Controller
    {
        private EcoleContext db = new EcoleContext();

        // GET: Parents
        public ActionResult Index()
        {
            return View(db.Parents.ToList());
        }

        // GET: Parents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // GET: Parents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Postnom,Prenom,Sexe,Telephone,Email")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                db.Parents.Add(parent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parent);
        }

        // GET: Parents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Postnom,Prenom,Sexe,Telephone,Email")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parent);
        }

        // GET: Parents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent parent = db.Parents.Find(id);
            db.Parents.Remove(parent);
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
