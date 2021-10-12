using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;
namespace GitGrabber.Components {
    public static class FetchUserOrgs {
        public static List<GithubOrg> Execute(string target) {
            return JsonSerializer.Deserialize<List<GithubOrg>>(FetchData.GetString(target));
        }
    }
}