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
        public ActionResult Login()
        {
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