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
using System.Collections.ObjectModel;
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
            foreach (ParseObject obj in await query.FindAsync())
            {
                e = new SHEvent();
                e.EventTime = DateTime.Parse(obj["eventTime"].ToString());
                e.Title = obj["eventTitle"].ToString();
                e.Description = obj["eventDescription"].ToString();
                events.Add(e);
            }
            var groupEvents = from ev in events orderby ev.EventTime ascending group ev by ev.EventTime.Date into grouped select new EventGroup(grouped)
            {
                Day = grouped.Key.ToString("D")
        };
            Events.Source = groupEvents;
        }

    }
    public class SHEvent
    {
        public DateTime EventTime { get; set; }
        public string Time { get { return EventTime.ToString("t"); } }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class EventGroup : ObservableCollection<SHEvent>
    {
        public EventGroup(IEnumerable<SHEvent> items) : base(items)
        {
        }
        
        public string Day{ get; set; }
    }
}
