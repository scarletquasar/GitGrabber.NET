using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Social
{
    public interface IGithubGist
    {
        public IGithubUser GetOwner();
        public Task<IGithubUser> GetOwnerAsync();
    }
}
