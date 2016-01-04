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
using Parse;
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
            MainPage.title.Value = "SCHEDULE";
            getSchedule();
        }
        public async void getSchedule()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Schedule");
            List<SHEvent> events = new List<SHEvent>();
            SHEvent e;
            foreach(ParseObject obj in await query.FindAsync())
            {
                e = new SHEvent();
                e.EventTime = DateTime.Parse(obj["eventTime"].ToString());
                e.Title = obj["eventTitle"].ToString();
                e.Description = obj["eventDescription"].ToString();
                events.Add(e);
            }
            Events.Source = events;
        }

    }
    public class SHEvent
    {
        public DateTime EventTime { get; set; }
        public string Time {
            get
            {
                return EventTime.DayOfWeek.ToString() + ", " + EventTime.ToString("G");
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
