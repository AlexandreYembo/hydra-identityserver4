using System.Text;
using Hydra.IdentityServer.Extensions;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hydra.IdentityServer
{
    public static class AuthenticatorsExtension
    {
        public static void AddAuthentications(this IServiceCollection services, IConfiguration configuration)
        {
            var googleAuthentication = configuration.GetSection("googleAuthentication");
            var cookieExpiration = configuration.GetSection("cookieExpiration");

            var appSettingsSection = configuration.GetSection("AppSettings");
           services.Configure<AppSettings>(appSettingsSection);

           var appSettings = appSettingsSection.Get<AppSettings>();
           var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>{
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer
                };
            });

            //Do not remove this for now
            // services.AddAuthentication("Hydra_cookie")
            //         //Cookie customized
            //         .AddCookie("Hydra_cookie", options => {
            //             options.ExpireTimeSpan = new System.TimeSpan(cookieExpiration.GetValue<int>("hour"), cookieExpiration.GetValue<int>("minutes"), 0);
            //         })
            //         //Google Authentication configuration
            //         .AddGoogle("Google", options =>
            //         {
            //             options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //             options.ClientId = googleAuthentication.GetValue<string>("clientId");
            //             options.ClientSecret = googleAuthentication.GetValue<string>("clientSecret");
            //         });
        }
    }
}