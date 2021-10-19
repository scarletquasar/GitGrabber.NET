using System;
using GitGrabber.Models;
using GitGrabber.Components;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber
{
    public class GitGrabConnection
    {
        private bool connection_success = false;
        /* Preset Definitions */
        public int SearchItemsPerPage = 30;
        public int SearchDefaultPage = 1;
        /* Singleton Definitions */
        private FetchGithubUser UserHandler = new FetchGithubUser();
        private FetchGithubRepo RepoHandler = new FetchGithubRepo();
        private FetchGithubOrg OrgHandler = new FetchGithubOrg();
        private FetchGithubUserSearch UserSearchHandler = new FetchGithubUserSearch();

        /* Connection Definitions */
        private GithubConnection connection = new GithubConnection() {
            connection_success = false
        };

        /* Starts the connection. Method used to avoid different errors that can have different causes. */
        public bool Connect() {
            connection = ConnectionWorker.Connect();
            connection_success = connection.connection_success;
            return connection.connection_success;
        }

        /* Connects to the main api and gets a GithubApiResponse object with all the returns from the original API. */
        public GithubApiResponse GithubApi() {
            if(connection_success) {
                return ConnectionWorker.Fetch();
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        /* Basic Getters */
        public GithubUser GetUser(string username) {
            if(connection_success) {
                return UserHandler.GrabObject("https://api.github.com/users/" + username);
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        public GithubRepo GetRepo(string username, string reponame) {
            if(connection_success) {
                return RepoHandler.GrabObject("https://api.github.com/repos/" + username + "/" + reponame);
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
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