using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopExcercise.WebUI.Startup))]
namespace WebShopExcercise.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
