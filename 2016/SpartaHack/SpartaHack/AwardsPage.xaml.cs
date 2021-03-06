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
using Parse;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AwardsPage : Page
    {
        public AwardsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try { 
            MainPage.title.Value = "AWARDS";
            getAwards();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in AwardsPage, OnNavigatedTo(): " + ex.Message);
            }
        }
        public async void getAwards()
        {
            try { 
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Prizes");
            List<Prize> prizes = new List<Prize>();
            Prize p;
            foreach(ParseObject obj in await query.FindAsync())
            {
                p = new Prize();
                p.Name = obj["name"].ToString();
                    try
                    {
                        p.Company = (await ((ParseObject)obj["sponsor"]).FetchIfNeededAsync())["name"].ToString();
                    }
                    catch { p.Company = "SpartaHack"; }
                p.Description = obj["description"].ToString();
                prizes.Add(p);
            }
            Awards.Source = from pr in prizes
                    group pr by pr.Company into grouped
                    select new PrizeList(grouped)
                    {
                        Company = grouped.Key
                    };
                showLoading();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in AwardsPage, getAwards(): " + ex.Message);
            }

        }
        private async void showLoading()
        {
            pgrRing.IsActive = true;
            grdAwards.Visibility = Visibility.Collapsed;
            await System.Threading.Tasks.Task.Delay(300);
            grdAwards.Visibility = Visibility.Visible;
            pgrRing.IsActive = false;
        }

        private void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            getAwards();
        }
    }
    public class Prize
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
    }
    public class PrizeList: ObservableCollection<Prize>
    {
        public PrizeList(IEnumerable<Prize> items) : base(items)
        {
        }

        public string Company { get; set; }
    }
}
