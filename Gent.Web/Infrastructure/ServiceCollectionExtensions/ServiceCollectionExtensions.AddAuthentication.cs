namespace Gent.Web.Infrastructure.ServiceCollectionExtensions
{
    public partial class ServiceCollectionExtensions
    {

        public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(builder.Configuration);
            return builder;
        }
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";

            })
                .AddCookie(opt =>
                {
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                })
                .AddOpenIdConnect("oidc", opt =>
                {
                    opt.Authority = configuration["ServiceUrls:IdentityApi"];
                    opt.GetClaimsFromUserInfoEndpoint = true;
                    opt.ClientId = "mango";
                    opt.ClientSecret = "secret";
                    opt.ResponseType = "code";
                    opt.TokenValidationParameters.NameClaimType = "name";
                    opt.TokenValidationParameters.RoleClaimType = "role";
                    opt.Scope.Add("Mango");

                });

            return services;
        }
    }
}
