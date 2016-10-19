using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Parse;


namespace SpartaHack
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        private Frame _rootFrame;
        public App()
        {
            
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            ParseService.Initialize();

        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await ParseService.OnLaunchedAsync(e);

            
            if (Window.Current.Content == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                _rootFrame = new Frame();
                _rootFrame.NavigationFailed += OnNavigationFailed;
                _rootFrame.Navigated += OnNavigated;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = new MainPage(_rootFrame);

                // Register a handler for BackRequested events and set the
                // visibility of the Back button
                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    _rootFrame.CanGoBack ?
                    AppViewBackButtonVisibility.Visible :
                    AppViewBackButtonVisibility.Collapsed;
            }

            if (_rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                _rootFrame.Navigate(typeof(HomePage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();

           
            
           
            //await ParsePush.SubscribeAsync("");

            //ParsePush.ParsePushNotificationReceived += (sender, args) =>
            // {

            //     var xDoc = new XDocument(
            //    new XElement("toast",
            //        new XElement("visual",
            //            new XElement("binding", new XAttribute("template", "ToastGeneric"),
            //                new XElement("text", "C# Corner"),
            //                new XElement("text", "Did you got MVP award?")
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

            //var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            //xmlDoc.LoadXml(xDoc.ToString());







            //var notifi = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
            //      notifi.Show(new Windows.UI.Notifications.ToastNotification(xmlDoc));
            //  };
           
        }

      


        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
      
        
        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            // Each time a navigation event occurs, update the Back button's visibility
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ((Frame)sender).CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_rootFrame != null && _rootFrame.CanGoBack)
            {
                e.Handled = true;
                _rootFrame.GoBack();
            }
        }
    }
}
