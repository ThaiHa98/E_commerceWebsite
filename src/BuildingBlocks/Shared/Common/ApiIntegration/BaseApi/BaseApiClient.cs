using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared.Common.Constants;
using Shared.SeedWork;
using System.Text;

namespace Shared.Common.ApiIntegration
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BaseApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ApiResult<T>> GetAsync<T>(string url, string clientId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.ApiGateWay]);
            if (!string.IsNullOrEmpty(clientId))
            {
                client.DefaultRequestHeaders.Add("clientId", clientId);
            }
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<T>>(body);
        }

        public async Task<ApiResult<T>> GetAsync<T>(string baseAddress, string url, string clientId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);
            if (!string.IsNullOrEmpty(clientId))
            {
                client.DefaultRequestHeaders.Add("clientId", clientId);
            }
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<T>>(body);
        }

        public async Task<ApiResult<string>> PostAsync<T>(string baseAddress, string url, T requestContent, string clientId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress);
            if (!string.IsNullOrEmpty(clientId))
            {
                client.DefaultRequestHeaders.Add("clientId", clientId);
            }
            StringContent httpContent = null;
            if (requestContent != null)
            {
                var json = JsonConvert.SerializeObject(requestContent);
                httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResult<string>>(body);
        }
    }
}
