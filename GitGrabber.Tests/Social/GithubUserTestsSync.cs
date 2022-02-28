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
    public class GithubUserTestsSync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubUserTestsSync()
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
        [Fact(DisplayName = "Should Return a valid user in [connection].GetUser()")]
        public void ShouldReturnValidUserInGetUserRequest()
        {
            var user = (GithubUser)_githubConnection.GetUser("EternalQuasar0206");

            Assert.NotNull(user);
            Assert.Equal("EternalQuasar0206", user.Login);
            Assert.Equal(70824102L, user.Id);
        }

        /// <summary>
        /// Should Return a valid user list in [user].GetFollowers()
        /// -> This test is considering a valid user with at least one follower.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid user list in [user].GetFollowers()")]
        public void ShouldReturnValidUsersInGetFollowersRequest()
        {
            var user = (GithubUser)_githubConnection.GetUser("EternalQuasar0206");

            Assert.NotNull(user);

            var followers = (List<GithubUser>)user.GetFollowers();

            Assert.NotNull(followers);
            Assert.NotEmpty(followers);

            var firstFollower = followers[0];

            Assert.NotNull(firstFollower);
        }

        /// <summary>
        /// Should Return a valid user list in [user].GetFollowing()
        /// -> This test is considering a valid user following at least one person.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid user list in [user].GetFollowing()")]
        public void ShouldReturnValidUsersInGetFollowingRequest()
        {
            var user = (GithubUser)_githubConnection.GetUser("EternalQuasar0206");

            Assert.NotNull(user);

            var following = (List<GithubUser>)user.GetFollowing();

            Assert.NotNull(following);
            Assert.NotEmpty(following);

            var firstFollowing = following[0];

            Assert.NotNull(firstFollowing);
        }

        /// <summary>
        /// Should Return a valid repository list in [user].GetRepositories()
        /// -> This test is considering a valid user with at least a valid repository.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid repository list in [user].GetRepositories()")]
        public void ShouldReturnValidRepositoriesInGetRepositoriesRequest()
        {
            var user = (GithubUser)_githubConnection.GetUser("EternalQuasar0206");

            Assert.NotNull(user);

            var repositories = (List<GithubRepository>)user.GetRepositories();

            Assert.NotNull(repositories);
            Assert.NotEmpty(repositories);

            var firstRepository = repositories[0];

            Assert.NotNull(firstRepository);
        }
    }
}