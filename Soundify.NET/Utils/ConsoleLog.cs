using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.Utils
{
    internal class ConsoleLog
    {
        public static TextBoxLog? TBLog { get; set; }
        public static void Log(string log)
        {
            TBLog.Write($"[{DateTime.Now:hh:mm:ss}] [LOG] > {log}\n", Color.Cyan);
        }

        public static void Msg(string log)
        {
            TBLog.Write($"[{DateTime.Now:hh:mm:ss}] [MESSAGE] > {log}\n", Color.White);
        }

        public static void Success(string log)
        {
            TBLog.Write($"[{DateTime.Now:hh:mm:ss}] [MESSAGE] > {log}\n", Color.LimeGreen);
            Alerts.Success();
        }

        public static void Warn(string log)
        {
            TBLog.Write($"[{DateTime.Now:hh:mm:ss}] [WARN] > {log}\n", Color.Gold);
        }

        public static void Error(string log)
        {
            TBLog.Write($"[{DateTime.Now:hh:mm:ss}] [ERROR] > {log}\n", Color.Red);
            Alerts.Error();
        }
    }
}
