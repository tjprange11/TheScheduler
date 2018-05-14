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
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            List<string> rolesToAdd = new List<string> { "Admin", "Owner", "Consumer" };

            foreach (string role in rolesToAdd)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }
        }
    }
}
