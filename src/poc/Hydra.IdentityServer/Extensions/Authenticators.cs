using IdentityServer4;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.IdentityServer
{
    public static class Authenticators
    {
        public static void AddAuthentications(this IServiceCollection services)  => 
            services.AddAuthentication()
                    .AddGoogle("Google", options =>{
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.ClientId = "<insert here>";
                        options.ClientSecret = "<insert here>";
                    });
    }
}