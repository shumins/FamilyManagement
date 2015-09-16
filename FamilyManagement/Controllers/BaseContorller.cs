using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using FamilyManagement.Services;

namespace FamilyManagement.Controllers
{
    public class BaseContorller : Controller
    {
        [Dependency]
        public UserService DiUserService { get; set; }
    }
}