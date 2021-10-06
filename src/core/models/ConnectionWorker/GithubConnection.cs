namespace GitGrabber.Models {
    public class GithubConnection {
        public bool connection_success {get; set;} = false;
        public long connection_latency {get; set;} = 0;
    }
}