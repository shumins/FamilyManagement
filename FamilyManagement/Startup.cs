using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyManagement.Startup))]
namespace FamilyManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
