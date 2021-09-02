using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiShop.WebUI.Startup))]
namespace MiShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
