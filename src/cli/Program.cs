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
            /* This console application is for testing purposes only and should not be confused 
            with the main project (core) of the application which can be found under "src/core". */
            
            GitGrabConnection GitConnection = new();
            GitConnection.Connect();

            GithubOrg Htapps = GitConnection.GetOrg("aspnet");
            Console.WriteLine(Htapps.login);
        }
    }
}
