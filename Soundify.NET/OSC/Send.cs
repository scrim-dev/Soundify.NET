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
            if (OSCToggles.ListeningToMediaTog)
            {
                OSCHandler.SendSongBorder2($"Listening to: {MediaInfo.SongName} by {MediaInfo.SongArtist}");
            }

            if (OSCToggles.BorderFXTog)
            {
                OSCHandler.SendSongBorder($"{MediaInfo.SongName} by {MediaInfo.SongArtist}");
            }

            if (OSCToggles.SongNameTog)
            {
                OSCHandler.SendSong($"{MediaInfo.SongName}");
            }

            if (OSCToggles.SoundifyNameTog)
            {
                //OSCHandler.SendSongFancy("{MediaInfo.SongName} by {MediaInfo.SongArtist}");
            }
        }
    }
}
