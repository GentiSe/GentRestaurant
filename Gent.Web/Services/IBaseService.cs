using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Web.Application;

namespace Gent.Web.Services
{
    public interface IBaseService:IDisposable
    {
        BaseResponse _baseResponse { get; set; }
        Task<T> SendAsync<T>(ApiRequest request);

    }
}
