using BuildSoft.OscCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.OSC
{
    internal class SoundifyOSC
    {
        public static OscClient? OscClient { get; set; } = null;
        public static void Setup(string IP, int PORT)
        {
            OscClient = new OscClient(IP, PORT);
        }

        public static void Dispose()
        {
            OscClient.Dispose();
        }
    }
}
