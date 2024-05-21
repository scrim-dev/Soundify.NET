using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.OSC
{
    internal class OSCToggles
    {
        public static bool MainOSCTog {  get; set; } = false;
        public static bool SongNameTog { get; set; } = false;
        public static bool SoundifyNameTog { get; set; } = false;
        public static bool ListeningToMediaTog { get; set; } = false;
        public static bool BorderFXTog { get; set; } = false;
    }
}
