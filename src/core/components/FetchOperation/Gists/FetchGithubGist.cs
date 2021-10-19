using GitGrabber.Models;
using System.Text.Json;

namespace GitGrabber.Components {
    public static class FetchGithubGist {
        //TODO: Add Exception Handler
        public static GithubGist Execute(string target) {
            return JsonSerializer.Deserialize<GithubGist>(FetchData.GetString(target));
        }
    }
}