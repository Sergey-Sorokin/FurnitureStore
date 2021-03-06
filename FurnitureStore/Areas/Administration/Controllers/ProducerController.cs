﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;
using FurnitureStore.Areas.Administration.Models;

namespace FurnitureStore.Areas.Administration.Controllers {
    [Authorize]
    public class ProducerController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administration/Producers
        [AuthorizeWithRedirect(Roles = "ProducerAdmin,CanEditProducer, CanDeleteProducer")]
        public ActionResult Index() {
            return View(db.Producers.ToList());
        }

        // GET: Administration/Producers/Create
        [AuthorizeWithRedirect(Roles = "ProducerAdmin, CanEditProducer")]
        public ActionResult Create() {
            return View();
        }

        // POST: Administration/Producers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = "ProducerAdmin,CanEditProducer")]
        public ActionResult Create([Bind(Include = "ID,Country,Name")] Producer producer) {
            if (ModelState.IsValid) {
                db.Producers.Add(producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producer);
        }

        // GET: Administration/Producers/Edit/5
        [AuthorizeWithRedirect(Roles = "ProducerAdmin, CanDeleteProducer")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null) {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Administration/Producers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = "ProducerAdmin, CanEditProducer")]
        public ActionResult Edit([Bind(Include = "ID,Country,Name")] Producer producer) {
            if (ModelState.IsValid) {
                db.Entry(producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        // GET: Administration/Producers/Delete/5
        [AuthorizeWithRedirect(Roles = "ProducerAdmin, CanDeleteProducer")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producer producer = db.Producers.Find(id);
            if (producer == null) {
                return HttpNotFound();
            }
            return View(producer);
        }

        // POST: Administration/Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = "ProducerAdmin, CanDeleteProducer")]
        public ActionResult DeleteConfirmed(int id) {
            Producer producer = db.Producers.Find(id);
            db.Producers.Remove(producer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
