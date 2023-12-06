using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Gent.Services.ProductAPI.Infrastructure.ServiceCollectionExtensions
{
    public partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuth();
            return builder;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                    {

                        opt.Authority = "https://localhost:7036/";
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };


                    });

            return services;
        }
    }
}
