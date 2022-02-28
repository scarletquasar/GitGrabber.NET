using GitGrabber.Abstractions.Activity;
using GitGrabber.Abstractions.Connections;
using GitGrabber.Social;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GitGrabber.Activity
{
    public class GithubCommit : IGithubCommit
    {
        public IGithubConnection Connection { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonPropertyName("commit")]
        public GithubCommit Commit { get; set; }

        [JsonPropertyName("author")]
        public GithubUser Author { get; set; }

        [JsonPropertyName("commiter")]
        public GithubUser Commiter { get; set; }

        [JsonPropertyName("parents")]
        public List<GithubCommit> Parents { get; set; }
    }
}
