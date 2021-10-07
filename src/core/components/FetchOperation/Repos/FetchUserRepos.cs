using System.Collections.Generic;
using System.Text.Json;
using GitGrabber.Models;

namespace GitGrabber.Components {
    public static class FetchUserRepos {
        //TODO: Add Exception Handler
        public static List<GithubRepo> Execute(string target) {
            return JsonSerializer.Deserialize<List<GithubRepo>>(FetchData.GetString(target));
        }
    }
}