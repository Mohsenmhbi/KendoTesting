using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoTesting.Startup))]
namespace KendoTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
