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

            

            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //string userPWD;

            //var user = new ApplicationUser();
            //user.UserName = "tjprange11";
            //user.Email = "tjprange11@gmail.com";
            //userPWD = "RoCkS=13";

            //if (UserManager.Create(user, userPWD).Succeeded)
            //{
            //    UserManager.AddToRole(user.Id, "Admin");
            //}

            //user = new ApplicationUser();
            //user.UserName = "SlyFiye";
            //user.Email = "austin.pichler@gmail.com";
            //userPWD = "Password100.";

            //if (UserManager.Create(user, userPWD).Succeeded)
            //{
            //    UserManager.AddToRole(user.Id, "Admin");
            //}

            //user = new ApplicationUser();
            //user.UserName = "Air-Ick";
            //user.Email = "EHenderson421@gmail.com";
            //userPWD = "Password100.";

            //if (UserManager.Create(user, userPWD).Succeeded)
            //{
            //    UserManager.AddToRole(user.Id, "Admin");
            //}
        }
    }
}
