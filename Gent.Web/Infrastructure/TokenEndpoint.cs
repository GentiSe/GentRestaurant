using Microsoft.AspNetCore.Authentication;

namespace Gent.Web.Infrastructure
{
    public interface ITokenEndpoint
    {
        Task<string> GetAccessToken();
        Task<string> GetRefreshTokenAsync(string refreshToken);
    }
    public class TokenEndpoint : ITokenEndpoint
    {
        private readonly IHttpContextAccessor _accessor;

        public TokenEndpoint(IHttpContextAccessor httpContextAccessor)
        {
                _accessor = httpContextAccessor;
        }
        public async Task<string> GetAccessToken()
        {
            var accessToken = string.Empty;

            // Get the current HttpContext to access the tokens
            var currentContext = _accessor.HttpContext;
            if(currentContext != null)
            {
                // Get expires_at value to check if should we renew access & refresh tokens?
                var expiresAt = await currentContext.GetTokenAsync("expires_at");

                if (expiresAt == null)
                    return accessToken;

                // Convert UTC DateTime to LocalDateTime
                expiresAt = DateTime.Parse(expiresAt).ToLocalTime().ToString();

                // Compare - make sure to use the exact date formats for comparison
                if (string.IsNullOrWhiteSpace(expiresAt) || (DateTime.Parse(expiresAt).AddSeconds(-300) < DateTime.Now))
                {
                    // Get current refresh_token to request new access_token
                    var currentRefreshToken = await currentContext.GetTokenAsync("refresh_token");

                    accessToken = await GetRefreshTokenAsync(currentRefreshToken);
                }
                else
                {
                    // Get access_token
                    accessToken = await currentContext?.GetTokenAsync("access_token");
                }

                currentContext.Response.Cookies.Append("access_token", accessToken, new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(1),
                });

            }

            return accessToken;

        }

        public async Task<string> GetRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
