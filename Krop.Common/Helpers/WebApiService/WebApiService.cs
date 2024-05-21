

using Microsoft.Extensions.Configuration;

namespace Krop.Common.Helpers.WebApiService
{
    public class WebApiService : IWebApiService
    {
        private readonly HttpClient _httpClient;
        public WebApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7117/api/");
        }
        public HttpClient httpClient => _httpClient;
    }
}
