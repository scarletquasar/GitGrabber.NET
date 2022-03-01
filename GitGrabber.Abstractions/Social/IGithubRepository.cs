using GitGrabber.Abstractions.Activity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Social
{
    public interface IGithubRepository
    {
        public IGithubUser GetOwner();
        public IEnumerable<IGithubCommit> GetCommits();
        public Task<IGithubUser> GetOwnerAsync();
        public Task<IEnumerable<IGithubCommit>> GetCommitsAsync();
    }
}
