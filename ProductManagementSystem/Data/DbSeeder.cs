using EcommerceManagementProject.Constant;
using EcommerceManagementProject.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace EcommerceManagementProject.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<UserModel>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user = new UserModel
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Ravindra",
                Address = "Noida",
                Password = "Admin@123",
                ConfirmPassword = "Admin@123",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}

