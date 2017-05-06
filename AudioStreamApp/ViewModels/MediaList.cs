using System.Collections.Generic;

namespace AudioStreamApp.ViewModels
{
    public class MediaList
    {
        public List<char> Letters { get; set; }
        public IEnumerable<string> Directories { get; set; }
    }
}