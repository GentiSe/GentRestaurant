using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Web.Application.DTOs;
using Gent.Web.Infrastructure.Helpers;
using Gent.Web.Models;
using Gent.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Gent.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;


        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
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

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var model = new ProductDTO();
            var response = await _productService.GetProductAsync<BaseResponse>(id);
            if(response.HasSucceded)
            {
                model = JsonSerializer.Deserialize<ProductDTO>(Convert.ToString(response.Result), JsonHelpers.JsonOptions());
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}