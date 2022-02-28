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
    public class GithubEmojisTestsSync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubEmojisTestsSync()
        {
            _config = Deserializer
                      .ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json")
                      ?? new();

            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid emoji list in [connection].GetEmojis()
        /// </summary>
        [Fact(DisplayName = "Should Return valid emoji list in [connection].GetEmojis()")]
        public void ShouldReturnValidEmojis()
        {
            var emojis = (GithubEmojis)_githubConnection.GetEmojis();

            Assert.NotNull(emojis);
        }
    }
}
