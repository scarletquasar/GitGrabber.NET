using GitGrabber.Models;
using System.Text.Json;
using System.Net;
using System.IO;
using System;
namespace GitGrabber.Components {
    public class FetchGithubRepo : IFetchOperation {
        //TODO: Add Exception Handler
        public dynamic GrabObject(string target) {
            try {
                string result = string.Empty;
                string url = target;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<GithubRepo>(result);
            }
            catch{
                return null;
            }
        }
    }
}