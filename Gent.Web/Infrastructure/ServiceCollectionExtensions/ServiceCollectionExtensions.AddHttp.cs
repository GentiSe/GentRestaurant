using Gent.Web.Services;

namespace Gent.Web.Infrastructure.ServiceCollectionExtensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddHttp(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttp();
            return builder;
        }

        public static IServiceCollection AddHttp(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient<IProductService, ProductService>().ConfigureHttpClient(x =>
            x.Timeout = TimeSpan.FromSeconds(30));
            return services;
        }
    }
}
