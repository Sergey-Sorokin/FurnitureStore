using FurnitureStore.Areas.Administration.Models;
using FurnitureStore.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using NLog;

namespace FurnitureStore.Models {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
            logger.Info("[Start]");
        }

        public static ApplicationDbContext Create() {
            logger.Info("[Start]");
            return new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            logger.Info("[End]");
            base.Dispose(disposing);
        }

        public System.Data.Entity.DbSet<Furniture> Furnitures { get; set; }
        public System.Data.Entity.DbSet<Producer> Producers { get; set; }
        public System.Data.Entity.DbSet<Image> Images { get; set; }
    }
}