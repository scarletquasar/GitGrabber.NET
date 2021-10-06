using System;
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

            GithubUser Htapps = GitConnection.GetUser("EternalQuasar0206");
            Console.WriteLine(Htapps.name);
        }
    }
}
