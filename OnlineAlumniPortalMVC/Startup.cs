using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAlumniPortalMVC.Startup))]
namespace OnlineAlumniPortalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
