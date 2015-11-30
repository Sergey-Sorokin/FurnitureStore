using Microsoft.AspNet.Identity.EntityFramework;
using NLog;

namespace FurnitureStore.Models {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
            logger.Info("[Start] Constructor");
        }

        public static ApplicationDbContext Create() {
            logger.Info("[Start] Create");
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Furniture> Furnitures { get; set; }
        public System.Data.Entity.DbSet<Producer> Producers { get; set; }
        public System.Data.Entity.DbSet<Image> Images { get; set; }
    }
}