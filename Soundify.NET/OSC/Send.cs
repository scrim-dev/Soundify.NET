using Soundify.NET.MediaController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.OSC
{
    internal class Send
    {
        public static void SendOSC()
        {
            OSCHandler.SendSongToOsc($"{MediaInfo.SongName} by {MediaInfo.SongArtist}");
            //Alerts.SendFX();
        }
    }
}
