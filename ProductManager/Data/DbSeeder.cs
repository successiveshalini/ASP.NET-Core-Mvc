using CustomIdentity.Constants;
using Microsoft.AspNetCore.Identity;


namespace CustomIdentity.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));


            //creating Admin 
            var user = new ApplicationUser()
            {
                UserName = "shalinikumari",
                Email = "shalini@admin.com",
                Name = "Shalini",
                Address = "Noida Sector126",
                PhoneNumber = "No",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                


            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);  
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@1234");
                await userManager.CreateAsync(user, Roles.Admin.ToString());
            }
        }

        

    }
}
