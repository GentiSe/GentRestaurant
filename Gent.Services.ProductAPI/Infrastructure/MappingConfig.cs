using AutoMapper;
using Gent.Services.ProductAPI.Application.DTOs;
using Gent.Services.ProductAPI.Domain.Models;

namespace Gent.Services.ProductAPI.Infrastructure
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
