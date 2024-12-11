using Android.App;
using Android.Content;
using AndroidX.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Android.App.Application;

namespace PassoMobil.Platforms.Android
{
    public class AndroidNotificationService
    {
        public void ShowLocalNotification(string title, string message)
        {
            try
            {
                var context = Application.Context;

                var intent = new Intent(context, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);

                // PendingIntent oluşturulurken FLAG_IMMUTABLE kullanılıyor
                var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot | PendingIntentFlags.Immutable);

                var notificationBuilder = new NotificationCompat.Builder(context, "default")
                    .SetContentTitle(title)
                    .SetContentText(message)
                    .SetAutoCancel(true)
                    .SetSmallIcon(Resource.Drawable.ic_search_black_24)
                    .SetContentIntent(pendingIntent);

                var notificationManager = NotificationManagerCompat.From(context);
                notificationManager.Notify(0, notificationBuilder.Build());
            }
            catch (Exception ex)
            {

            }

        }
    }
}
