using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyManagement.Controllers
{
    public class AdminController : BaseContorller
    {
        // GET: AdminUser
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        public ActionResult Left()
        {
            return View();
        }
       

        #region User
        public ActionResult User_List()
        {
            return View();
        }
        #endregion

        #region Charts

        public ActionResult Charts_LineChart()
        {
            return View();
        }
        #endregion
        


    }
}