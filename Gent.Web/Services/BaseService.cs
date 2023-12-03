using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Web.Application;
using Gent.Web.Infrastructure.Helpers;
using System.Text;
using System.Text.Json;

namespace Gent.Web.Services
{
    public class BaseService : IBaseService
    {
        public BaseResponse _baseResponse { get; set; }
        public IHttpClientFactory _httpClientFactory { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
           _baseResponse = new BaseResponse();
           _httpClientFactory = httpClientFactory;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("GentApi");
                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.ApiUrl);
                client.DefaultRequestHeaders.Clear();

                if(request.Data != null)
                {
                    message.Content = new StringContent(JsonSerializer.Serialize(request.Data), Encoding.UTF8,
                      "application/json");
                }

                message.Method = (request.ApiType)
                    switch
                {
                    SD.ApiType.POST => HttpMethod.Post,
                    SD.ApiType.GET => HttpMethod.Get,
                    SD.ApiType.PUT => HttpMethod.Put,
                    SD.ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Patch
                };

                var apiResponse = await client.SendAsync(message);
                var content = await apiResponse?.Content?.ReadAsStringAsync();
                var res = JsonSerializer.Deserialize<T>(content, JsonHelpers.JsonOptions());
                return res;
            }
            catch (Exception e)
            {
                var errorResponse = new BaseResponse()
                {
                    HasSucceded = false,
                    ErrorResponse = new BaseErrorResponse()
                    {
                        ErrorMessage = e.Message,
                    }
                };

                var res = JsonSerializer.Serialize(errorResponse);
                return JsonSerializer.Deserialize<T>(res);                
            }
        }
    }
}
