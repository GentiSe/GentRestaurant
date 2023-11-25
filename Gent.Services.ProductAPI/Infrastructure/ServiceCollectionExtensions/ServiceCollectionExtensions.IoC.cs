using Gent.Services.ProductAPI.Application.Repository;

namespace Gent.Services.ProductAPI.Infrastructure.ServiceCollectionExtensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddIoC(this WebApplicationBuilder builder)
        {
            builder.Services.ADdIoC();
            return builder;
        }

        public static IServiceCollection ADdIoC(this IServiceCollection services)
        {
            services.AddScoped<IProductRespository, ProductRepository>();
            return services;
        }
    }
}
