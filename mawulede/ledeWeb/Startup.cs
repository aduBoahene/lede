using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ledeWeb.Startup))]
namespace ledeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
