using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FurnitureStore.Models;
using FurnitureStore.ViewModels;
using StackExchange.Profiling;
using NLog;
using FurnitureStore.Areas.Administration.ViewModels;

namespace FurnitureStore.Controllers {
    public class FurnitureController : Controller {

        const int ItemsPerPage = 3;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Furnitures
        public ActionResult Index(int page = 0) {
            logger.Info("[Start] Index");
            var furnitures = db.Furnitures.Include(f => f.Producer).Include(f => f.Images).
                OrderByDescending(o => o.PublishDate).Skip(page * ItemsPerPage).Take(ItemsPerPage + 1).
                AsNoTracking().ToList();
            var hasMoreFurniture = false;

            if (furnitures.Count > ItemsPerPage) {
                furnitures.RemoveAt(ItemsPerPage);
                hasMoreFurniture = true;
            }

            logger.Debug("Furnitures: {0}", furnitures);
            logger.Debug("Page: {0}", page);
            var view = new PaginaionViewModel(furnitures, 3, page + 1, hasMoreFurniture);

            if (Request.IsAjaxRequest()) {
                logger.Info("Ajax request");
                logger.Info("[End] Index");
                return PartialView("_Index", view);
            }

            logger.Info("Non-ajax request");
            logger.Info("[End] Index");
            return View(view);
        }

        // GET: Furniture/Details/5
        public ActionResult Details(int? id) {
            logger.Info("[Start] Details");
            logger.Debug("id: {0}", id);
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Furniture furniture = db.Furnitures.Find(id);
            logger.Debug("furniture: {0}", furniture);
            if (furniture == null) {
                return HttpNotFound();
            }
            logger.Info("[End] Details");
            return View(furniture);
        }

        protected override void Dispose(bool disposing) {
            logger.Info("[Start] Dispose");
            logger.Debug("disposing: {0}", disposing);
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
            logger.Info("[End] Dispose");
        }
    }
}
