using System.Net;
using System.Web.Mvc;
using NLog;
using System;
using FurnitureStore.Services;
using System.Threading.Tasks;

namespace FurnitureStore.Controllers {
    public class FurnitureController : Controller {

        private readonly FurnitureService service;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public FurnitureController(FurnitureService service) {
            logger.Info("[Start]");
            this.service = service;
            logger.Debug("service: {0}", service);
            logger.Info("[End]");

        }

        // GET: Furniture?page=0
        public async Task<ActionResult> Index(int page = 0) {
            logger.Info("[Start]");
            try {
                logger.Debug("service: {0}", service);
                logger.Debug("page: {0}", page);
                var view = await service.ListOrderedWithPaginationAsync(36, page);

                // Ajax request sent to show additional furniture
                if (Request.IsAjaxRequest()) {
                    logger.Info("Ajax request");
                    return PartialView("_Index", view);
                } else {
                    logger.Info("Non-ajax request");
                    return View(view);
                }
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
        public async Task<ActionResult> Details(int? id) {
            logger.Info("[Start]");
            try {
                logger.Debug("id: {0}", id);
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                logger.Debug("service: {0}", service);
                var furniture = await service.FindAsync(id.Value);

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
            base.Dispose(disposing);
            logger.Info("[End]");
        }
    }
}
