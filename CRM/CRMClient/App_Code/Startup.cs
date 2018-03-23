using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMClient.Startup))]
namespace CRMClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
