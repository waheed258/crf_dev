using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMAdminProject.Startup))]
namespace CRMAdminProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
