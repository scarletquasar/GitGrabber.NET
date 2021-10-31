using System.Net;
using System.IO;
using System.Threading.Tasks;
using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber.Components {
    public static class PublicFetchOperation {
        public static async Task<dynamic> Fetch(string type, string url) {
            byte remainingWebFetchAttempts = 5;

            /**/
            async Task<string> getGithubApiData() {
                try {
                    string result = string.Empty;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    request.Headers.Add("Accept", "application/vnd.github.v3+json"); 
                    request.Headers.Add("User-Agent", "request");
                    using (WebResponse webResponse = await request.GetResponseAsync())
                    using (Stream stream = webResponse.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var res = await reader.ReadToEndAsync();
                        return res;
                    }
                }
                catch {
                    if(remainingWebFetchAttempts > 0) {
                        remainingWebFetchAttempts--;
                        var res = await getGithubApiData();
                        return res;
                    }
                    else {
                        return null;
                    }
                }
            }

            var response = await getGithubApiData();;

            if(response != null) {
                switch(type) {
                    case "User":
                        return JsonSerializer.Deserialize<GithubUser>(response);

                    case "UserList":
                        return JsonSerializer.Deserialize<List<GithubUser>>(response);

                    case "Org":
                        return JsonSerializer.Deserialize<GithubOrg>(response);

                    case "OrgList":
                        return JsonSerializer.Deserialize<List<GithubOrg>>(response);

                    case "Repo":
                        return JsonSerializer.Deserialize<GithubRepo>(response);

                    case "RepoList":
                        return JsonSerializer.Deserialize<List<GithubRepo>>(response);
                    
                    case "Gist":
                        return JsonSerializer.Deserialize<GithubGist>(response);

                    case "GitsList":
                        return JsonSerializer.Deserialize<List<GithubGist>>(response);

                    case "Emoji":
                        return JsonSerializer.Deserialize<Dictionary<string, string>>(response);
                }
            }
            else {
                throw new WebException();
            }

            return null;
        }
    }
}