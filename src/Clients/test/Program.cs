using System;
using Hydra.Client.Requests;
using Newtonsoft.Json.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME - THIS CONSOLE WILL TEST YOUR REQUEST BY USING IDENTITY SERVER 4");

            IBaseHttpClient _httpClient = new BaseHttpClient("http://localhost:5000");
            //Discover endpoints from metada
            var discoveryService = new DiscoverService(_httpClient);
            var discovery = discoveryService.Discovery();
            var credentialsService = new CredentialsService(_httpClient);
            Console.WriteLine($"TOKEN ENDPOINT: {discovery.TokenEndpoint}");

            string token = credentialsService.RequestCredentialsToken(discovery.TokenEndpoint);

            Console.WriteLine($"TOKEN: {token}");

            IApiClient _apiClient = new ApiClient("http://localhost:5001", token);
            var identityService = new IdentityService(_apiClient);
            string identityResult = identityService.Get();
            Console.WriteLine("IDENTITY RESULT: ");
            Console.WriteLine(JArray.Parse(identityResult));
        }
    }
}
