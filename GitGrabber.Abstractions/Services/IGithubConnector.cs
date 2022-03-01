using System.Threading.Tasks;

namespace GitGrabber.Abstractions.Services
{
    public interface IGithubConnector
    {
        public Task<T> GetAsync<T>(string route, string username, string token);
        public T Get<T>(string route, string username, string token);
    }
}