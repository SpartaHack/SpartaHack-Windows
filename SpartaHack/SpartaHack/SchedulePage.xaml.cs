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
using Parse;
using SpartaHack.Styles;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try { 
            MainPage.title.Value = "SCHEDULE";
            getSchedule();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in SchedulePage, OnNavigatedTo(): " + ex.Message);
            }
        }
        public async void getSchedule()
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Schedule");
                List<SHEvent> events = new List<SHEvent>();
                SHEvent e;
                foreach (ParseObject obj in await query.FindAsync())
                {
                    e = new SHEvent();
                    e.EventTime = ((DateTime)obj["eventTime"]).ToLocalTime();
                    
                    e.Title = obj["eventTitle"].ToString();
                    try
                    {
                        e.Description = obj["eventDescription"].ToString();
                    }
                    catch { }
                    try
                    {
                        e.Location = obj["eventLocation"].ToString();
                    }
                    catch { }
                    events.Add(e);
                }
                var groupEvents = from ev in events
                                  orderby ev.EventTime ascending
                                  group ev by ev.EventTime.Date into grouped
                                  select new HeaderGroup(grouped)
                                  {
                                      Header = grouped.Key.ToString("D")
                                  };
                Events.Source = groupEvents;
                showLoading();

                try {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        var item = from ev in events where ev.EventTime > DateTime.Now select ev;

                        lsvSchedule.ScrollIntoView(item.First());
                    });
                }
                catch
                {
                    //spartahack is over

                }
                
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in SchedulePage, getSchedule(): " + ex.Message);
            }
        }

        private async void showLoading()
        {
            pgrRing.IsActive = true;
            lsvSchedule.Visibility = Visibility.Collapsed;
            await System.Threading.Tasks.Task.Delay(300);
            lsvSchedule.Visibility = Visibility.Visible;
            pgrRing.IsActive = false;
        }


        private void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            try
            {
                getSchedule();
            }
            catch { }
        }
    }
    public class SHEvent
    {
        public DateTime EventTime { get; set; }
        public string Time { get { return EventTime.ToString("t"); } }
        public string Title { get; set; }

        public string Location { get; set; }
        public string Description { get; set; }
    }
   
}
