using Gent.Services.Identity.Initializer;

namespace Gent.Services.Identity.Infrastructure.ServiceCollectionExtensions
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
            services.AddScoped<IDbInitializer, DbInitializer>();
            return services;
        }
    }
}
