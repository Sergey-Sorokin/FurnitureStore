using Ninject.Modules;
using FurnitureStore.Models;
using NLog;
using FurnitureStore.Services;
using FurnitureStore.Areas.Administration.Services;
using FurnitureStore.Areas.Administration.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FurnitureStore.Ninject {
    public class FurnitureNinjectModule : NinjectModule {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void Load() {
            logger.Info("[Start]");

            Bind<ApplicationDbContext>().ToSelf();
            Bind<FurnitureService>().ToSelf();
            //Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            //Bind<IRoleStore<ApplicationRole, string>>().To<RoleStore<ApplicationRole>>();
            //Bind<RoleService>().ToSelf();

            logger.Info("[End]");
        }

    }
}