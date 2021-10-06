using System;
using GitGrabber;
using GitGrabber.Models;
using GitGrabber.Components;
namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            GitGrabConnection Test = new();
            Test.Connect();
            string xax = new FetchGithubUser().GrabObject("https://api.github.com/users/" + "EternalQuasar0206");
            Console.WriteLine(xax);
        }
    }
}
