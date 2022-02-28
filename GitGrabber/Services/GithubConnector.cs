using GitGrabber.Abstractions.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace GitGrabber.Services
{
    public class GithubConnector : IGithubConnector
    {
        private readonly HttpClient _httpClient;

        public GithubConnector()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitGrabber Client v2.0");
        }
        public T Get<T>(string route, string username, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{token}")));

            var response = _httpClient.GetAsync(route).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(responseString);
            }

            throw new HttpRequestException
                ($"{Properties.Resources.ConnectionError}({route}) => {response.Content.ReadAsStringAsync().Result}");
        }

        public async Task<T> GetAsync<T>(string route, string username, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{token}")));

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = await responseContent.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseString);
            }

            throw new HttpRequestException
                ($"{Properties.Resources.ConnectionError}({response.StatusCode}) => {await response.Content.ReadAsStringAsync()}");
        }
    }
}
