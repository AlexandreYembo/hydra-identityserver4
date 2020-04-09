using IdentityModel.Client;

namespace Hydra.Client.Requests
{
   /// <summary>
   /// Get the credentials from the Identity Server, based on ClientId, client secret
   /// </summary>
    public class CredentialsService{
        protected readonly IBaseHttpClient _httpClient;
        public CredentialsService(IBaseHttpClient httpClient){
            _httpClient = httpClient;
        }
    
        /// <summary>
        /// Get the Credential token based on the token endpoint from Hydra Identity Server
        /// </summary>
        /// <param name="tokenEndpoint"></param>
        public string RequestCredentialsToken(string tokenEndpoint){
            var tokenRequest = _httpClient.RequestClientCredentialsTokenAsync(tokenEndpoint).Result;
            return tokenRequest.AccessToken;
        }
    }
}