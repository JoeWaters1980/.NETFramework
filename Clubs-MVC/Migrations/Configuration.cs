namespace Clubs_MVC.Migrations
{
    using Clubs_MVC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Clubs_MVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Clubs_MVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            {
                var manager =
                    new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(context));

                var roleManager =
                    new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(context));

                context.Roles.AddOrUpdate(r => r.Name,
                    new IdentityRole { Name = "Admin" }
                    );
                context.Roles.AddOrUpdate(r => r.Name,
                    new IdentityRole { Name = "ClubAdmin" }
                    );
                context.Roles.AddOrUpdate(r => r.Name,
                    new IdentityRole { Name = "member" }
                    );

                PasswordHasher ps = new PasswordHasher();

                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = "powell.paul@itsligo.ie",
                        Email = "powell.paul@itsligo.ie",
                        EmailConfirmed = true,
                        JoinDate = DateTime.Now,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        FirstName = "Paul",
                        Surname = "Powell",
                        PasswordHash = ps.HashPassword("Rad3022021$1")
                    });

                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = "radp2016@outlook.com",
                        Email = "radp2016@outlook.com",
                        EmailConfirmed = true,
                        JoinDate = DateTime.Now,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        FirstName = "Rad",
                        Surname = "Paulner",
                        PasswordHash = ps.HashPassword("radP2016$1")
                    });
                context.SaveChanges();

                ApplicationUser admin = manager.FindByEmail("powell.paul@itsligo.ie");
                if (admin != null)
                {
                    manager.AddToRoles(admin.Id, new string[] { "Admin", "member", "ClubAdmin" });
                }
            }
        }
    }
}

