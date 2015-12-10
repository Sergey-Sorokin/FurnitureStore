using FurnitureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NLog;

namespace FurnitureStore.Controllers {
    public class HomeController : Controller {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index() {
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