using Gent.Services.ProductAPI.Application.DTOs;

namespace Gent.Services.ProductAPI.Application.Repository
{
    public interface IProductRespository
    {
        Task<BaseResponse> GetAll();
        Task<BaseResponse> Get(int id);
        Task<BaseResponse> CreateUpdateProduct(ProductDto productDto);
        Task<BaseResponse> DeleteProduct (int id);
    }
}
