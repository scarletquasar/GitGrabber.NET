using System.Collections.Generic;
using System.Text.Json.Serialization;
using GitGrabber.Components;

namespace GitGrabber.Models {
    public class GithubGist {
        public string url { get; set; }
        public string forks_url { get; set; }
        public string commits_url { get; set; }
        public string id { get; set; }
        public string node_id { get; set; }
        public string git_pull_url { get; set; }
        public string git_push_url { get; set; }
        public string html_url { get; set; }
        public Dictionary<string, Dictionary<string, dynamic>> files { get; set; }
        public bool @public { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string description { get; set; }
        public int comments { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string user { get; set; }
        public string comments_url { get; set; }
        public GithubUser owner { get; set; }
        public bool truncated { get; set; }
    }
}