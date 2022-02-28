using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Services;
using GitGrabber.Connections;
using GitGrabber.Services;
using GitGrabber.Social;
using GitGrabber.Tests.ConfigModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace GitGrabber.Tests
{
    public class GithubUserTestsAsync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubUserTestsAsync()
        {
            _config = Deserializer
                      .ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json") 
                      ?? new();

            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return a valid user in [connection].GetUser()
        /// -> This test is considering a valid user.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid user in [connection].GetUserAsync()")]
        public async void ShouldReturnValidUserInGetUserRequest()
        {
            var user = (GithubUser)await _githubConnection.GetUserAsync("EternalQuasar0206");

            Assert.NotNull(user);
            Assert.Equal("EternalQuasar0206", user.Login);
            Assert.Equal(70824102L, user.Id);
        }

        /// <summary>
        /// Should Return a valid user list in [user].GetFollowersAsync()
        /// -> This test is considering a valid user with at least one follower.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid user list in [user].GetFollowersAsync()")]
        public async void ShouldReturnValidUsersInGetFollowersRequest()
        {
            var user = (GithubUser)await _githubConnection.GetUserAsync("EternalQuasar0206");

            Assert.NotNull(user);

            var followers = (List<GithubUser>)await user.GetFollowersAsync();

            Assert.NotNull(followers);
            Assert.NotEmpty(followers);

            var firstFollower = followers[0];

            Assert.NotNull(firstFollower);
        }

        /// <summary>
        /// Should Return a valid user list in [user].GetFollowingAsync()
        /// -> This test is considering a valid user following at least one person.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid user list in [user].GetFollowingAsync()")]
        public async void ShouldReturnValidUsersInGetFollowingRequest()
        {
            var user = (GithubUser)await _githubConnection.GetUserAsync("EternalQuasar0206");

            Assert.NotNull(user);

            var following = (List<GithubUser>)await user.GetFollowingAsync();

            Assert.NotNull(following);
            Assert.NotEmpty(following);

            var firstFollowing = following[0];

            Assert.NotNull(firstFollowing);
        }

        /// <summary>
        /// Should Return a valid repository list in [user].GetRepositoriesAsync()
        /// -> This test is considering a valid user with at least a valid repository.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid repository list in [user].GetRepositoriesAsync()")]
        public async void ShouldReturnValidRepositoriesInGetRepositoriesRequest()
        {
            var user = (GithubUser)await _githubConnection.GetUserAsync("EternalQuasar0206");

            Assert.NotNull(user);

            var repositories = (List<GithubRepository>)await user.GetRepositoriesAsync();

            Assert.NotNull(repositories);
            Assert.NotEmpty(repositories);

            var firstRepository = repositories[0];

            Assert.NotNull(firstRepository);
        }
    }
}