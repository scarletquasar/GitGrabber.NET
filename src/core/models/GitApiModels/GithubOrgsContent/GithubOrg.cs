namespace GitGrabber.Models {
    public class GithubOrg {
        public string login {get; set;}
        public long id {get; set;}
        public string node_id {get; set;}
        public string url {get; set;}
        public string repos_url {get; set;}
        public string events_url {get; set;}
        public string hooks_url {get; set;}
        public string issues_url {get; set;}
        public string members_url {get; set;}
        public string public_members_url {get; set;}
        public string avatar_url {get; set;}
        public string description {get; set;}
        public bool is_verified {get; set;}
        public bool has_organization_projects {get; set;} = false;
        public bool has_repository_projects {get; set;} = false;
        public int public_repos {get; set;}
        public int public_gists {get; set;}
        public int followers {get; set;}
        public int following {get; set;}
        public string html_url {get; set;}
        public string created_at {get; set;}
        public string updated_at {get; set;}
        public string type {get; set;}
        
        /* Built-in dynamic data retrieval features */
        public List<GithubUser> GetFollowers() {
            return FetchUserFollowers.Execute($"https://api.github.com/users/{login}/followers");
        }
    }
}