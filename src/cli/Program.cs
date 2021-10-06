using System;
using GitGrabber;
using GitGrabber.Models;
namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            GitGrabConnection Test = new();
            Test.Connect();
            GithubUser xax = Test.GetUser("EternalQuasar0206");
            Console.WriteLine(xax.name);
        }
    }
}
