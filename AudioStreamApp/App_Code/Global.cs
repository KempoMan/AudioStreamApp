using System.Collections.Generic;

namespace AudioStreamApp.App_Code
{
    public static class Global
    {
        public static string BasePath = @"I:\mp3";

        public static string CurrentSong { get; set; }

        public static List<string> CurrentPlaylist { get; set; }
    }
}