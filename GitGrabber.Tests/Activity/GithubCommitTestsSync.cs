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
    public class GithubCommitTestsSync
    {
        private readonly GithubConnectionConfig? _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubCommitTestsSync()
        {
            _config = Deserializer.ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json");
            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid commit list in [repository].GetCommits()
        /// </summary>
        [Fact(DisplayName = "Should Return valid commit list in [repository].GetCommits()")]
        public void ShouldReturnValidCommits()
        {
            var repository = (GithubRepository)_githubConnection.GetRepository("EternalQuasar0206", "GitGrabber.NET");

            Assert.NotNull(repository);

            var commits = (List<GithubCommit>)repository.GetCommits();

            Assert.NotNull(commits);
            Assert.NotEmpty(commits);
        }
    }
}
