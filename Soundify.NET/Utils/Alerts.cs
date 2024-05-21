using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.Utils
{
    internal class Alerts
    {
        public static void SFX()
        {
            if (AppToggles.AppSoundsTog)
            {
                SoundPlayer sound = new(Properties.Resources.buttonsfx);
                try { sound.Play(); } catch { }
            }
        }

        public static void Success()
        {
            if (AppToggles.AppSoundsTog)
            {
                SoundPlayer sound = new(Properties.Resources.Success);
                try { sound.Play(); } catch { }
            }
        }

        public static void Error() 
        {
            if (AppToggles.AppSoundsTog)
            {
                SoundPlayer sound = new(Properties.Resources.Failure);
                try { sound.Play(); } catch { }
            }
        }
    }
}
