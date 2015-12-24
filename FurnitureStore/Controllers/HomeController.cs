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

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index() {
            logger.Info("[Start]");
            try {
                var furnitures = db.Furnitures.Include(f => f.Producer).Include(f => f.Images).
                    OrderBy(c => Guid.NewGuid()).Take(3).AsNoTracking().ToList();
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