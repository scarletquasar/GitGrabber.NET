using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Services;
using GitGrabber.Connections;
using GitGrabber.Misc;
using GitGrabber.Services;
using GitGrabber.Tests.ConfigModels;
using System;
using Xunit;

namespace GitGrabber.Tests
{
    public class GithubEmojisTestsAsync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubEmojisTestsAsync()
        {
            _config = Deserializer
                      .ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json")
                      ?? new();

            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid emoji list in [connection].GetEmojisAsync()
        /// </summary>
        [Fact(DisplayName = "Should Return valid emoji list in [connection].GetEmojisAsync()")]
        public async void ShouldReturnValidEmojis()
        {
            var emojis = (GithubEmojis)await _githubConnection.GetEmojisAsync();

            Assert.NotNull(emojis);
        }
    }
}
