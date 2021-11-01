using System;
using GitGrabber.Models;
using GitGrabber.Components;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GitGrabber
{
    public class GitGrabConnection
    {
        /* Preset Definitions */
        public int SearchItemsPerPage = 30;
        public int SearchDefaultPage = 1;

        /* Basic Getters */
        public async Task<GithubUser> GetUser(string username) {
            return (await PublicFetchOperation.Fetch("User", $"https://api.github.com/users/{username}"));
        }

        public async Task<GithubRepo> GetRepo(string username, string reponame) {
            return (await PublicFetchOperation.Fetch("Repo", $"https://api.github.com/repos/{username}/{reponame}"));
        }

        public async Task<GithubOrg> GetOrg(string org_name) {
            return (await PublicFetchOperation.Fetch("Org", $"https://api.github.com/orgs/{org_name}"));
        }
        
        /* API Searchers */
        public async Task<List<GithubUser>> SearchUser(string search) {
            return (await PublicFetchOperation.Fetch("UserList", $"https://api.github.com/search/users?q={search}"));
        }

        public async Task<List<GithubUser>> SearchUser(string search, int per_page, int page) {
            return (await PublicFetchOperation.Fetch("UserList", $"https://api.github.com/search/users?q={search}&page={page}&per_page={per_page}"));
        }

        public async Task<List<GithubGist>> GetPublicGists() {
            return (await PublicFetchOperation.Fetch("GistList", "https://api.github.com/gists/public"));
        }

        public async Task<GithubGist> GetGist(string id) {
            return (await PublicFetchOperation.Fetch("GistList", $"https://api.github.com/gists/{id}"));
        }

        /* Emoji API */

        public async Task<Dictionary<string, string>> Emojis() {
            return (await PublicFetchOperation.Fetch("Emoji", "https://api.github.com/emojis"));
        }
    }
}