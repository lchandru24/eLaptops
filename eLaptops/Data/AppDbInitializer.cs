using eLaptops.Data.Static;
using eLaptops.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Laptops
                if (!context.Laptops.Any())
                {
                    context.Laptops.AddRange(new List<Laptop>()
                    {
                        new Laptop()
                        {
                            Name = "MSI GF65",
                            Description = "Powerful Gaming Laptop",
                            Price = 849.00,
                            Quantity = 30,
                            ImageURL = "https://www.rapiddeal.net/wp-content/uploads/2020/06/61-jJDoQfOL._AC_SL1200_.jpg"
                        },
                        new Laptop()
                        {
                            Name = "MSI GL",
                            Description = "Beast Gaming Laptop",
                            Price = 1200.00,
                            Quantity = 10,
                            ImageURL = "https://th.bing.com/th/id/OIP.o4JXQ1hKPyBzg5rE2Bi-EwHaFZ?w=247&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"

                        },
                        new Laptop()
                        {
                            Name = "MSI GP",
                            Description = "Ultimate Gaming Laptop",
                            Price = 1500.00,
                            Quantity = 5,
                            ImageURL = "https://th.bing.com/th/id/OIP.3pTPFjIqzAATlxSDA1UsHAHaFj?pid=ImgDet&rs=1"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@elaptops.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@elaptops.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}
