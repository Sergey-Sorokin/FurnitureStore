using System;
using System.Net;
using System.Web.Mvc;
using FurnitureStore.Models;
using FurnitureStore.Areas.Administration.Models;
using FurnitureStore.ViewModels;
using FurnitureStore.Areas.Administration.Services;
using System.Threading.Tasks;
using System.Threading;
using NLog;

namespace FurnitureStore.Areas.Administration.Controllers {
    [Authorize]
    public class FurnitureController : Controller {
        private AdministrationFurnitureService service;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const String AdminEditDeleteRole = "FurnitureAdmin,CanEditFurtiture,CanDeleteFurtiture";
        private const String AdminEditRole = "FurnitureAdmin,CanEditFurtiture";
        private const String AdminDeleteRole = "FurnitureAdmin,CanDeleteFurtiture";

        public FurnitureController(AdministrationFurnitureService furnitureService) {
            service = furnitureService;
        }

        // GET: Furnitures
        [AsyncTimeout(1000)]
        [AuthorizeWithRedirect(Roles = AdminEditDeleteRole)]
        public async Task<ActionResult> Index(CancellationToken cancellationToken) {
            return View(await service.ListOrderedByNameIncludingProducers(cancellationToken));
        }

        // GET: Furnitures/Create
        [AsyncTimeout(1000)]
        [AuthorizeWithRedirect(Roles = AdminEditRole)]
        public async Task<ActionResult> Create(CancellationToken cancellationToken) {
            return View(await service.PrepareCreateAsync(cancellationToken));
        }

        // POST: Furnitures/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AsyncTimeout(1000)]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = AdminEditRole)]
        public async Task<ActionResult> Create(FurnitureViewModel furnitureModel, CancellationToken cancellationToken) {
            try {
                logger.Debug("ModelState is valid: {0}", ModelState.IsValid);
                logger.Debug("Furniture: {0}", furnitureModel.Furniture);
                if (ModelState.IsValid) {
                    await service.CreateAsync(furnitureModel, HttpContext, cancellationToken);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                ModelState.AddModelError("", ex.Message);
            }

            return View(await service.PrepareCreateAsync(cancellationToken));
        }

        // GET: Furnitures/Edit/5
        [AsyncTimeout(1000)]
        [AuthorizeWithRedirect(Roles = AdminEditRole)]
        public async Task<ActionResult> Edit(int? id, CancellationToken cancellationToken) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var furniture = await service.PrepareEditAsync(id.Value, cancellationToken);
            if (furniture.Furniture == null) {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AsyncTimeout(1000)]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = AdminEditRole)]
        public async Task<ActionResult> Edit(FurnitureViewModel furnitureModel, CancellationToken cancellationToken) {
            try {              
                logger.Debug("ModelState is valid: {0}", ModelState.IsValid);
                logger.Debug("Furniture: {0}", furnitureModel.Furniture);
                logger.Debug("Files: {0}", furnitureModel.Files);
                logger.Debug("CheckedImages: {0}", furnitureModel.CheckedImages);

                if (ModelState.IsValid) {
                    await service.EditAsync(furnitureModel, HttpContext, cancellationToken);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
            }

            return View(await service.PrepareEditAsync(furnitureModel.Furniture.ID, cancellationToken));
        }

        // GET: Furnitures/Delete/5
        [AsyncTimeout(1000)]
        [AuthorizeWithRedirect(Roles = AdminDeleteRole)]
        public async Task<ActionResult> Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = await service.FindAsync(id.Value);
            if (furniture == null) {
                return HttpNotFound();
            }
            return View(furniture);
        }

        // POST: Furnitures/Delete/5
        [AsyncTimeout(1000)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeWithRedirect(Roles = AdminDeleteRole)]
        public async Task<ActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken) {
            await service.DeleteAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
    }
}
