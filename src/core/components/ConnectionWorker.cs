using GitGrabber.Models;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Text.Json;

namespace GitGrabber.Components {
    public static class ConnectionWorker {
        public static GithubConnection Connect() {
            try {
                    var pinger = new Ping();
                    PingReply reply = pinger.Send("api.github.com");
                    var pingable = reply.Status == IPStatus.Success;
                    var latency = reply.RoundtripTime;
                    
                    return new GithubConnection() {
                        connection_success = pingable,
                        connection_latency = latency
                    };
            }
            catch (PingException)
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