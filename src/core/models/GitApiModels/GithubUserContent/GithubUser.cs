using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GitGrabber.Components;

namespace GitGrabber.Models {
    public class GithubUser {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }      
        public string type { get; set; } 
        public bool site_admin { get; set; } = false;
        public string name { get; set; }
        public string company { get; set; }
        public string blog { get; set; }
        public string location { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string email { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? hireable { get; set; }
        public string bio { get; set; }
        public string twitter_username { get; set; }
        public int public_repos { get; set; }
        public int public_gists { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public double score { get; set; }

        /* Built-in dynamic data retrieval features */
        public async Task<List<GithubUser>> GetFollowers() {
            return (await PublicFetchOperation.Fetch("UserList", $"https://api.github.com/users/{login}/followers"));
        }
        public async Task<List<GithubRepo>> GetRepos() {
            return (await PublicFetchOperation.Fetch("RepoList", $"https://api.github.com/users/{login}/repos"));
        }

        public async Task<List<GithubOrg>> GetOrgs() {
            return (await PublicFetchOperation.Fetch("OrgList", $"https://api.github.com/users/{login}/orgs"));
        }

        public async Task<List<GithubGist>> GetGists() {
            return (await PublicFetchOperation.Fetch("GistList", $"https://api.github.com/users/{login}/gists"));
        }
    }
}