using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspProject8.Startup))]
namespace aspProject8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
