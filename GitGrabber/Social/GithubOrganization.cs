using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Social;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitGrabber.Social
{
    public class GithubOrganization : IGithubOrganization
    {
        public IGithubConnection Connection;

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; }

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; set; }

        [JsonPropertyName("hooks_url")]
        public string HooksUrl { get; set; }

        [JsonPropertyName("issues_url")]
        public string IssuesUrl { get; set; }

        [JsonPropertyName("members_url")]
        public string MembersUtl { get; set; }

        [JsonPropertyName("public_members_url")]
        public string PublicMembersUrl { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("is_verified")]
        public bool IsVerified { get; set; }

        [JsonPropertyName("has_organization_projects")]
        public bool? HasOrganizationProjects { get; set; }

        [JsonPropertyName("has_repository_projects")]
        public bool? HasRepositoryProjects { get; set; }

        [JsonPropertyName("public_repos")]
        public int PublicRepositoriesCount { get; set; }

        [JsonPropertyName("public_gists")]
        public int PublicGistsCount { get; set; }

        [JsonPropertyName("followers")]
        public int FollowersCount { get; set; }

        [JsonPropertyName("following")]
        public int FollowingCount { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        public IEnumerable<IGithubRepository> GetRepos()
        {
            return Connection.GetUserRepositories(Login);
        }

        public async Task<IEnumerable<IGithubRepository>> GetReposAsync()
        {
            return await Connection.GetUserRepositoriesAsync(Login);
        }
    }
}
