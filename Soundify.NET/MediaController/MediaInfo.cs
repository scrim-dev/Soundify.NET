using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.MediaController
{
    internal class MediaInfo
    {
        public static string ID { get; set; } = string.Empty;
        public static string SongName { get; set; } = string.Empty;
        public static string SongArtist { get; set; } = string.Empty;
        public static float TimelineMax{ get; set; } = 0f;
        public static float TimelineMin { get; set; } = 0f;
    }
}
