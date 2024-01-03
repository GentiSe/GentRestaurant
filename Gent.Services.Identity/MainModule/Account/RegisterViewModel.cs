using System.ComponentModel.DataAnnotations;

namespace Gent.Services.Identity.MainModule.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }
        public string? RoleName { get; set; }
        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; }
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();

        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string? ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.FirstOrDefault()?.AuthenticationScheme : null;
    }
}
