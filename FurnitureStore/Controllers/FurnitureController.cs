using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FurnitureStore.Models;
using NLog;
using FurnitureStore.Areas.Administration.ViewModels;
using System;

namespace FurnitureStore.Controllers {
    public class FurnitureController : Controller {

        const int ItemsPerPage = 36;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Furniture?page=0
        public ActionResult Index(int page = 0) {
            logger.Info("[Start]");
            try {
                var furnitures = db.Furnitures.Include(f => f.Producer).Include(f => f.Images).
                    OrderByDescending(o => o.PublishDate).OrderByDescending(o => o.ID).Skip(page * ItemsPerPage).Take(ItemsPerPage + 1).
                    AsNoTracking().ToList();

                var hasMoreFurniture = false;
                // Check is there are more furniture to be shown on second page
                if (furnitures.Count > ItemsPerPage) {
                    // As one more furniture was added in result, excluding it now
                    furnitures.RemoveAt(ItemsPerPage);
                    hasMoreFurniture = true;
                }

                logger.Debug("furnitures: {0}", furnitures);
                logger.Debug("hasMoreFurniture: {0}", hasMoreFurniture);
                logger.Debug("page: {0}", page);
                var view = new PaginaionViewModel(furnitures, 3, page + 1, hasMoreFurniture);

                if (Request.IsAjaxRequest()) {
                    logger.Info("Ajax request");
                    return PartialView("_Index", view);
                }

                logger.Info("Non-ajax request");
                return View(view);
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw ex;
            }
            finally {
                logger.Info("[End]");
            }
        }

        // GET: Furniture/Details/5
        public ActionResult Details(int? id) {
            logger.Info("[Start]");
            try {
                logger.Debug("id: {0}", id);
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Furniture furniture = db.Furnitures.Find(id);
                logger.Debug("furniture: {0}", furniture);
                if (furniture == null) {
                    return HttpNotFound();
                }

                return View(furniture);
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw ex;
            }
            finally {
                logger.Info("[End]");
            }
        }

        protected override void Dispose(bool disposing) {
            logger.Info("[Start]");
            logger.Debug("disposing: {0}", disposing);
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
            logger.Info("[End]");
        }
    }
}
