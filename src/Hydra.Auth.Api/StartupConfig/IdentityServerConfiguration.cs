using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Auth.Api.StartupConfig
{
    /* add the authentication services to DI (dependency injection) and the authentication middleware to the pipeline. These will:
• validate the incoming token to make sure it is coming from a trusted issuer
• validate that the token is valid to be used with this api (aka audience) */
  
    public class IdentityServerConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options => {
                options.Authority = "http://localhost:5000";   // host used for the identity server
                options.RequireHttpsMetadata = false;
                options.Audience = "hydra-api";     //API resource name defined in Identity service
            });
        }
    }
}
