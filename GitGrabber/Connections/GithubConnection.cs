using GitGrabber.Abstractions.Activity;
using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Misc;
using GitGrabber.Abstractions.Services;
using GitGrabber.Abstractions.Social;
using GitGrabber.Activity;
using GitGrabber.Misc;
using GitGrabber.Social;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitGrabber.Connections
{
    public class GithubConnection : IGithubConnection
    {
        private readonly string _url = "https://api.github.com";
        private readonly string _username;
        private readonly string _token;
        private readonly IGithubConnector _connector;

        public GithubConnection(string username, string token, IGithubConnector connector)
        {
            _username = username;
            _token = token;
            _connector = connector;
        }

        public async Task<IGithubUser> GetUserAsync(string username)
        {
            var user = await _connector.GetAsync<GithubUser>(_url + $"/users/{username}", _username, _token);
            user.Connection = this;
            return user;
        }

        public async Task<IEnumerable<IGithubUser>> GetUserFollowersAsync(string username)
        {
            var users = await _connector.GetAsync<List<GithubUser>>(_url + $"/users/{username}/followers", _username, _token);
            users.ForEach(x => x.Connection = this);
            return users;
        }

        public async Task<IGithubRepository> GetRepositoryAsync(string owner, string name)
        {
            var repository = await _connector.GetAsync<GithubRepository>(_url + $"/repos/{owner}/{name}", _username, _token);
            repository.Connection = this;
            return repository;
        }

        public async Task<IGithubOrganization> GetOrganizationAsync(string organization)
        {
            var org = await _connector.GetAsync<GithubOrganization>(_url + $"/orgs/{organization}", _username, _token);
            org.Connection = this;
            return org;
        }

        public IGithubUser GetUser(string username)
        {
            var user = _connector.Get<GithubUser>(_url + $"/users/{username}", _username, _token);
            user.Connection = this;
            return user;
        }

        public IEnumerable<IGithubUser> GetUserFollowers(string username)
        {
            var users = _connector.Get<List<GithubUser>>(_url + $"/users/{username}/followers", _username, _token);
            users.ForEach(x => x.Connection = this);
            return users;
        }

        public IGithubRepository GetRepository(string owner, string name)
        {
            var respository = _connector.Get<GithubRepository>(_url + $"/repos/{owner}/{name}", _username, _token);
            respository.Connection = this;
            return respository;
        }

        public IGithubOrganization GetOrganization(string organization)
        {
            var org = _connector.Get<GithubOrganization>(_url + $"/orgs/{organization}", _username, _token);
            org.Connection = this;
            return org;
        }

        public IGithubGist GetGist(long identifier)
        {
            var gist = _connector.Get<GithubGist>(_url + $"/gists/{identifier}", _username, _token);
            gist.Connection = this;
            return gist;
        }

        public async Task<IEnumerable<IGithubUser>> GetUserFollowingAsync(string username)
        {
            var users = await _connector.GetAsync<List<GithubUser>>(_url + $"/users/{username}/following", _username, _token);
            users.ForEach(x => x.Connection = this);
            return users;
        }

        public async Task<IEnumerable<IGithubRepository>> GetUserRepositoriesAsync(string username)
        {
            var respositories = await _connector.GetAsync<List<GithubRepository>>(_url + $"/users/{username}/repos", _username, _token);
            respositories.ForEach(x => x.Connection = this);
            return respositories;
        }

        public async Task<IEnumerable<IGithubRepository>> GetOrganizationRepositoriesAsync(string organization)
        {
            var respositories = await _connector.GetAsync<List<GithubRepository>>(_url + $"/orgs/{organization}/repos", _username, _token);
            respositories.ForEach(x => x.Connection = this);
            return respositories;
        }

        public async Task<IEnumerable<IGithubOrganization>> GetUserOrganizationsAsync()
        {
            var orgs = await _connector.GetAsync<List<GithubOrganization>>(_url + $"/user/orgs", _username, _token);
            orgs.ForEach(x => x.Connection = this);
            return orgs;
        }

        public IEnumerable<IGithubUser> GetUserFollowing(string username)
        {
            return _connector.Get<List<GithubUser>>(_url + $"/users/{username}/following", _username, _token);
        }

        public IEnumerable<IGithubRepository> GetUserRepositories(string username)
        {
            var respositories = _connector.Get<List<GithubRepository>>(_url + $"/users/{username}/repos", _username, _token);
            respositories.ForEach(x => x.Connection = this);
            return respositories;
        }

        public IEnumerable<IGithubRepository> GetOrganizationRepositories(string organization)
        {    
            var respositories = _connector.Get<List<GithubRepository>>(_url + $"/orgs/{organization}/repos", _username, _token);
            respositories.ForEach(x => x.Connection = this);
            return respositories;
        }

        public IEnumerable<IGithubOrganization> GetUserOrganizations()
        {
            var orgs = _connector.Get<List<GithubOrganization>>(_url + $"/user/orgs", _username, _token);
            orgs.ForEach(x => x.Connection = this);
            return orgs;
        }

        public async Task<IGithubGist> GetGistAsync(long identifier)
        {
            var gist = await _connector.GetAsync<GithubGist>(_url + $"/gists/{identifier}", _username, _token);
            gist.Connection = this;
            return gist;
        }

        public async Task<IGithubEmojis> GetEmojisAsync()
        {
            var emojis = await _connector.GetAsync<GithubEmojis>(_url + $"/emojis", _username, _token);
            emojis.Connection = this;
            return emojis;
        }

        public IGithubEmojis GetEmojis()
        {
            var emojis = _connector.Get<GithubEmojis>(_url + $"/emojis", _username, _token);
            emojis.Connection = this;
            return emojis;
        }

        public async Task<IEnumerable<IGithubCommit>> GetRepositoryCommitsAsync(string repoOwner, string repoName)
        {
            var commits = await _connector.GetAsync<List<GithubCommit>>(_url + $"/repos/{repoOwner}/{repoName}/commits", _username, _token);
            commits.ForEach(x => x.Connection = this);
            return commits;
        }

        public IEnumerable<IGithubCommit> GetRepositoryCommits(string repoOwner, string repoName)
        {
            var commits = _connector.Get<List<GithubCommit>>(_url + $"/repos/{repoOwner}/{repoName}/commits", _username, _token);
            commits.ForEach(x => x.Connection = this);
            return commits;
        }
    }
}