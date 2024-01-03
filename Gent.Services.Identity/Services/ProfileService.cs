using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Gent.Services.Identity.Application.Domain;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Gent.Services.Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaims;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProfileService(IUserClaimsPrincipalFactory<ApplicationUser> userClaims,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager
            )
        {
                _roleManager = roleManager;
                _userClaims = userClaims;
                _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(sub);
            var userClaims = await _userClaims.CreateAsync(user);

            var claims = userClaims.Claims.ToList();
            claims = claims.Where(d => context.RequestedClaimTypes.Contains(d.Type)).ToList(); ;

            if (_userManager.SupportsUserRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Any())
                {
                    foreach(var role in roles)
                    {
                        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.Role, role));
                        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.FamilyName, user.LastName));
                        claims.Add(new System.Security.Claims.Claim(JwtClaimTypes.GivenName, user.FirstName));

                        if (_roleManager.SupportsRoleClaims)
                        {
                            var identityRole = await _roleManager.FindByNameAsync(role);
                            if(identityRole != null)
                            {
                                claims.AddRange(await _roleManager.GetClaimsAsync(identityRole)); 
                            }
                        }
                    }
                }
            }

            context.IssuedClaims = claims;

        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();

            var isActive = await _userManager.FindByIdAsync(sub) != null;
        }
    }
}
