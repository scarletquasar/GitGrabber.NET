using GitGrabber.Models;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubOrg {
        //TODO: Add Exception Handler
        public GithubOrg GrabObject(string target) {
            return JsonSerializer.Deserialize<GithubOrg>(FetchData.GetString(target));
        }
    }
}