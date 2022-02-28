using GitGrabber.Abstractions.Activity;
using GitGrabber.Abstractions.Misc;
using GitGrabber.Abstractions.Social;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Connections
{
    public interface IGithubConnection
    {
        public Task<IGithubUser> GetUserAsync(string username);
        public Task<IEnumerable<IGithubUser>> GetUserFollowersAsync(string username);
        public Task<IEnumerable<IGithubUser>> GetUserFollowingAsync(string username);
        public Task<IGithubRepository> GetRepositoryAsync(string owner, string name);
        public Task<IEnumerable<IGithubRepository>> GetUserRepositoriesAsync(string username);
        public Task<IGithubOrganization> GetOrganizationAsync(string organization);
        public Task<IEnumerable<IGithubRepository>> GetOrganizationRepositoriesAsync(string organization);
        public Task<IEnumerable<IGithubOrganization>> GetUserOrganizationsAsync();
        public Task<IGithubGist> GetGistAsync(long identifier);
        public Task<IGithubEmojis> GetEmojisAsync();
        public Task<IEnumerable<IGithubCommit>> GetRepositoryCommitsAsync(string repoOwner, string repoName);
        public IGithubUser GetUser(string username);
        public IEnumerable<IGithubUser> GetUserFollowers(string username);
        public IEnumerable<IGithubUser> GetUserFollowing(string username);
        public IGithubRepository GetRepository(string owner, string name);
        public IEnumerable<IGithubRepository> GetUserRepositories(string username);
        public IGithubOrganization GetOrganization(string organization);
        public IEnumerable<IGithubRepository> GetOrganizationRepositories(string organization);
        public IEnumerable<IGithubOrganization> GetUserOrganizations();
        public IGithubGist GetGist(long identifier);
        public IGithubEmojis GetEmojis();
        public IEnumerable<IGithubCommit> GetRepositoryCommits(string repoOwner, string repoName);
    }
}
