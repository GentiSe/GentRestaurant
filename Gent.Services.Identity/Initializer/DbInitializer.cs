using Gent.Services.Identity.Application.Domain;
using Gent.Services.Identity.Application.IdentityDatabaseContext;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Gent.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IdentityContext _conntext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(IdentityContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _conntext = context;   
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Initialize()
        {
            if (await _roleManager.FindByNameAsync(SD.Admin) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.Admin));
                await _roleManager.CreateAsync(new IdentityRole(SD.Customer));
            }
        

            var adminUser = new ApplicationUser
            {
                UserName = "gentselimi7@gmail.com",
                Email = "gentselimi7@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "044352799",
                FirstName = "gent",
                LastName = "selimi"
            };

            await _userManager.CreateAsync(adminUser, "admin123");
            await _userManager.AddToRoleAsync(adminUser, SD.Admin);

            await _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName +  " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.LastName +  " " + adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, SD.Admin)
            });


        }
    }
}
