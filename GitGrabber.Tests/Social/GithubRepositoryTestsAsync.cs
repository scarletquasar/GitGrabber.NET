using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Services;
using GitGrabber.Connections;
using GitGrabber.Services;
using GitGrabber.Social;
using GitGrabber.Tests.ConfigModels;
using System;
using Xunit;

namespace GitGrabber.Tests
{
    public class GithubRepositoryTestsAsync
    {
        private readonly GithubConnectionConfig? _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubRepositoryTestsAsync()
        {
            _config = Deserializer.ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json");
            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return a valid owner in [repository].GetOwner()
        /// -> This test is considering a valid repository.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid owner in [repository].GetOwner()")]
        public async void ShouldReturnAValidOwnerToRepository()
        {
            var repository = (GithubRepository)await _githubConnection.GetRepositoryAsync("EternalQuasar0206", "GitGrabber.NET");

            Assert.NotNull(repository);

            var owner = (GithubUser)await repository.GetOwnerAsync();

            Assert.NotNull(owner);
            Assert.Equal("EternalQuasar0206", owner.Login);
            Assert.Equal(70824102L, owner.Id);
        }
    }
}
