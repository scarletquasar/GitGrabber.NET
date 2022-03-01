using GitGrabber.Abstractions.Connections;
using GitGrabber.Abstractions.Misc;
using System.Collections.Generic;

namespace GitGrabber.Misc
{
    public class GithubEmojis : Dictionary<string, string>, IGithubEmojis
    {
        public IGithubConnection Connection;
        public GithubEmojis() : base() { }

        public string GetUrl(string identifier) => this[identifier];

    }
}
