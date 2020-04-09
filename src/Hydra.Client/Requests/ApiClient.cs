using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Hydra.Client.Requests
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetAsync();
    }
    public class ApiClient : IApiClient{
        protected HttpClient _client;
        protected string _url;
        public ApiClient(string url, string token){
            _client = new HttpClient();
            _client.SetBearerToken(token);
            _url = url;
        }

        public async Task<HttpResponseMessage> GetAsync(){
            HttpResponseMessage response = await _client.GetAsync($"{_url}/identity");
            return response;
        }
    }
}