using GitGrabber.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace GitGrabber.Components {
    public class FetchEmojiList {
        public Dictionary<string, string> GrabObject(string target) {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(FetchData.GetString(target));
        }
    }
}