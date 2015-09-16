using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using FamilyManagement.Services;
using FamilyManagement.Models;
using Provider.Infra;


namespace FamilyManagement.Security
{
  
        public class ApiExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext filterContext)
            {
                var warning = filterContext.Exception as Warning;
                if (warning != null)
                {
                    var response = new ErrorResponse(warning);
                    filterContext.Response = filterContext.Request.CreateResponse(response);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("|Url:");
                    sb.Append(filterContext.ActionContext.Request.RequestUri.AbsoluteUri);
                    sb.Append("\r\n");
                    sb.Append(filterContext.Exception.Message.Replace("<", string.Empty).Replace(">", string.Empty));
                    sb.Append("\r\n");
                    sb.Append(filterContext.Exception.Source);
                    sb.Append("\r\n");
                    sb.Append(filterContext.Exception.StackTrace);
                    sb.Append("\r\n");
                    Exception ex = filterContext.Exception.InnerException;
                    while (ex != null)
                    {
                        sb.Append("\r\n-----------------------");
                        sb.Append(filterContext.Exception.Message.Replace("<", string.Empty).Replace(">", string.Empty));
                        sb.Append("\r\n");
                        sb.Append(filterContext.Exception.Source);
                        sb.Append("\r\n");
                        sb.Append(filterContext.Exception.StackTrace);
                        ex = ex.InnerException;
                    }

                    LogHelper.WriteLog(sb.ToString());
                    var response = new ErrorResponse(0, "系统错误,请联系管理员");
                    filterContext.Response = filterContext.Request.CreateResponse(response);
                }

                base.OnException(filterContext);
            }
        }
    
}