using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManyToManyMVC.Startup))]
namespace HotelManyToManyMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
