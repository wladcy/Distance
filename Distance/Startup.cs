using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Distance.Startup))]
namespace Distance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
