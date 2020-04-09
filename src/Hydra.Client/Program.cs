using System;
using System.Net.Http;
using Hydra.Client.Requests;
using IdentityModel.Client;

namespace Hydra.Client
{
    class Program
    {
        static void Main(string[] args)
        {
         //   var client = new HttpClient();

            IBaseHttpClient _httpClient = new BaseHttpClient("http://localhost:5000");
            //Discover endpoints from metada
            var discoveryService = new DiscoverService(_httpClient);
            var discovery = discoveryService.Discovery();
            var credentialsService = new CredentialsService(_httpClient);
            credentialsService.RequestCredentialsToken(discovery.TokenEndpoint);
        }
    }
}
