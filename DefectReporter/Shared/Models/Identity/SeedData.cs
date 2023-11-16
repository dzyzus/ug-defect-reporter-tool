using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectReporter.Shared.Models.Identity
{
    public class SeedData
    {
        public async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string roleName = "Admin";
                IdentityResult roleResult;

                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }

                ApplicationUser user = await userManager.FindByEmailAsync("dzyzusek@gmail.com");

                if (user == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = "dzyzusek@gmail.com",
                        Email = "dzyzusek@gmail.com",
                    };
                    await userManager.CreateAsync(user, "ToChange123!");

                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
