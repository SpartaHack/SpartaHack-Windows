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
namespace SpartaHack
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }
        async void getAnnouncements()
        {
            try
            {
               
                
                    List<Announcement> announcements = new List<Announcement>();
                    List<ParseObject> _announcements = new List<ParseObject>( await ParseObject.GetQuery("Announcements").FindAsync());
              
                    foreach (ParseObject obj in _announcements)
                    {
                        announcements.Add(new Announcement
                        {
                            Title = obj["Title"].ToString(),
                            pinned = (bool)obj["Pinned"],
                            Created = obj.CreatedAt.Value.ToLocalTime(),
                            Description = obj["Description"].ToString()
                        });
                    }
                Data.Source = from note in announcements orderby note.Created descending orderby note.pinned descending
                              group note by note.pinned into grouped select new HeaderGroup(grouped)
                              {
                                  Header = grouped.Key ? "Pinned" : "Notifications"
                              };

                showLoading();



                    
               

            }
            catch(Exception ex)
            {
            
            
                DebuggingHelper.ShowError("Error in HomePage, getAnnouncements(): " + ex.Message);
            
            }
        }
        protected override  void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                MainPage.title.Value = "ANNOUNCEMENTS";
                getAnnouncements();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HomePage, OnNavigatedTo(): " + ex.Message);
            }
        }

        private async void showLoading()
        {
            pgrRing.IsActive = true;
            listAnnouncements.Visibility = Visibility.Collapsed;
            await System.Threading.Tasks.Task.Delay(300);
            listAnnouncements.Visibility = Visibility.Visible;
            pgrRing.IsActive = false;
        }
       



        private void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            getAnnouncements();
        }

        private async void listAnnouncements_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                Announcement a = e.ClickedItem as Announcement;
                int index = a.Description.IndexOf("http");
                string link = a.Description.Substring(index, a.Description.IndexOf(" ", index) - index);
                await Windows.System.Launcher.LaunchUriAsync(new Uri(link));
            }
            catch
            {

            }
        }
    }
    class Announcement
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public string Time { get {
                if (DateTime.Now.DayOfYear == Created.DayOfYear)
                    return Created.ToString("t");
                else if (DateTime.Now - Created == TimeSpan.FromDays(1))
                    return "Yesterday";
                else
                    return (DateTime.Now - Created).Days + " Days Ago"; } }
        public bool pinned { get; set; }
        public Visibility Pinned { get { return pinned ? Visibility.Visible : Visibility.Collapsed; } }
    }
}
