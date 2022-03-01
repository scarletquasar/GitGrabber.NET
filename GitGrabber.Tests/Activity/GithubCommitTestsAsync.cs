using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Services;
using GitGrabber.Activity;
using GitGrabber.Connections;
using GitGrabber.Misc;
using GitGrabber.Services;
using GitGrabber.Social;
using GitGrabber.Tests.ConfigModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace GitGrabber.Tests
{
    public class GithubCommitTestsAsync
    {
        private readonly GithubConnectionConfig? _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubCommitTestsAsync()
        {
            _config = Deserializer.ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json");
            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid commit list in [repository].GetCommitsAsync()
        /// </summary>
        [Fact(DisplayName = "Should Return valid commit list in [repository].GetCommitsAsync()")]
        public async void ShouldReturnValidCommits()
        {
            var repository = (GithubRepository)await _githubConnection.GetRepositoryAsync("EternalQuasar0206", "GitGrabber.NET");

            Assert.NotNull(repository);

            var commits = (List<GithubCommit>)await repository.GetCommitsAsync();

            Assert.NotNull(commits);
            Assert.NotEmpty(commits);
        }
    }
}
