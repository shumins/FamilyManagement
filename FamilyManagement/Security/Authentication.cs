using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyManagement.Security {
    public class Authentication : FilterAttribute, IAuthorizationFilter {
        public bool OpenAuth { get; set; }

        public Authentication() {
            OpenAuth = true;
        }

        public Authentication(bool openAuth) {
            OpenAuth = openAuth;
        }

        public void OnAuthorization(AuthorizationContext filterContext) {
            if (Context.GetCurrentUser() == null && OpenAuth) {
                HttpContext.Current.Response.Redirect("/User/Login");
            }
        }
    }
}