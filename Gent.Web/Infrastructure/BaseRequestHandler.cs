using System.Net.Http;

namespace Gent.Web.Infrastructure
{
    public class BaseRequestHandler
    {
        protected static ITokenEndpoint _tokenEndpoint;

        public BaseRequestHandler(ITokenEndpoint tokenEndpoint = null)
        {
            _tokenEndpoint = tokenEndpoint;
        }

        public async Task<string> GetAccessToken()
        {
           return await _tokenEndpoint.GetAccessToken();
        }
    }
}
