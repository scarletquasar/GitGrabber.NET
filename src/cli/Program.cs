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

            GithubRepo Htapps = GitConnection.GetRepo("EternalQuasar0206", "htapps");
            Console.WriteLine(Htapps.name);
        }
    }
}
