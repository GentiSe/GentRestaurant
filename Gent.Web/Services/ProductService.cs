using Gent.Web.Application;
using Gent.Web.Application.DTOs;
using static Gent.Web.SD;

namespace Gent.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<T> CreateProduct<T>(ProductDTO product)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = product,
                ApiUrl = SD.ProductApiBase + "api/products",
                AccessToken = "null"
            });
        }

        public async Task<T> DeleteProduct<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                ApiUrl = SD.ProductApiBase + "api/products/" + id,
                AccessToken = "null"
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                ApiUrl = SD.ProductApiBase + "api/products",
                AccessToken = "null"
            });
        }

        public async Task<T> GetProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                ApiUrl = SD.ProductApiBase + "api/products/" + id,
                AccessToken = "null"
            });
        }

        public async Task<T> UpdateProduct<T>(ProductDTO product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = product,
                ApiUrl = SD.ProductApiBase + "api/products",
                AccessToken = "null"
            });
        }
    }
}
