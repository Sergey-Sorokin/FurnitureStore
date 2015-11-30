using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FurnitureStore.ViewModels;
using FurnitureStore.Models;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity.Validation;

namespace FurnitureStore.Areas.Administration.Controllers {
    public class FurnitureController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Furnitures
        public ActionResult Index() {
            return View(db.Furnitures.Include(x => x.Producer).ToList());
        }

        // GET: Furnitures/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            if (furniture == null) {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // GET: Furnitures/Create
        public ActionResult Create() {
            var producers = db.Producers.ToList();
            var furniture = new FurnitureViewModel(producers);
            furniture.PublishDate = DateTime.Now;
            return View(furniture);
        }

        // POST: Furnitures/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,PublishDate,Description,ArticleNo,ProducerID,Price,Size,Color,Rating")] FurnitureViewModel furniture, IEnumerable<HttpPostedFileBase> files) {
            try {
                if (ModelState.IsValid) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        furniture.CreateUser = User.Identity.Name;
                        furniture.CreateDate = DateTime.Now;

                        db.Furnitures.Add(furniture);
                        db.SaveChanges();

                        foreach (var file in files) {
                            if (file != null && file.ContentLength > 0) {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/assets"), fileName);
                                file.SaveAs(path);

                                db.Images.Add(new Image {
                                    URL = fileName,
                                    FurnitureID = furniture.ID
                                });
                            }
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
            }

            furniture.Producers = db.Producers.ToList();
            return View(furniture);
        }

        // GET: Furnitures/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurnitureViewModel furniture = db.Furnitures.Find(id) as FurnitureViewModel;
            if (furniture == null) {
                return HttpNotFound();
            }
            furniture.Producers = db.Producers.ToList();
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PublishDate,Description,ArticleNo,ProducerID,Price,Size,Color,Rating")] FurnitureViewModel furniture, IEnumerable<HttpPostedFileBase> files) {
            try {
                if (ModelState.IsValid) {
                    using (var transaction = db.Database.BeginTransaction()) {
                        foreach (var file in files) {
                            if (file != null && file.ContentLength > 0) {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/assets"), fileName);
                                file.SaveAs(path);

                                db.Images.Add(new Image {
                                    URL = fileName,
                                    FurnitureID = furniture.ID
                                });
                            }
                        }

                        furniture.UpdateUser = User.Identity.Name;
                        furniture.UpdateDate = DateTime.Now;

                        db.Entry(furniture).State = EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex) {
                ModelState.AddModelError("", dex.Message);
            }

            furniture.Producers = db.Producers.ToList();
            return View(furniture);
        }

        // GET: Furnitures/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            if (furniture == null) {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Furniture furniture = db.Furnitures.Find(id);
            db.Furnitures.Remove(furniture);
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
