using System;
using GitGrabber.Models;
using GitGrabber.Components;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber
{
    public class GitGrabConnection
    {
        /* Preset Definitions */
        public int SearchItemsPerPage = 30;
        public int SearchDefaultPage = 1;
        /* Singleton Definitions */
        private FetchGithubUser UserHandler = new FetchGithubUser();
        private FetchGithubRepo RepoHandler = new FetchGithubRepo();
        private FetchGithubUserSearch UserSearchHandler = new FetchGithubUserSearch();

        /* Connection Definitions */
        private GithubConnection connection = new GithubConnection() {
            connection_success = false,
            connection_latency = 0
        };

        /* Starts the connection. Method used to avoid different errors that can have different causes. */
        public bool Connect() {
            connection = ConnectionWorker.Connect();
            return connection.connection_success;
        }

        /* Connects to the main api and gets a GithubApiResponse object with all the returns from the original API. */
        public GithubApiResponse GithubApi() {
            if(connection.connection_success) {
                return ConnectionWorker.Fetch();
            }
            else {
                throw new Exception(ExceptionDictionary.NotConnected);
            }
        }

        /* Basic Getters */
        public GithubUser GetUser(string username) {
            return new FetchGithubUser().GrabObject("https://api.github.com/users/" + username);
        }

        public GithubRepo GetRepo(string username, string reponame) {
            return new FetchGithubRepo().GrabObject("https://api.github.com/repos/" + username + "/" + reponame);
        }

        /* API Searchers */
        public List<GithubUser> SearchUser(string search) {
            return new FetchGithubUserSearch().GrabObject("https://api.github.com/search/users?q=" + search);
        }

        public List<GithubUser> SearchUser(string search, int per_page, int page) {
            if(per_page == 0) per_page = SearchItemsPerPage;
            if(page == 0) page = SearchDefaultPage;
            return new FetchGithubUserSearch().
            GrabObject($"https://api.github.com/search/users?q={search}&page={page}&per_page={per_page}");
        }
    }
}