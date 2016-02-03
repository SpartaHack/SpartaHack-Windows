using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Storage;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Title title;
        DateTime d;
        public static MainPage root;
        public static Frame rootFrame;
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            this.MySplitView.Content = frame;
            title = new Title();
            DataContext = title;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            d = DateTime.Parse("2/27/2016 8:00 AM");
            dt.Tick += Dt_Tick;
            txtCountDown.Loaded += (s, e) => { dt.Start(); };
            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;
            try
            {
                DebuggingHelper.ShowError(settings.Values["Task"].ToString());
            }
            catch { }

            MySplitView.PaneClosed += (s, e) => { bgPane.Width = 48; };
            root = this;
            rootFrame = MySplitView.Content as Frame;
        }

        private void Dt_Tick(object sender, object e)
        {
            TimeSpan dt = d.Subtract(DateTime.Now);
            if (dt.TotalSeconds <= 0)
                txtCountDown.Text = "FINISHED";
            else
                //txtCountDown.Text = dt.ToString(@"hh\:mm\:ss");
                txtCountDown.Text =string.Format("{0}h {1}m {2}s", ((int)dt.TotalHours),  dt.Minutes.ToString() , dt.Seconds.ToString());
        }

        private void OnNotificationsChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(HomePage));
            }
            catch { }
        }
        private void OnMapsChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(MapPage));
            }
            catch { }
        }
        private void OnLoginChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(LoginPage));
            }
            catch { }
        }
        private void OnHelpChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(HelpDesk));
            }
            catch { }
        }

        private void OnSponsorsChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(SponsorPage));
            }
            catch { }
        }
        private void OnAwardsChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(AwardsPage));
            }
            catch { }
        }
        private void OnScheduleChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(SchedulePage));
            }
            catch { }
        }
        private void HambButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
                bgPane.Width = MySplitView.IsPaneOpen ? MySplitView.OpenPaneLength : MySplitView.CompactPaneLength;
                
            }
            catch { }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //rdNotifications.IsChecked = true;
            }
            catch { }
        }
    }
}
