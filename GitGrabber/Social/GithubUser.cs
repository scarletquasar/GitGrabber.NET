using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Social;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitGrabber.Social
{
    public class GithubUser : IGithubUser
    {
        public IGithubConnection Connection;

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("followers_url")]
        public string FollowersUrl { get; set; }

        [JsonPropertyName("following_url")]
        public string FollowingUrl { get; set; }

        [JsonPropertyName("gists_url")]
        public string GistsUrl { get; set; }

        [JsonPropertyName("starred_url")]
        public string StarredUrl { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string SubscriptionsUrl { get; set; }

        [JsonPropertyName("organizations_url")]
        public string OrganizationsUrl { get; set; }

        [JsonPropertyName("repos_url")]
        public string ReposUrl { get; set; }

        [JsonPropertyName("events_url")]
        public string EventsUrl { get; set; }

        [JsonPropertyName("received_events_url")]
        public string ReceivedEventsUrl { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("site_admin")]
        public bool? IsAdmin { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("blog")]
        public string Blog { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("hireable")]
        public bool? Hireable { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonPropertyName("public_repos")]
        public int PublicReposCount { get; set; }

        [JsonPropertyName("public_gists")]
        public int PublicGistsCount { get; set; }

        [JsonPropertyName("followers")]
        public long FollowersCount { get; set; }

        [JsonPropertyName("following")]
        public long FollowingCount { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public IEnumerable<IGithubUser> GetFollowers()
        {
            return Connection.GetUserFollowers(Login);
        }

        public async Task<IEnumerable<IGithubUser>> GetFollowersAsync()
        {
            return await Connection.GetUserFollowersAsync(Login);
        }

        public IEnumerable<IGithubUser> GetFollowing()
        {
            return Connection.GetUserFollowing(Login);
        }

        public async Task<IEnumerable<IGithubUser>> GetFollowingAsync()
        {
            return await Connection.GetUserFollowingAsync(Login);
        }

        public IEnumerable<IGithubRepository> GetRepositories()
        {
            return Connection.GetUserRepositories(Login);
        }

        public async Task<IEnumerable<IGithubRepository>> GetRepositoriesAsync()
        {
            return await Connection.GetUserRepositoriesAsync(Login);
        }
    }
}
