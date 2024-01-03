using Gent.Web.Application;
using Gent.Web.Application.DTOs;
using Gent.Web.Infrastructure;
using static Gent.Web.SD;

namespace Gent.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenEndpoint _tokenEndpoint;
        public ProductService(IHttpClientFactory httpClientFactory, ITokenEndpoint tokenEndpoint) : base(httpClientFactory,tokenEndpoint)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<T> CreateProduct<T>(ProductDTO product)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = product,
                ApiUrl = SD.ProductAPI + "api/v1/products",
                AccessToken = "null"
            });
        }

        public async Task<T> DeleteProduct<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                ApiUrl = SD.ProductAPI + "api/v1/products/" + id,
                AccessToken = "null"
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                ApiUrl = SD.ProductAPI + "api/v1/products",
                AccessToken = "null"
            });
        }

        public async Task<T> GetProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                ApiUrl = SD.ProductAPI + "api/v1/products/" + id,
                AccessToken = "null"
            });
        }

        public async Task<T> UpdateProduct<T>(ProductDTO product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = product,
                ApiUrl = SD.ProductAPI + "api/v1/products",
                AccessToken = "null"
            });
        }
    }
}
