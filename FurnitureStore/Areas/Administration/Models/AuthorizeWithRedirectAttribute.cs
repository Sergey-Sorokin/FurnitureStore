using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureStore.Areas.Administration.Models {
    public class AuthorizeWithRedirectAttribute : AuthorizeAttribute {

        public string View { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext) {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult) {
                filterContext.Result = new ViewResult { ViewName = View ?? "Unauthorized" };
            }
        }
    }
}