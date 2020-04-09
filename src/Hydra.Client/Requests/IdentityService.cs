using IdentityModel.Client;

namespace Hydra.Client.Requests
{
    /// <summary>
    /// Class to get the user identity from the Hydra Auth API
    /// </summary>
    public class IdentityService{
        protected readonly IApiClient _apiClient;
        public IdentityService(IApiClient apiClient){
            _apiClient = apiClient;
        }

        public string Get(){
           var response =  _apiClient.GetAsync().Result;
           return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : null;
        }
    }
}