using System.Text.Json;
using System.IO;

namespace GitGrabber.Tests
{
    public static class Deserializer
    {
        public static T? ByFile<T>(string path)
        {
            var file = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(file);
        }
    }
}
