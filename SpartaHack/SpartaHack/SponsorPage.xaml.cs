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
using System.Net.Http;
using Parse;
using Windows.UI.Xaml.Media.Imaging;
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
            MainPage.title.Value = "SPONSORS";
            grdSponsors.SelectedIndex = -1;
            getSponsors();
           
        }
        public async void getSponsors()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Company");
            var companies = await query.FindAsync();
            List<Sponsor> sponsors = new List<Sponsor>();
            Sponsor sponsor;
            foreach(ParseObject obj in companies)
            {
                sponsor = new Sponsor();
                sponsor.getLogo(obj["img"] as ParseFile);
                sponsor.Name = obj["name"].ToString();
                sponsor.URL = new Uri(obj["url"].ToString());
                sponsors.Add(sponsor);
            }
            Sponsors.Source = sponsors;
        }

        private async void grdSponsors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (grdSponsors.SelectedIndex != -1)
            //{
            //    Sponsor s = grdSponsors.SelectedItem as Sponsor;
            //    await Windows.System.Launcher.LaunchUriAsync(s.URL);
            //    grdSponsors.SelectedIndex = -1;
            //}
        }
    }
    public class Sponsor
    {
        public string Name { get; set; }
        public BitmapImage Logo { get; set; }
        public Uri URL { get; set; }
        public void getLogo(ParseFile file)
        {
            Logo = new BitmapImage();
            Logo.UriSource = file.Url;
        }
    }
}
