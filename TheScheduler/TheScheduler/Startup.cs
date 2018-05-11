using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using TheScheduler.Models;

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
