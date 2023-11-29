using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gent.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllProductsAsync<BaseResponse>();
            return View(response);
        }
    }
}
