using System.Web.Mvc;

namespace FurnitureStore.Areas.Administration {
    public class AdministrationAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { controller = "Furniture", action = "Index", id = UrlParameter.Optional },
                new[] { "FurnitureStore.Areas.Administration.Controllers" }
            );
        }
    }
}