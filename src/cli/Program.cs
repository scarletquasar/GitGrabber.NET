using System;
using System.Linq;
using System.Collections.Generic;
using GitGrabber;
using GitGrabber.Models;
namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            GitGrabConnection GitConnection = new();
            GitConnection.Connect();

            List<GithubRepo> Htapps = GitConnection.GetUser("EternalQuasar0206").GetRepos();
            if(Htapps.ElementAt(0) != null) Console.WriteLine(Htapps.ElementAt(0).name);
        }
    }
}
