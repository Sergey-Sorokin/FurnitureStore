using Ninject.Modules;
using FurnitureStore.Models;
using NLog;
using Ninject;
using System;

namespace FurnitureStore.Ninject {
    public class FurnitureNinjectModule : NinjectModule {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void Load() {
            logger.Info("[Start] Load");
            Bind<ApplicationDbContext>().ToSelf();
            logger.Info("[End] Load");
        }

    }
}