using FurnitureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NLog;
using System.Threading.Tasks;
using FurnitureStore.Services;

namespace FurnitureStore.Controllers {
    public class HomeController : Controller {

        private readonly FurnitureService service;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HomeController(FurnitureService service) {
            logger.Info("[Start]");
            this.service = service;
            logger.Debug("service: {0}", service);
            logger.Info("[End]");
        }

        public async Task<ActionResult> Index() {
            logger.Info("[Start]");
            try {
                var furnitures = await service.ListOrderedWithLimitAsync(3);

                return View(furnitures);
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw ex;
            }
            finally {
                logger.Info("[End]");
            }
        }

        public ActionResult Contact() {
            logger.Info("[Start]");
            try {
                return View();
            }
            catch (Exception ex) {
                logger.Error(ex, ex.Message);
                throw ex;
            }
            finally {
                logger.Info("[End]");
            }
        }
    }
}