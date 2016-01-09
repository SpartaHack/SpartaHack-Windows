using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            this.MySplitView.Content = frame;
            title = new Title();
            DataContext = title;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(.5);
            d = DateTime.Now.AddHours(1);
            dt.Tick += (s, e) => { txtCountDown.Text = d.Subtract(DateTime.Now).ToString("t"); };
            txtCountDown.Loaded += (s, e) => { dt.Start(); };
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
                bgPane.Width = MySplitView.IsPaneOpen ? 200 : 48;
            }
            catch { }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                rdNotifications.IsChecked = true;
            }
            catch { }
        }
    }
}
