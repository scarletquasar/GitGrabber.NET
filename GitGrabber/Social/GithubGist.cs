using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Social;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitGrabber.Social
{
    public class GithubGist : IGithubGist
    {
        public IGithubConnection Connection;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("forks_url")]
        public string ForksUrl { get; set; }

        [JsonPropertyName("commits_url")]
        public string CommitsUrl { get; set; }

        [JsonPropertyName("id")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("git_pull_url")]
        public string GitPullUrl { get; set; }

        [JsonPropertyName("git_push_url")]
        public string GitPushUrl { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("files")]
        public Dictionary<string, Dictionary<string, dynamic>> Files { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("comments")]
        public int Comments { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonPropertyName("owner")]
        public GithubUser Owner { get; set; }

        [JsonPropertyName("truncated")]
        public bool Truncated { get; set; }

        public IGithubUser GetOwner()
        {
            return Connection.GetUser(Owner.Login);
        }

        public async Task<IGithubUser> GetOwnerAsync()
        {
            return await Connection.GetUserAsync(Owner.Login);
        }
    }
}
