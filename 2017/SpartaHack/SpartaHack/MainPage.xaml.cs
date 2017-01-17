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
        public static ObservableValue<string> Title;
        public static ObservableValue<bool> LoggedIn;
        public static MainPage root;
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            Title = new ObservableValue<string>();
            LoggedIn = new ObservableValue<bool>();
            this.MySplitView.Content = frame;
            DataContext = Title;

            this.Loaded += (s,e) =>
            {
                rdSchedule.IsChecked = true;
            };
            MySplitView.PaneClosed += (s, e) =>
            {
                grdHideView.Visibility = Visibility.Collapsed;
                bgPane.Margin = new Thickness(MySplitView.IsPaneOpen ? MySplitView.OpenPaneLength : MySplitView.CompactPaneLength, bgPane.Margin.Top, bgPane.Margin.Right, bgPane.Margin.Bottom);

            };

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
        private void OnTicketChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(TicketPage));
            }
            catch { }
        }
        private void OnMapChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(MapPage));
            }
            catch { }
        }
        private void OnSponsorChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(SponsorPage));
            }
            catch { }
        }
        private void OnPrizeChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(PrizePage));
            }
            catch { }
        }


        private void OnLoginChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(ProfilePage));
            }
            catch { }
        }
        private void HambButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grdHideView.Visibility = grdHideView.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
                bgPane.Margin = new Thickness(MySplitView.IsPaneOpen ? MySplitView.OpenPaneLength : MySplitView.CompactPaneLength, bgPane.Margin.Top, bgPane.Margin.Right, bgPane.Margin.Bottom);



            }
            catch { }
        }
    }
}
