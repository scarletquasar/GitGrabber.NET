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

            List<GithubOrg> Htapps = GitConnection.GetUser("sebastienros").GetOrgs();
            if(Htapps.ElementAt(0) != null) Console.WriteLine(Htapps.ElementAt(1).login);
        }
    }
}
