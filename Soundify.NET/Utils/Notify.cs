using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Soundify.NET.Utils
{
    internal class Notify
    {
        public static void SendToastNotification(string title, string content)
        {
            var toastContent = new ToastContentBuilder()
                .AddText(title)
                .AddText(content)
                .GetToastContent();

            var toastNotification = new ToastNotification(toastContent.GetXml());

            ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
        }

        public static void SendToastNotificationIcon(string title, string content, string icon)
        {
            var toastContent = new ToastContentBuilder()
                .AddAppLogoOverride(new Uri(icon), ToastGenericAppLogoCrop.Circle)
                .AddText(title)
                .AddText(content)
                .GetToastContent();

            var toastNotification = new ToastNotification(toastContent.GetXml());

            ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
        }
    }
}
