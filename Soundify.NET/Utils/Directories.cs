using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.Utils
{
    internal class Directories
    {
        public static readonly string CurrentDir = Directory.GetCurrentDirectory();
        public static readonly string AppFolder = CurrentDir + "\\Soundify";
        public static readonly string WebView2Folder = CurrentDir + "\\Soundify.NET.exe.WebView2";
        public static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string LocalLowPath = AppDataPath + "\\..\\" + "LocalLow";

        public static void Load()
        {
            if (!Directory.Exists(AppFolder)) 
            {
                try { Directory.CreateDirectory(AppFolder); }
                catch(Exception ex)
                {
                    MessageBox.Show($"Failed to create Soundify folder!\n\n{ex}");
                }
            }
        }
    }
}
