using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using Unity.WebApi;
using Unity.Mvc3;
using Provider.Provider;
using Provider.Model;



namespace Provider.Infra
{
    public sealed class Bootstrapper
    {
      
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new  Unity.Mvc3.UnityDependencyResolver(container)); //mvc注入
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);//webpai注入
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserTokenRepository, UserTokenRepository>();
            //var a = container.Resolve<IUserRepository>();
            //var b = container.Resolve<IUserTokenRepository>();
            RegisterTypes(container);    
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
    
}
