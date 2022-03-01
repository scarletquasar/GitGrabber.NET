using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Social
{
    public interface IGithubOrganization
    {
        public IEnumerable<IGithubRepository> GetRepos();
        public Task<IEnumerable<IGithubRepository>> GetReposAsync();
    }
}
