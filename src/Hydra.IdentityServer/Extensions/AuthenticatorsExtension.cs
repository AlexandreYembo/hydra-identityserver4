using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.IdentityServer
{
    public static class AuthenticatorsExtension
    {
        public static void AddAuthentications(this IServiceCollection services, IConfiguration configuration)
        {
            var googleAuthentication = configuration.GetSection("googleAuthentication");
            services.AddAuthentication()
                    .AddGoogle("Google", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.ClientId = googleAuthentication.GetSection("clientId").Value;
                        options.ClientSecret = googleAuthentication.GetSection("clientSecret").Value;
                    });
        }
    }
}