using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheScheduler.Startup))]
namespace TheScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
