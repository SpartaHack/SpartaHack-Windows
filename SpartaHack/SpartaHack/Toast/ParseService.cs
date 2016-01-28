using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Networking.PushNotifications;
using Parse;
using Windows.Data.Xml.Dom;
using System.Xml;
using System.Xml.Linq;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using System;

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
        }

        public static async Task OnLaunchedAsync(ILaunchActivatedEventArgs args)
        {

            await ParseInstallation.CurrentInstallation.SaveAsync();
           

            await ParseAnalytics.TrackAppOpenedAsync(args);

            //BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
            //PushNotificationTrigger trigger = new PushNotificationTrigger();
            //taskBuilder.SetTrigger(trigger);
            //taskBuilder.Name = nameof(SpartaHackToast.ToastHelper);
            //taskBuilder.TaskEntryPoint = typeof(SpartaHackToast.ToastHelper).FullName;
            //bool registered = false;
            //foreach (var cur in BackgroundTaskRegistration.AllTasks)
            //{

            //    if (cur.Value.Name == taskBuilder.Name)
            //    {
            //        // 
            //        // The task is already registered.
            //        // 
            //        registered = true;
            //        break;

            //    }
            //}
            //if (!registered)
            //    taskBuilder.Register();





        }

    }
}
