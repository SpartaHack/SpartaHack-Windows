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

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
          



        }

        //private static void RegisterBackgroundTask()
        //{
        //    BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();

        //    // taskBuilder.SetTrigger(new SystemTrigger(SystemTriggerType.InternetAvailable, false));
        //    taskBuilder.SetTrigger(new PushNotificationTrigger());
        //   // taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
        //    // Background tasks must live in separate DLL, and be included in the package manifest 
        //    // Also, make sure that your main application project includes a reference to this DLL 
        //    taskBuilder.TaskEntryPoint = typeof(SpartaHackToast.ToastHelper).FullName;
        //    taskBuilder.Name = typeof(SpartaHackToast.ToastHelper).FullName;
        

        //    try
        //    {
        //        BackgroundTaskRegistration task = taskBuilder.Register();
        //        task.Progress += Task_Progress;
        //        task.Completed += Task_Completed;
        //    }
        //    catch (Exception ex)
        //    {
        //        DebugingHelper.ShowError(ex.Message);
        //    }
        //}

        //private static async  void Task_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        //{
        //    //CoreDispatcher dispatcher = Window.Current.Dispatcher;
        //    //await dispatcher.RunAsync(
        //    //    CoreDispatcherPriority.Normal,
        //    //    () =>
        //    //    {
        //    //        DebugingHelper.ShowError(args.Progress.ToString());
        //    //    });
        //}

        //private static bool UnregisterBackgroundTask(string SampleTaskName)
        //{
        //    foreach (var iter in BackgroundTaskRegistration.AllTasks)
        //    {
        //        IBackgroundTaskRegistration task = iter.Value;

        //        if (task.Name == SampleTaskName)
        //        {
        //            task.Unregister(true);
        //            return true;
        //        }
        //    }

        //    return false;
        //}





        //private static async  void Task_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        //{
           
        //}

        //private static void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        //{
        //    if (args.NotificationType == PushNotificationType.Raw)
        //    {
        //        args.Cancel = false;

        //        var xDoc = new XDocument(
        //    new XElement("toast",
        //        new XElement("visual",
        //            new XElement("binding", new XAttribute("template", "ToastGeneric"),
        //                new XElement("text", "SpartaHack 2016"),
        //                new XElement("text", "test")
        //                )
        //            ),// actions 
        //        new XElement("actions",
        //            new XElement("action", new XAttribute("activationType", "background"),
        //                new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
        //            new XElement("action", new XAttribute("activationType", "background"),
        //                new XAttribute("content", "No"), new XAttribute("arguments", "no"))
        //            )
        //        )
        //    );

        //        var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
        //        xmlDoc.LoadXml(xDoc.ToString());
        //        var notifi = ToastNotificationManager.CreateToastNotifier();
        //        notifi.Show(new ToastNotification(xmlDoc));
        //    }
        //}
    }
}
