using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNotifications;

namespace PassoMobil.Platforms.iOS
{
    public class iOSNotificationService
    {
        public void ShowLocalNotification(string title, string message)
        {
            var content = new UNMutableNotificationContent()
            {
                Title = title,
                Body = message,
                Sound = UNNotificationSound.Default
            };

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);
            var request = UNNotificationRequest.FromIdentifier(Guid.NewGuid().ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    Console.WriteLine($"Error: {err.Description}");
                }
            });
        }
    }
}
