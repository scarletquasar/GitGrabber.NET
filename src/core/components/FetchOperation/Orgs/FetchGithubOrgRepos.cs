using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber.Components {
    public static class FetchGithubOrgRepos {
        public static List<GithubRepo> Execute(string target) {
            return JsonSerializer.Deserialize<List<GithubRepo>>(FetchData.GetString(target));
        }
    }
}