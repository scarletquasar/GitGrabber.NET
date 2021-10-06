using System;
using GitGrabber.Models;
using GitGrabber.Components;
using System.Text.Json;

namespace GitGrabber
{
    public class GitGrabConnection
    {
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

        public GithubUser GetUser(string username) {
            return new FetchGithubUser().GrabObject("https://api.github.com/users/" + username);
        }

        public GithubRepo GetRepo(string username, string reponame) {
            return new FetchGithubRepo().GrabObject("https://api.github.com/users/" + username + "/" + reponame);
        }

        
    }
}