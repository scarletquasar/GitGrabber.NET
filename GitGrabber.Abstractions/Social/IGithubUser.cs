using System.Collections.Generic;
using System.Threading.Tasks;


namespace GitGrabber.Abstractions.Social
{
    public interface IGithubUser
    {
        public Task<IEnumerable<IGithubRepository>> GetRepositoriesAsync();
        public Task<IEnumerable<IGithubUser>> GetFollowersAsync();
        public Task<IEnumerable<IGithubUser>> GetFollowingAsync();
        public IEnumerable<IGithubRepository> GetRepositories();
        public IEnumerable<IGithubUser> GetFollowers();
        public IEnumerable<IGithubUser> GetFollowing();
    }
}
