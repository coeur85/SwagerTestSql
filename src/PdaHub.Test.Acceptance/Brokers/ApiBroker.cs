using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Net.Http;
using System.Threading.Tasks;

namespace PdaHub.Test.Acceptance.Brokers
{
    public class ApiBroker
    {
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;
        private readonly HttpClient _httpClinet;
        private readonly IRESTFulApiFactoryClient _apiFactoryClient;


        public ApiBroker()
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>();
            _httpClinet = _webApplicationFactory.CreateClient();
            _apiFactoryClient = new RESTFulApiFactoryClient(_httpClinet);
        }

        public async Task<T> GetAsync<T>(string Url) =>
            await _apiFactoryClient.GetContentAsync<T>(Url);

        public async Task<string> GetAsync(string Url) =>
            await _apiFactoryClient.GetContentStringAsync(Url);


        public async Task<T> PostAsync<T>(string Url, T content) =>
            await _apiFactoryClient.PostContentAsync(Url, content);

        public async Task<T> PostAsync<T, U>(string Url, U content) =>
           await _apiFactoryClient.PostContentAsync<U, T>(Url, content);

        public async Task<T> PutAsync<T>(string Url, T content) =>
          await _apiFactoryClient.PutContentAsync(Url, content);

        public async Task<T> PutAsync<T, U>(string Url, U content) =>
           await _apiFactoryClient.PutContentAsync<U, T>(Url, content);



    }
}
