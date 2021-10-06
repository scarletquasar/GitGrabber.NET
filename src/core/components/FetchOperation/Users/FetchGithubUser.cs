using GitGrabber.Models;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubUser {
        //TODO: Add Exception Handler
        public GithubUser GrabObject(string target) {
            return JsonSerializer.Deserialize<GithubUser>(FetchData.GetString(target));
        }
    }
}