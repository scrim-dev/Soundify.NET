using BuildSoft.VRChat.Osc.Chatbox;
using Soundify.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.OSC
{
    internal class OSCHandler
    {
        public static RichTextBox? OscTextBox { get; set; }
        private static readonly string TextBorder = $"+{string.Concat(Enumerable.Repeat("-", 25))}+";

        public static void SendSongToOsc(string song)
        {
            //Yandere dev ahh setup :sob:
            if (OSCToggles.ListeningToMediaTog)
            {
                var s = $"Listening to: {song}";
                OscChatbox.SendMessage(s, true, false);
                OscTextBox.Text = s;
                ConsoleLog.Log("OSC SENT: " + s);
            }
            else if (OSCToggles.SoundifyNameTog)
            {
                var s = $"[Soundify]\n{song}";
                OscChatbox.SendMessage(s, true, false);
                OscTextBox.Text = s;
                ConsoleLog.Log("OSC SENT: " + s);
            }
            else if (OSCToggles.BorderFXTog)
            {
                var s = $"[Soundify]\n{TextBorder}\n| {song} |\n{TextBorder}";
                OscChatbox.SendMessage(s, true, false);
                OscTextBox.Text = s;
                ConsoleLog.Log("OSC SENT: " + s);
            }
            else if (OSCToggles.SongNameTog)
            {
                var s = $"[{song}]";
                OscChatbox.SendMessage(s, true, false);
                OscTextBox.Text = s;
                ConsoleLog.Log("OSC SENT: " + s);
            }
        }
    }
}
