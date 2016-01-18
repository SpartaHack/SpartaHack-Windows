using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Networking.PushNotifications;
using Parse;

namespace SpartaHack
{
    public static class ParseService
    {
        public static void Initialize()
        {
            ParseClient.Initialize("p3FuD3whdYxozQ3XZ8eaxM3OUca3TtvnDma3Huhb", "33Is9CGoVvQaaMGJ5pFPAq6b58KbISkLpvHEULaD");

            ParsePush.PushNotificationReceived += ParsePushOnPushNotificationReceived;
        }

        private static void ParsePushOnPushNotificationReceived(object sender, PushNotificationReceivedEventArgs args)
        {
            Debug.WriteLine("Notification received !");
        }

        public static async Task OnLaunchedAsync(ILaunchActivatedEventArgs args)
        {
            await ParseInstallation.CurrentInstallation.SaveAsync();

           await ParseAnalytics.TrackAppOpenedAsync(args);
        }
    }
}
