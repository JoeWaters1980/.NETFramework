using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clubs_MVC.Startup))]
namespace Clubs_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
