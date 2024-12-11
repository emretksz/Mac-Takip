using Foundation;
using PassoMobil.Platforms.iOS;
using UIKit;
using UserNotifications;

namespace PassoMobil
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Bildirim izinlerini isteme
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert |
                                                                  UNAuthorizationOptions.Badge |
                                                                  UNAuthorizationOptions.Sound,
                                                                  (granted, error) =>
                                                                  {
                                                                      if (error != null)
                                                                      {
                                                                          Console.WriteLine($"Bildirim izni hatası: {error.LocalizedDescription}");
                                                                      }
                                                                  });

            UNUserNotificationCenter.Current.Delegate = new iOSNotificationDelegate();
            return true;
        }
    }
}
