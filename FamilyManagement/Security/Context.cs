using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamilyManagement.Dtos;
using Provider.Infra;

namespace FamilyManagement.Security {
    public class Context {
        private static string _preFix = ConfigHelper.GetConfigString("sessionPrefix");

        public static void SetUser(CurrentUser user) {

            HttpContext.Current.Session[_preFix + "_User"] = user;
        }

        public static CurrentUser GetCurrentUser() {
            return HttpContext.Current.Session[_preFix + "_User"] as CurrentUser;
        }

        public static void Logout() {
            HttpContext.Current.Session[_preFix + "_User"] = null;
        }
    }
}