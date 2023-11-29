using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopThoiTrang.Startup))]
namespace WebShopThoiTrang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
