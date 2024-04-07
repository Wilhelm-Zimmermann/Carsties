using System.Security.Claims;
using IdentityModel;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityService;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if(userMgr.Users.Any())
            {
                return;
            }

            var will = userMgr.FindByNameAsync("will").Result;
            if (will == null)
            {
                will = new ApplicationUser
                {
                    UserName = "will",
                    Email = "will@gmail.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(will, "Will123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(will, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Will Zim"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("Will created");
            }
            else
            {
                Log.Debug("will already exists");
            }
        }
    }
}
