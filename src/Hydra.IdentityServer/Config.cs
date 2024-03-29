﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Hydra.IdentityServer
{
    public static class Config
    {
     
        ///Add support for the standard openid (subject id) and profile (first name, last name etc..) scopes
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            //define custom identity resources
            var customProfile = new IdentityResource(
                name: "custom.profile",
                displayName: "Custom Profile",
                claimTypes: new []{ "status, gender"}
            );

            return new List<IdentityResource>{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
                customProfile
            };
        }
        
        // public static IEnumerable<Client> Clients =>
        //     new List<Client>(){
        //         new Client{
        //             ClientId = "client",
        //             AllowedGrantTypes = GrantTypes.ClientCredentials, // no interactive user, use the clientid/secret for authentication
        //             ClientSecrets = {
        //                 new Secret("secret".Sha256()) // secret for authentication
        //             },
        //             AllowedScopes = { "hydra-api" } // scopes that client has access to
        //         },
        //         new Client{     //hydra.client.api register
        //             ClientId = "mvc",
        //             ClientSecrets = {
        //                 new Secret("secret".Sha256()) 
        //                 },
        //             AllowedGrantTypes= GrantTypes.Code,
        //             RequireConsent = false,
        //             RequirePkce = true,

        //             // where to redirect to after login
        //             RedirectUris = { "http://localhost:5002/signin-oidc" },

        //             // where to redirect to after logout
        //             PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

        //             AllowedScopes = new List<string>{
        //                 IdentityServerConstants.StandardScopes.OpenId,
        //                 IdentityServerConstants.StandardScopes.Profile,
        //                 "hydra-api"
        //             },
        //             AllowOfflineAccess = true   //enable support for refresh tokens
        //         },
        //         new Client{ //client registration to IdentityServer for the JavaScript client
        //             ClientId = "js",
        //             ClientName = "Javascript Client",
        //             AllowedGrantTypes = GrantTypes.Code,
        //             RequirePkce = true,
        //             RequireClientSecret = false,
        //             RedirectUris = { "http://localhost:5003/callback.html" },
        //             PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
        //             AllowedCorsOrigins = { "http://localhost:5003" },
                    
        //             AllowedScopes = { 
        //                 IdentityServerConstants.StandardScopes.OpenId,
        //                 IdentityServerConstants.StandardScopes.Profile,
        //                 "hydra-api"
        //             }
        //         }
        //     };
    }
}