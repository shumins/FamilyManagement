using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using FamilyManagement.Models;
using FamilyManagement.Services;


namespace FamilyManagement.Security {
     
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthenticationApi : ActionFilterAttribute
    {
        public bool OpenAuth { get; set; }

        public AuthenticationApi() {
            OpenAuth = true;
        }

        public AuthenticationApi(bool openAuth) {
            OpenAuth = openAuth;
        }
        /// <summary>  
        /// 检查用户是否有该API执行的操作权限  
        /// </summary>  
        /// <param name="actionContext"></param>  
        public override void OnActionExecuting(HttpActionContext actionContext) {
            if (Context.GetCurrentUser() == null && OpenAuth) {
                Warning authWarn = new Warning(498);
                var response = new ErrorResponse(authWarn);
                actionContext.Response = actionContext.Request.CreateResponse(response);
            }
            else {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}