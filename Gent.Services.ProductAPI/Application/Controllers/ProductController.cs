using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Services.ProductAPI.Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gent.Services.ProductAPI.Application.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRespository _repository;
        public ProductController(IProductRespository respository)
        {
                
            _repository = respository;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]int id)
        {
            if (id is 0)
                return BadRequest("Id must be provided");

            return Ok(await _repository.Get(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id is 0)
                return BadRequest("Id must be provided");

            return Ok(await _repository.DeleteProduct(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            if (product is null)
                return BadRequest("Product data must be provided");

            return Ok(await _repository.CreateUpdateProduct(product));

        }
    }
}