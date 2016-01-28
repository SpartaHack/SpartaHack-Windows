
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using Windows.ApplicationModel.Background;
using Windows.Networking.PushNotifications;
using Windows.Storage;
namespace SpartaHackToast
{
    public sealed class ToastHelper : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
           // var deferal = taskInstance.GetDeferral();
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            string taskName = taskInstance.Task.Name;

            Debug.WriteLine("Background " + taskName + " starting...");

            // Store the content received from the notification so it can be retrieved from the UI.
           // RawNotification notification = (RawNotification)taskInstance.TriggerDetails;
            settings.Values["Task"] = "TEST";

            Debug.WriteLine("Background " + taskName + " completed!");









            //var xDoc = new XDocument(
            //new XElement("toast",
            //    new XElement("visual",
            //        new XElement("binding", new XAttribute("template", "ToastGeneric"),
            //            new XElement("text", "SpartaHack 2016"),
            //            new XElement("text", "test")
            //            )
            //        ),// actions 
            //    new XElement("actions",
            //        new XElement("action", new XAttribute("activationType", "background"),
            //            new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
            //        new XElement("action", new XAttribute("activationType", "background"),
            //            new XAttribute("content", "No"), new XAttribute("arguments", "no"))
            //        )
            //    )
            //);

            // var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            // xmlDoc.LoadXml(xDoc.ToString());
            // var notifi = ToastNotificationManager.CreateToastNotifier();
            // notifi.Show(new ToastNotification(xmlDoc));
           // deferal.Complete();
        }
    }
}
