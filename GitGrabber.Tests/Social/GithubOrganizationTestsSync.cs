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
    public class GithubOrganizationTestsSync
    {
        private readonly GithubConnectionConfig _config;
        private readonly IGithubConnection _githubConnection;
        private readonly IGithubConnector _githubConnector;
        public GithubOrganizationTestsSync()
        {
            _config = Deserializer
                      .ByFile<GithubConnectionConfig>($"{AppDomain.CurrentDomain.BaseDirectory}/githubConfig.json")
                      ?? new();

            _githubConnector = new GithubConnector();
            _githubConnection = new GithubConnection(_config.Username, _config.Token, _githubConnector);
        }

        /// <summary>
        /// Should Return valid organizations in [connection].GetUserOrganizations()
        /// -> This test is considering a valid authentication (user).
        /// </summary>
        [Fact(DisplayName = "Should Return valid organizations in [connection].GetUserOrganizations()")]
        public void ShouldReturnValidOrganizationsToAuthenticatedUser()
        {
            var organizations = (List<GithubOrganization>)_githubConnection.GetUserOrganizations();

            Assert.NotNull(organizations);
            Assert.NotEmpty(organizations);
        }

        /// <summary>
        /// Should Return a valid organization in [connection].GetOrganization()
        /// -> This test is considering a valid organization.
        /// </summary>
        [Fact(DisplayName = "Should Return a valid organization in [connection].GetOrganization()")]
        public void ShouldReturnValidOrganization()
        {
            var organization = (GithubOrganization)_githubConnection.GetOrganization("devdeckapp");

            Assert.NotNull(organization);
        }

        /// <summary>
        /// Should Return valid repositories in [organization].GetRepos()
        /// -> This test is considering a valid organization with at least 1 repository.
        /// </summary>
        [Fact(DisplayName = "Should Return valid organizations in [organization].GetRepos()")]
        public void ShouldReturnValidReposInOrganizationGetRepos()
        {
            var organization = (GithubOrganization)_githubConnection.GetOrganization("devdeckapp");

            Assert.NotNull(organization);

            var repos = (List<GithubRepository>)organization.GetRepos();

            Assert.NotNull(repos);
            Assert.NotEmpty(repos);
        }
    }
}
