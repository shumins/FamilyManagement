using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyManagement.Security;
using FamilyManagement.Services;
using FamilyManagement.Models;


namespace FamilyManagement.Controllers
{
    public class UserController : BaseContorller
    {
        // GET: User
         [Authentication(false)]
        public ActionResult Login() {
            #region 增加自动登录的逻辑
            var cookie = Request.Cookies.Get("tokenKey");
             if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
             {
                 var user =  DiUserService.LoginByToken(cookie.Value);
                 if (user != null)
                 {
                     Context.SetUser(new CurrentUser()
                     {
                         LoginName=user.LoginName,
                         UserId=user.Id,
                     });
                     return Redirect("/Admin/Left");
                 }
             }

             #endregion
            return View();
        }

        [HttpPost]
        public ActionResult Login(string loginName, string password)
        {

            var user = DiUserService.Login(loginName, password);
            return Json("");
        }
             

       
    }
}