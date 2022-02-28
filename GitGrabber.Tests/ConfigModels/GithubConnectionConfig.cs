using System.Text.Json.Serialization;

namespace GitGrabber.Tests.ConfigModels
{
    public class GithubConnectionConfig
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
