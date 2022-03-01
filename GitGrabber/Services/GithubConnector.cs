using GitGrabber.Abstractions.Services;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GitGrabber.Services
{
    public class GithubConnector : IGithubConnector
    {
        private readonly HttpClient _httpClient;

        public GithubConnector()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitGrabber Github Client v2.0");
        }

        public T Get<T>(string route, string username, string token) => GetAsync<T>(route, username, token).Result;

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
