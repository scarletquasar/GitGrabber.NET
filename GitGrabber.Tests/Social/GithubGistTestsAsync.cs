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
    public class GithubGistTestsAsync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubGistTestsAsync()
        {
            _config = Deserializer
                      .ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json")
                      ?? new();

            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid gist in [connection].GetGist()
        /// -> This test is considering a valid gist.
        /// </summary>
        [Fact(DisplayName = "Should Return valid gist in [connection].GetGist()")]
        public async void ShouldReturnValidGist()
        {
            var gist = (GithubGist)await _githubConnection.GetGistAsync(1);

            Assert.NotNull(gist);
        }

        /// <summary>
        /// Should Return valid owner in [gist].GetOwner()
        /// -> This test is considering a valid gist.
        /// </summary>
        [Fact(DisplayName = "Should Return valid owner in [gist].GetOwner()")]
        public async void ShouldReturnValidGistOwner()
        {
            var gist = (GithubGist)await _githubConnection.GetGistAsync(1);

            Assert.NotNull(gist);

            var owner = (GithubUser)await gist.GetOwnerAsync();

            Assert.NotNull(owner);
        }
    }
}
