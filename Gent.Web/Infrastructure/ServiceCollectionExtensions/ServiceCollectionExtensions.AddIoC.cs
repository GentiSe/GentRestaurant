using Gent.Web.Services;

namespace Gent.Web.Infrastructure.ServiceCollectionExtensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddIoC(this WebApplicationBuilder builder)
        {
            builder.Services.AddIoC();
            return builder;
        }

        public static IServiceCollection AddIoC(this  IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITokenEndpoint, TokenEndpoint>();

            return services;
        }
    }
}
