using GitGrabber.Models;
using System.Text.Json;

namespace GitGrabber.Components {
    public class FetchGithubRepo {
        //TODO: Add Exception Handler
        public GithubRepo GrabObject(string target) {
            return JsonSerializer.Deserialize<GithubRepo>(FetchData.GetString(target));
        }
    }
}