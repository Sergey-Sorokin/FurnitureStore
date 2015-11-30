using Microsoft.Owin;
using Owin;
using StackExchange.Profiling.EntityFramework6;

[assembly: OwinStartupAttribute(typeof(FurnitureStore.Startup))]
namespace FurnitureStore {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
