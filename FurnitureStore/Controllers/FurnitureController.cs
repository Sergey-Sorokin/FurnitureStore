using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FurnitureStore.Models;
using FurnitureStore.ViewModels;
using StackExchange.Profiling;
using NLog;

namespace FurnitureStore.Controllers {
    public class FurnitureController : Controller {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Furnitures
        public ActionResult Index() {
            logger.Info("[Start] Index");
            var furnitures = db.Furnitures.Include(f => f.Producer).Include(f => f.Images).AsNoTracking().ToList();
            logger.Debug("Furnitures: {0}", furnitures);
            logger.Info("[End] Index");
            return View(furnitures);
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
