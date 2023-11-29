namespace Gent.Web.Infrastructure.ServiceCollectionExtensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddIntegrationConfigurations(this WebApplicationBuilder builder)
        {
            builder.Services.AddIntegrationConfigurations(builder.Configuration);
            return builder;
        }
        
        public static IServiceCollection AddIntegrationConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            SD.ProductAPI = configuration.GetSection("ServiceUrls").GetValue<string>("ProductAPI");
            return services;
        }
    }
}
