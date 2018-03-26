using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMClientProject.Startup))]
namespace CRMClientProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
