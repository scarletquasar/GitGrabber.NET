using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber.Components {
    public static class FetchGithubGist {
        //TODO: Add Exception Handler
        public static GithubGist Execute(string target) {
            return JsonSerializer.Deserialize<GithubGist>(FetchData.GetString(target));
        }
    }
}