using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber.Components {
    public static class FetchPublicGithubGists {
        //TODO: Add Exception Handler
        public static List<GithubGist> Execute(string target) {
            return JsonSerializer.Deserialize<List<GithubGist>>(FetchData.GetString(target));
        }
    }
}