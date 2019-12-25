using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2019MusicShop.Startup))]
namespace _2019MusicShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
