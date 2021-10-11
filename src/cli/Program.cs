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

            GithubOrg Htapps = GitConnection.GetOrg("MeuFazTudo");
            Console.WriteLine(Htapps.login);
        }
    }
}
