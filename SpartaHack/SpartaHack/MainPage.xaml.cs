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
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            this.MySplitView.Content = frame;
            title = new Title();
            DataContext = title;
        }

      
        private void OnNotificationsChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(HomePage));
        }
        private void OnMapsChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(MapPage));
        }
        private void OnLoginChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(LoginPage));
        }
        private void OnHelpChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(HelpDesk));
        }

        private void OnSponsorsChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(SponsorPage));
        }
        private void OnAwardsChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(AwardsPage));
        }
        private void OnScheduleChecked(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
            if (MySplitView.Content != null)
                ((Frame)MySplitView.Content).Navigate(typeof(SchedulePage));
        }
        private void HambButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            bgPane.Width = MySplitView.IsPaneOpen ? 200 : 48;
        }
    }
}
