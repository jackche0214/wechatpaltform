using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(weixinmenu.Startup))]
namespace weixinmenu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
