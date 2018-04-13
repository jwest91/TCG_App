using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TCG_App.Startup))]
namespace TCG_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
