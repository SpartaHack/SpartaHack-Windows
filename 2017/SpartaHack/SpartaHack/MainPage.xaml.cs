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
        public static ObservableValue<string> Title { get; set; }
        public static ObservableValue<bool> LoggedIn { get; set; }
        public static ObservableValue<string> Time { get; set; }
        public static MainPage root;
        private DateTime DoneTime;
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            Title = new ObservableValue<string>();
            LoggedIn = new ObservableValue<bool>();
            Time = new ObservableValue<string>();
            this.MySplitView.Content = frame;
            DataContext = this;


            DoneTime = DateTime.Parse("1/22/2017 17:00:00 GMT");

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;



            this.Loaded += (s,e) =>
            {
                rdAnnouncements.IsChecked = true;
                dt.Start();
            };
            MySplitView.PaneClosed += (s, e) =>
            {
                grdHideView.Visibility = Visibility.Collapsed;
                bgPane.Margin = new Thickness(MySplitView.IsPaneOpen ? MySplitView.OpenPaneLength : MySplitView.CompactPaneLength, bgPane.Margin.Top, bgPane.Margin.Right, bgPane.Margin.Bottom);

            };
          

            
        }

        private void Dt_Tick(object sender, object e)
        {
            TimeSpan dt = DoneTime.ToUniversalTime().Subtract(DateTime.Now.ToUniversalTime());
            if (dt.TotalSeconds <= 0)
                Time.Value = "FINISHED";
            else
                //txtCountDown.Text = dt.ToString(@"hh\:mm\:ss");
                //Time.Value = $"{(int)dt.TotalHours}H {dt.Minutes}M {dt.Seconds}S";
                   Time.Value= string.Format("{0:##}h {1:##}m {2:##}s", ((int)dt.TotalHours), dt.Minutes.ToString(), dt.Seconds.ToString());
        }

        private void OnAnnouncementsChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                MySplitView.IsPaneOpen = false;
                if (MySplitView.Content != null)
                    ((Frame)MySplitView.Content).Navigate(typeof(AnnouncementsPage));
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

        private void grdHideView_Tapped(object sender, TappedRoutedEventArgs e)
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
