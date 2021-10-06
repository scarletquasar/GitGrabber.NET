using GitGrabber.Models;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubUser : IFetchOperation {
        //TODO: Add Exception Handler
        public dynamic GrabObject(string target) {
            try {
                string result = string.Empty;
                string url = target;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                request.Headers.Add("Accept", "application/vnd.github.v3+json"); // [Added Header to enable api usage]

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<GithubUser>(result);
            }
            catch(Exception e) {
                return e.ToString();
            }
        }
    }
}