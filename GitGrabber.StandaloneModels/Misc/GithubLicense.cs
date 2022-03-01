using System.Text.Json.Serialization;

namespace GitGrabber.StandaloneModels.Misc
{
    public class GithubLicense
    {
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("spdx_id")]
        public string? LicenseId { get; set; }

        [JsonPropertyName("url")]
        public string? LicenseUrl { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }
    }
}
