using FurnitureStore.Interfaces.Services;
using FurnitureStore.Models;
using System.Linq;
using System.Data.Entity;
using FurnitureStore.ViewModels;
using NLog;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FurnitureStore.Services {
    public class FurnitureService : IDisposable, IService<Furniture, int> {

        private const int ItemsPerPage = 36;

        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected ApplicationDbContext db;

        public FurnitureService(ApplicationDbContext context) {
            logger.Info("[Start]");
            db = context;
            logger.Debug("context: {0}", context);
            logger.Info("[End]");
        }

        public async Task<PaginationViewModel> ListOrderedWithPaginationAsync(int itemsPerPage, int page) {
            logger.Info("[Start]");
            var furnitures = await db.Furnitures.Include(f => f.Producer).Include(f => f.Images).
                   OrderByDescending(o => o.PublishDate).OrderByDescending(o => o.CreateDate).Skip(page * itemsPerPage).Take(itemsPerPage + 1).
                   AsNoTracking().ToListAsync();

            var hasMoreFurniture = false;
            // Check is there are more furniture to be shown on second page
            if (furnitures.Count > itemsPerPage) {
                // As one more furniture was added in result, excluding it now
                furnitures.RemoveAt(itemsPerPage);
                hasMoreFurniture = true;
            }

            logger.Debug("furnitures: {0}", furnitures);
            logger.Debug("hasMoreFurniture: {0}", hasMoreFurniture);
            logger.Debug("page: {0}", page);

            logger.Info("[End]");

            return new PaginationViewModel(furnitures, 3, page + 1, hasMoreFurniture);
        }

        public async Task<List<Furniture>> ListOrderedWithLimitAsync(int limit) {
            logger.Info("[Start]");
            logger.Debug("limit: {0}", limit);

            return await db.Furnitures.Include(f => f.Producer).Include(f => f.Images)
                .OrderBy(c => Guid.NewGuid()).Take(3).AsNoTracking().ToListAsync();
        }

        public async Task<Furniture> FindAsync(int id) {
            logger.Info("[Start]");
            logger.Debug("id: {0}", id);
            logger.Info("[End]");

            return await db.Furnitures.FindAsync(id);
        }

        protected virtual void Dispose(bool disposing) {
            logger.Info("[Start]");
            logger.Debug("disposing: {0}", disposing);
            if (disposing) {
                db.Dispose();
            }
            logger.Info("[End]");
        }

        public void Dispose() {
            logger.Info("[Start]");
            Dispose(true);
            logger.Info("[End]");
        }
    }
}