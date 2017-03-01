using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopList.Startup))]
namespace ShopList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
