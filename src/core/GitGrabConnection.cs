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

        public GithubOrg GetOrg(string org_name) {
            if(connection_success) {
                return OrgHandler.GrabObject("https://api.github.com/orgs/" + org_name);
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }
        
        /* API Searchers */
        public List<GithubUser> SearchUser(string search) {
            if(connection_success) {
                return UserSearchHandler.GrabObject("https://api.github.com/search/users?q=" + search);
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            } 
        }

        public List<GithubUser> SearchUser(string search, int per_page, int page) {
            if(connection_success) {
                if(per_page == 0) per_page = SearchItemsPerPage;
                if(page == 0) page = SearchDefaultPage;
                return new FetchGithubUserSearch().
                GrabObject($"https://api.github.com/search/users?q={search}&page={page}&per_page={per_page}");
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        public List<GithubGist> GetPublicGists() {
            if(connection_success) {
                return FetchPublicGithubGists.Execute("https://api.github.com/gists/public");
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        public GithubGist GetGist(string id) {
            if(connection_success) {
                return FetchGithubGist.Execute($"https://api.github.com/gists/{id}");
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        /* Emoji API */

        public Dictionary<string, string> Emojis() {
            if(connection_success) {
                return new FetchEmojiList().GrabObject("https://api.github.com/emojis");
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }
    }
}