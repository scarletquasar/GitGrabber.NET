using System.Collections.Generic;

namespace GitGrabber.Models {
    public class GithubUserSearch {
        public int total_count {get; set;}
        public bool incomplete_results {get; set;}
        public List<GithubUser> items {get; set;}
    }
}