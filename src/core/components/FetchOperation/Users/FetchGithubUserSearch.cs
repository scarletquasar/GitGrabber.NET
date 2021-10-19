using GitGrabber.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace GitGrabber.Components {
    public class FetchGithubUserSearch {
        //TODO: Add Exception Handler
        public List<GithubUser> GrabObject(string target) {
            return JsonSerializer.Deserialize<GithubUserSearch>(FetchData.GetString(target)).items;
        }
    }
}