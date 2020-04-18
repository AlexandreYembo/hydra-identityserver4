using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Hydra.IdentityServer.Seeds
{
    public class Clients
    {
        public static IEnumerable<Client> Get() => 
        new List<Client> {
            // no interactive user is present - a service (aka client) wants to communicate with an API (aka scope):
            new Client 
            {
                ClientId = "86b90b75-b924-4928-a7cb-4c5b63b71b20",
                ClientName = "Basket API",
                ClientSecrets = {
                    new Secret("86b90b75-b924-4928-a7cb-4c5b63b71b20".Sha256()) 
                },
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                AllowedScopes = { "hydra-api", "hydra-api2.read_only" }
            },
            //Client based on SPA
            // new Client
            // { 
            //     ClientId = "7d84d81e-b63d-4642-a357-fef5203dc2d8",
            //     ClientName = "Hydra Administrator",
            //     ClientUri = "http://localhost:5003",
            //     AllowedGrantTypes = GrantTypes.Implicit,
            //     AllowAccessTokensViaBrowser = true,
            //     RedirectUris = { "http://localhost:5003/index.html" }, 
            //     PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
            //     AllowedCorsOrigins = { "http://localhost:5003" },
            //     AllowedScopes = {
            //         IdentityServerConstants.StandardScopes.OpenId, 
            //         IdentityServerConstants.StandardScopes.Profile, 
            //         IdentityServerConstants.StandardScopes.Email,
            //         "hydra-api", "hydra-api2.read_only"
            //     }
            // },
            new Client{ //client registration to IdentityServer for the JavaScript client
                    ClientId = "7d84d81e-b63d-4642-a357-fef5203dc2d8",
                    ClientName = "Hydra Administrator",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = { "http://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins = { "http://localhost:5003" },
                    
                    AllowedScopes = { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "hydra-api", "hydra-api2.read_only"
                    }
                }
        };
    }
}