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
        public static RichTextBox? OscTextBox {  get; set; }
        private static readonly string TextBorder = $"[{string.Concat(Enumerable.Repeat("=", 25))}]";
        private static readonly string TextBorder2 = $"[{string.Concat(Enumerable.Repeat("x-x-", 10))}]";

        public static void SendSongBorder(string song)
        {
            OscChatbox.SendMessage($"[Soundify]\n{TextBorder}\n\n{song}\n\n{TextBorder}", true, false);
            OscTextBox.Text = $"[Soundify]\n{TextBorder}\n\n{song}\n\n{TextBorder}";
            ConsoleLog.Log("Sent SendSongBorder() to chatbox");
        }

        public static void SendSongBorder2(string song)
        {
            OscChatbox.SendMessage($"[Soundify]\n{TextBorder2}\n\n{song}\n\n{TextBorder2}", true, false);
            OscTextBox.Text = $"[Soundify]\n{TextBorder2}\n\n{song}\n\n{TextBorder2}";
            ConsoleLog.Log("Sent SendSongBorder2() to chatbox");
        }

        public static void SendSong(string song)
        {
            OscChatbox.SendMessage($"[Soundify]\n{song}", true, false);
            OscTextBox.Text = $"[Soundify]\n{song}";
            ConsoleLog.Log("Sent SendSong() to chatbox");
        }

        public static void SendSongFancy(string song)
        {
            OscChatbox.SendMessage($"\v\v\v[Soundify]\n{song}\v\v\v", true, false);
            OscTextBox.Text = $"\v\v\v[Soundify]\n{song}\v\v\v";
            ConsoleLog.Log("Sent SendSongFancy() to chatbox");
        }
    }
}
