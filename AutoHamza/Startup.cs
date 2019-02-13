using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoHamza.Startup))]
namespace AutoHamza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
