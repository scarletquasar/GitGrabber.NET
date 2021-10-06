using System.Collections.Generic;
using System.Text.Json;
using GitGrabber.Models;

namespace GitGrabber.Components {
    public static class FetchUserFollowers {
        public static List<GithubUser> Execute(string target) {
            return JsonSerializer.Deserialize<List<GithubUser>>(FetchData.GetString(target));
        }
    }
}