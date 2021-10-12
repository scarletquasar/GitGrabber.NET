using GitGrabber.Models;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GitGrabber.Components {
    public static class ConnectionWorker {
        public static GithubConnection Connect() {
            try {
                var result = Fetch();

                if(result.authorizations_url != null && result.authorizations_url != "") {
                    return new GithubConnection() {
                        connection_success = true
                    };
                }
                else {
                    return new GithubConnection();
                }
            }
            catch
            {
                return new GithubConnection();
            }
        }

        public static GithubApiResponse Fetch() {
            try {
                string result = string.Empty;
                string url = @"https://api.github.com/";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                // [Added Headers to enable api usage]
                request.Headers.Add("Accept", "application/vnd.github.v3+json"); 
                request.Headers.Add("User-Agent", "request");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<GithubApiResponse>(result);
            }
            catch{
                return new GithubApiResponse();
            }
        }
    }
}