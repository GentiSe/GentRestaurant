using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Web.Application.DTOs;
using Gent.Web.Infrastructure.Helpers;
using Gent.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var products = new List<ProductDTO>();
            var response = await _productService.GetAllProductsAsync<BaseResponse>();
            if (response.HasSucceded)
            {
                products = JsonSerializer.Deserialize<List<ProductDTO>>(Convert.ToString(response.Result), JsonHelpers.JsonOptions());
            }
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO request)
        {
            var response = await _productService.CreateProduct<BaseResponse>(request);
            if (response.HasSucceded)
            {
                return RedirectToAction("Index"); 
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _productService.GetProductAsync<BaseResponse>(id);

            if (response.HasSucceded)
            {
                var product = JsonSerializer.Deserialize<ProductDTO>(Convert.ToString(response.Result), JsonHelpers.JsonOptions());
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductDTO request)
        {
            var response = await _productService.UpdateProduct<BaseResponse>(request);
            if (response.HasSucceded)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost()]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest("Id should be provided");

            var response = await _productService.DeleteProduct<BaseResponse>(id);
            if (response.HasSucceded)
            {
                return RedirectToAction("Index");
            }
            return View(id);
        }
    }
}
