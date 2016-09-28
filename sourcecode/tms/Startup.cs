using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tms.Startup))]
namespace tms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
