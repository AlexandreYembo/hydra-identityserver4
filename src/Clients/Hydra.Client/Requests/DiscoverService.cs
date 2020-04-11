using IdentityModel.Client;

namespace Hydra.Client.Requests
{
 
 /// <summary>
 /// Discovery Service to get the proper endpoints from Hydra Identity Server
 /// </summary>
    public class DiscoverService{
        protected readonly IBaseHttpClient _httpClient;
        public DiscoverService(IBaseHttpClient httpClient){
            _httpClient = httpClient;
        }

        public DiscoveryDocumentResponse Discovery(){
           var result =  _httpClient.GetDiscoveryDocumentAsync().Result;
           return result;
        }
    }
}