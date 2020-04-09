using IdentityModel.Client;

namespace Hydra.Client.Requests
{
    public class CredentialsService{
        protected readonly IBaseHttpClient _httpClient;
        public CredentialsService(IBaseHttpClient httpClient){
            _httpClient = httpClient;
        }
        public void RequestCredentialsToken(string tokenEndpoint){
            var tokenRequest = _httpClient.RequestClientCredentialsTokenAsync(tokenEndpoint).Result;
           // return tokenRequest.Json;
        }
    }
}