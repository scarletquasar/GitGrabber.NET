using GitGrabber.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubUserSearch {
        //TODO: Add Exception Handler
        public List<GithubUser> GrabObject(string target) {
            return JsonSerializer.Deserialize<List<GithubUser>>(FetchData.GetString(target));
        }
    }
}