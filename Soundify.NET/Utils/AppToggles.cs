using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.Utils
{
    internal class AppToggles
    {
        public static bool TopMostTog { get; set; } = false;
        public static bool NotifsTog { get; set; } = false;
        public static bool AppSoundsTog { get; set; } = false;
        public static bool ConsoleLogTog { get; set; } = false;
        public static bool SaveLogsTog { get; set; } = false;
        public static bool UntrustedUrisTog {  get; set; } = false;
    }
}
