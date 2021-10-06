using GitGrabber.Models;
using System.Net.NetworkInformation;

namespace GitGrabber.Components {
    public static class ConnectionWorker {
        public static GithubConnection Connect() {
            try {
                    var pinger = new Ping();
                    PingReply reply = pinger.Send("api.github.com");
                    var pingable = reply.Status == IPStatus.Success;
                    var status = string.Empty;
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
    }
}