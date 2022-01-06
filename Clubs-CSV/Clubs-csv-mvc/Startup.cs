using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clubs_csv_mvc.Startup))]
namespace Clubs_csv_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
