using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Provider.Provider;


namespace FamilyManagement.Services
{
    public class BaseService
    {
        [Dependency]
        public IUserRepository DiUserRepository { get; set; }
    }
}