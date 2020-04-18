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
            var cookieExpiration = configuration.GetSection("cookieExpiration");
            services.AddAuthentication("Hydra_cookie")
                    //Cookie customized
                    .AddCookie("Hydra_cookie", options => {
                        options.ExpireTimeSpan = new System.TimeSpan(cookieExpiration.GetValue<int>("hour"), cookieExpiration.GetValue<int>("minutes"), 0);
                    })
                    //Google Authentication configuration
                    .AddGoogle("Google", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.ClientId = googleAuthentication.GetValue<string>("clientId");
                        options.ClientSecret = googleAuthentication.GetValue<string>("clientSecret");
                    });
        }
    }
}