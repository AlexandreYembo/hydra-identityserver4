// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Hydra.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource> 
            {  
                new ApiResource("hydra-api", "Hydra Identity Api")
            };
        
        public static IEnumerable<Client> Clients =>
            new List<Client>(){
                new Client{
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // no interactive user, use the clientid/secret for authentication
                    ClientSecrets = {
                        new Secret("secret".Sha256()) // secret for authentication
                    },
                    AllowedScopes = { "hydra-api" } // scopes that client has access to
                }
            };
    }
}