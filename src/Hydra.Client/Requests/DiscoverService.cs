using IdentityModel.Client;

namespace Hydra.Client.Requests
{
    public class DiscoverService{
        protected readonly IBaseHttpClient _httpClient;
        public DiscoverService(IBaseHttpClient httpClient){
            _httpClient = httpClient;
        }

        public DiscoveryDocumentResponse Discovery(){
           var result =  _httpClient.GetDiscoveryDocumentAsync().Result;
           return result;
        }

        public void RequestCredentialsToken(string tokenEndpoint){
            
        }
    }
}