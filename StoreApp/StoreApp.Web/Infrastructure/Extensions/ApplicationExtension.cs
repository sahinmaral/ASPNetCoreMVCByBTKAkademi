using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Repositories;

namespace StoreApp.Web.Infrastructure.Extensions;

public static class ApplicationExtension
{

    public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
    {
        StoreAppDbContext context = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<StoreAppDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    public static async void ConfigureDefaultUserHasAdminRole(this IApplicationBuilder app)
    {
        var username = "admin";
        var password = "Abc1234.";

        UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

        RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        IdentityUser? user = await userManager.FindByNameAsync(username);
        if(user is null)
        {
            user = new IdentityUser()
            {
                Email = "sahinmaral@hotmail.com",
                PhoneNumber = "2122161896",
                UserName =  username
            };

            string errorMessage = "";

            var result = await userManager.CreateAsync(user,password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {

                    errorMessage += $"{error.Description}{Environment.NewLine}";
                }
                throw new Exception(errorMessage);
            }
            else
            {
                var roleResult = await userManager.AddToRolesAsync(user,roleManager.Roles.Select(x => x.Name).ToList());

                if(!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {

                        errorMessage += $"{error.Description}{Environment.NewLine}";
                    }
                    throw new Exception(errorMessage);
                }
            }


        }
    }
}