using Microsoft.AspNetCore.Identity;

namespace Gent.Services.Identity.Application.Domain
{
    public class ApplicationUser:IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
