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
    public sealed partial class HelpDesk : Page
    {
        public HelpDesk()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.title.Value = "HELP DESK";
        
            getCategories();
            getTickets();
        }
        public async void getCategories()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("HelpDesk");

            List<Ticket> categories = new List<Ticket>();
            Ticket category;
            foreach(ParseObject obj in await query.FindAsync())
            {
                category = new Ticket();
                category.Title = obj["category"].ToString();
                category.Description = obj["Description"].ToString();
                categories.Add(category);
            }
            Categories.Source = categories;
        }

        public async void getTickets()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("HelpDeskTickets");

            List<Ticket> tickets = new List<Ticket>();
            Ticket t;
            foreach (ParseObject obj in await query.FindAsync())
            {
                t = new Ticket();
                
                t.Description = obj["description"].ToString();
               tickets.Add(t);
            }
            Tickets.Source = tickets;
        }
    }
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }


}
