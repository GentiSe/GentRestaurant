using Gent.Web.Application.DTOs;

namespace Gent.Web.Services
{
    public interface IProductService : IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> CreateProduct<T>(ProductDTO product);
        Task<T> UpdateProduct<T>(ProductDTO product);
        Task<T> DeleteProduct<T>(int id);
        Task<T> GetProductAsync<T>(int id);
    }
}
