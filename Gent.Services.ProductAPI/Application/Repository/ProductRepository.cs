using AutoMapper;
using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Services.ProductAPI.Domain.Models;
using Gent.Services.ProductAPI.Infrastructure.ProductDbContext;
using Microsoft.EntityFrameworkCore;

namespace Gent.Services.ProductAPI.Application.Repository
{
    public class ProductRepository : IProductRespository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly ILogger<ProductRepository> _logger;    
        public ProductRepository(ApplicationDbContext context, IMapper mapper, ILogger<ProductRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<BaseResponse> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);
            if(product is not null && product.Id > 0)
            {
                _context.Products.Update(product);
            }

            else
            {
                await _context.Products.AddAsync(product);
            }

            await _context.SaveChangesAsync();
            return new BaseResponse() { HasSucceded = true };
        }

        public async Task<BaseResponse> DeleteProduct(int id)
        {
            var product = await _context.Products.Where(d => d.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return new BaseResponse() { HasSucceded = false, ErrorResponse = new BaseErrorResponse() { ErrorMessage = "Product Not found" } };
            }

            product.IsDeleted = true;

            _context.Products.Update(product);
            var result = await _context.SaveChangesAsync() > 0;
            return new BaseResponse() { HasSucceded = result };
        }

        public async Task<BaseResponse> Get(int id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return new BaseResponse() { HasSucceded = true, Result = product };
        }

        public async Task<BaseResponse> GetAll()
        {
            var products = await _context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.CategoryName,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            }).ToListAsync();


            return new BaseResponse() { HasSucceded = true, Result = products };
        }
    }
}
