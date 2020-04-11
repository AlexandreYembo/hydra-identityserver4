using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Hydra.Client.Requests
{
    public interface IBaseHttpClient
    {
        Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync();
        Task<TokenResponse> RequestClientCredentialsTokenAsync(string tokenEndpoint);
    }
    public class BaseHttpClient : IBaseHttpClient{
        protected HttpClient _client;
        protected string _url;
        public BaseHttpClient(string url){
            _client = new HttpClient();
            _url = url;
        }

        public async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(){
            DiscoveryDocumentResponse response = await _client.GetDiscoveryDocumentAsync(_url);
            return response;
        }

          public async Task<TokenResponse> RequestClientCredentialsTokenAsync(string tokenEndpoint){
            TokenResponse response = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest{
                Address = tokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "hydra-api"
            });
            return response;
        }
    }
}