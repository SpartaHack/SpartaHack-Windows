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

        }
 

        public static async Task OnLaunchedAsync(ILaunchActivatedEventArgs args)
        {

            await ParseInstallation.CurrentInstallation.SaveAsync();
           

            await ParseAnalytics.TrackAppOpenedAsync(args);
          



        }

    }
}
