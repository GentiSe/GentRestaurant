namespace Gent.Services.ProductAPI.Infrastructure.ServiceCollectionExtensions
{
    public partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();
            return builder;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("ApiScope", opt =>
                {
                    opt.RequireAuthenticatedUser();
                    opt.RequireClaim("scope", "gent");

                });
            });

            return services;
        }
    }
}
