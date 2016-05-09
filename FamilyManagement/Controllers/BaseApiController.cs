using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using FamilyManagement.Services;
using FamilyManagement.Security;

namespace FamilyManagement.Controllers
{
     [ApiExceptionFilter]
     [AuthenticationApi]
    public class BaseApiController : ApiController
    {
        [Dependency]
        public UserService DiUserService { get; set; }
    }
   
}
