using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace Soundify.NET.Utils
{
    internal class Web
    {
        //For downloads and updates
        public static HttpClient? Client { get; set; } = null;
        public static void Setup()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36 OPR/110.0.0.0");
            Client.DefaultRequestHeaders.Add("User-Agent", $"Soundify.NET/{Program.AppVersion}");
        }
    }
}
