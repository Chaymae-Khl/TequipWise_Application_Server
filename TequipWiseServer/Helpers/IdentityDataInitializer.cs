using Microsoft.AspNetCore.Identity;
using TequipWiseServer.Models;

namespace TequipWiseServer.Helpers
{
    //this class is to create the Admin Account
    public class IdentityDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@domain.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            // Add other users similarly...
        }
    }
}
