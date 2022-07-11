using GameShop.Models.Service.Interface;
using Microsoft.AspNetCore.Identity;

namespace GameShop.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            string adminEmail = "admin_6@gmail.com";
            string password = "Qwerty123!_";
            string managerEmail = "manager_07@gmail.com";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("manager"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                    await userManager.ConfirmEmailAsync(admin,
                        await userManager.GenerateEmailConfirmationTokenAsync(admin));
                    await userService.Create(new Models.Entity.User { Identity = admin.Id, Name = "Admin" });
                }
            }
            if (await userManager.FindByNameAsync(managerEmail) == null)
            {
                IdentityUser manager = new IdentityUser { Email = managerEmail, UserName = managerEmail };
                IdentityResult result = await userManager.CreateAsync(manager, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(manager, "Manager");
                    await userManager.ConfirmEmailAsync(manager,
                        await userManager.GenerateEmailConfirmationTokenAsync(manager));
                    await userService.Create(new Models.Entity.User { Identity = manager.Id, Name = "Manager" });
                }
            }
        }
    }
}
