using GitGrabber.Abstractions.Activity;
using GitGrabber.Abstractions.Misc;
using GitGrabber.Abstractions.Social;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Connections
{
    public interface IGithubConnection
    {
        //IGithubUser
        public Task<IGithubUser> GetUserAsync(string username);
        public Task<IEnumerable<IGithubUser>> GetUserFollowersAsync(string username);
        public Task<IEnumerable<IGithubUser>> GetUserFollowingAsync(string username);
        public Task<IEnumerable<IGithubRepository>> GetUserRepositoriesAsync(string username);
        public Task<IEnumerable<IGithubOrganization>> GetUserOrganizationsAsync();
        public IGithubUser GetUser(string username);
        public IEnumerable<IGithubUser> GetUserFollowers(string username);
        public IEnumerable<IGithubUser> GetUserFollowing(string username);
        public IEnumerable<IGithubRepository> GetUserRepositories(string username);
        public IEnumerable<IGithubOrganization> GetUserOrganizations();

        //IGithubRepository
        public Task<IGithubRepository> GetRepositoryAsync(string owner, string name);
        public Task<IEnumerable<IGithubCommit>> GetRepositoryCommitsAsync(string repoOwner, string repoName);
        public IGithubRepository GetRepository(string owner, string name);
        public IEnumerable<IGithubCommit> GetRepositoryCommits(string repoOwner, string repoName);

        //IGithubOrganization
        public Task<IGithubOrganization> GetOrganizationAsync(string organization);
        public Task<IEnumerable<IGithubRepository>> GetOrganizationRepositoriesAsync(string organization);
        public IGithubOrganization GetOrganization(string organization);
        public IEnumerable<IGithubRepository> GetOrganizationRepositories(string organization);

        //IGithubGist
        public Task<IGithubGist> GetGistAsync(long identifier);
        public IGithubGist GetGist(long identifier);

        //IGithubEmojis
        public Task<IGithubEmojis> GetEmojisAsync();
        public IGithubEmojis GetEmojis();
    }
}
