namespace TheScheduler.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheScheduler.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedAdmins(context);
            SeedOwners(context);
            SeedConsumers(context);
            SeedFacilityAddresses(context);
            SeedFacilities(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
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
        private void SeedAdmins(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            List<ApplicationUser> adminsToAdd = new List<ApplicationUser>();
            ApplicationUser userToAdd = new ApplicationUser();

            userToAdd.UserName = "admin";
            adminsToAdd.Add(userToAdd);

            for (int i = 1; i <= adminsToAdd.Count; i++)
            {
                SeedUserRole(manager, adminsToAdd[i], i, "Password100.", "Admin");
            }
        }
        private void SeedOwners(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            List<ApplicationUser> ownersToAdd = new List<ApplicationUser>();
            ApplicationUser userToAdd = new ApplicationUser();

            userToAdd.UserName = "Phil";
            ownersToAdd.Add(userToAdd);

            for (int i = 1; i <= ownersToAdd.Count; i++)
            {
                SeedUserRole(manager, ownersToAdd[i], i, "Password100.", "Owner");
            }
        }
        private void SeedConsumers(ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            List<ApplicationUser> consumersToAdd = new List<ApplicationUser>();
            ApplicationUser userToAdd = new ApplicationUser();

            userToAdd.UserName = "Frank";
            consumersToAdd.Add(userToAdd);

            for (int i = 1; i <= consumersToAdd.Count; i++)
            {
                SeedUserRole(manager, consumersToAdd[i], i, "Password100.", "Consumer");
            }
        }
        private void SeedFacilityAddresses(ApplicationDbContext context)
        {
            List<FacilityAddress> addresses = new List<FacilityAddress>();

            context.FacilityAddresses.AddOrUpdate(x => x.ID, new FacilityAddress() { ID = 1, StreetAddress = "123 Test Avenue", City = "Milwaukee", State = "WI", Country = "USA", PostalCode = "11111" });
        }
        private void SeedFacilities(ApplicationDbContext context)
        {
            context.Facilities.AddOrUpdate(x => x.ID, new Facility() { ID = 1, FacilityAddressId = 1, Name = "School Playground", OwnerId = 1, Indoor = false, Sport = "soccer" });
        }

        private void SeedUserRole(UserManager<ApplicationUser> manager, ApplicationUser user, int id, string password, string role)
        {
            if (manager.Create(user, password).Succeeded)
            {
                manager.AddToRole(user.Id, role);
            }

            ApplicationDbContext context = new ApplicationDbContext();
            switch (role)
            {
                case "Consumer":
                    context.Consumers.AddOrUpdate(x => x.ID, new Consumer() { ID = id, UserId = user.Id });
                    break;
                case "Owner":
                    context.Owners.AddOrUpdate(x => x.ID, new Owner() { ID = id, UserId = user.Id });
                    break;
                case "Admin":
                    context.Admins.AddOrUpdate(x => x.ID, new Admin() { ID = id, UserId = user.Id });
                    break;
                default:
                    break;
            }
        }
    }
}
