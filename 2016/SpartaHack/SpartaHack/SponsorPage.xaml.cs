﻿using System;
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
using System.Net.Http;
using Parse;
using Windows.UI.Xaml.Media.Imaging;
using SpartaHack.Styles;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SponsorPage : Page
    {
        public SponsorPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try { 
            MainPage.title.Value = "SPONSORS";
            grdSponsors.SelectedIndex = -1;
            getSponsors();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in SponsorPage, OnNavigatedTo(): " + ex.Message);
            }

        }
        public async void getSponsors()
        {
            try {
                ParseQuery<ParseObject> parseQuery = ParseObject.GetQuery("Company");
                var companies = await parseQuery.FindAsync();
                List<Sponsor> sponsors = new List<Sponsor>();
                Sponsor sponsor;
                foreach (ParseObject obj in companies)
                {
                    sponsor = new Sponsor();
                    try
                    {
                        sponsor.getLogo(obj["png"] as ParseFile);
                    }
                    catch { }
                    sponsor.Name = obj["name"].ToString();
                    sponsor.URL = new Uri(obj["url"].ToString());
                    sponsor.Level = obj["level"].ToString();
                    sponsors.Add(sponsor);
                }
                var query = from s in sponsors orderby s.Name, s.numLevel descending
                            group s by s.Level into grouped
                            select new HeaderGroup(grouped)
                            {
                                Header = grouped.Key,

                            };

                Sponsors.Source = query;
                showLoading();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in SponsorsPage, getSponsors(): " + ex.Message);
            }


        }
        private async void showLoading()
        {
            pgrRing.IsActive = true;
            grdSponsors.Visibility = Visibility.Collapsed;
            await System.Threading.Tasks.Task.Delay(300);
            grdSponsors.Visibility = Visibility.Visible;
            pgrRing.IsActive = false;
        }
        private async void grdSponsors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdSponsors.SelectedIndex != -1)
            {
                Sponsor s = grdSponsors.SelectedItem as Sponsor;
                await Windows.System.Launcher.LaunchUriAsync(s.URL);
                grdSponsors.SelectedIndex = -1;
            }
        }



        private void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            try
            {
                getSponsors();
            }
            catch { }
        }
    }
    public class Sponsor
    {
        public string Name { get; set; }
        public BitmapImage Logo { get; set; }

        public string Level { get; set; }
        public Uri URL { get; set; }
        public void getLogo(ParseFile file)
        {
            Logo = new BitmapImage();
            Logo.UriSource = file.Url;
        }

        public int numLevel
        {
            get
            {
                if (Level == "partner")
                    return 1;
                if (Level == "trainee")
                    return 2;
                if (Level == "warrior")
                    return 3;
                if (Level == "commander")
                    return 4;
                if (Level == "ledgend")
                    return 5;
                return 0;
            }
        }
        public double Size { get {
                return 20*numLevel; } }
    }
    


}
