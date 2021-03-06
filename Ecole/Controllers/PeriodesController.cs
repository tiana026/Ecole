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
    public class PeriodesController : Controller
    {
        private EcoleContext db = new EcoleContext();

        // GET: Periodes
        public ActionResult Index()
        {
            return View(db.Periodes.ToList());
        }

        // GET: Periodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periode periode = db.Periodes.Find(id);
            if (periode == null)
            {
                return HttpNotFound();
            }
            return View(periode);
        }

        // GET: Periodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomPeriode")] Periode periode)
        {
            if (ModelState.IsValid)
            {
                db.Periodes.Add(periode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periode);
        }

        // GET: Periodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periode periode = db.Periodes.Find(id);
            if (periode == null)
            {
                return HttpNotFound();
            }
            return View(periode);
        }

        // POST: Periodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomPeriode")] Periode periode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periode);
        }

        // GET: Periodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periode periode = db.Periodes.Find(id);
            if (periode == null)
            {
                return HttpNotFound();
            }
            return View(periode);
        }

        // POST: Periodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periode periode = db.Periodes.Find(id);
            db.Periodes.Remove(periode);
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
