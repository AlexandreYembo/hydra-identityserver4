using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Hydra.IdentityServer.Seeds
{
    public class ApiResources
    {
           public static IEnumerable<ApiResource> Get(){
            return  new List<ApiResource> 
                    {
                        new ApiResource("hydra-api", "Hydra Identity Api"),
                        new ApiResource
                        {
                            Name = "hydra-api2",
                            Description = "Hydra Identity Api",
                            ApiSecrets = { new Secret("hydra-secret".Sha256())},
                            //include the following using claims in access token
                            UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },
                            // this API defines two scopes
                            Scopes = {
                                new Scope() { Name =  "hydra-api2.full_access", DisplayName = "Full access to Hydra API" },
                                new Scope() { Name = "hydra-api2.read_only", DisplayName = "Read only access to Hydra API"}
                            }
                        }
                    };
        }
    }
}