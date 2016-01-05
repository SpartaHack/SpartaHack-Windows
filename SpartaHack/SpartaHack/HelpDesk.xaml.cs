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
            try
            { 
            MainPage.title.Value = "HELP DESK";
        
            getCategories();
            getTickets();
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, OnNavigatedTo: " + ex.Message);
            }
        }
        public async void getCategories()
        {
            try
            {

            
            ParseQuery<ParseObject> query = ParseObject.GetQuery("HelpDesk");

            List<Ticket> categories = new List<Ticket>();
            Ticket category;
            foreach(ParseObject obj in await query.FindAsync())
            {
                category = new Ticket();
                category.Title = obj["category"].ToString();
                category.Description = obj["Description"].ToString();
                category.objectId = obj.ObjectId;
                categories.Add(category);
            }
            Categories.Source = categories;
            }
            catch(Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, getCategories(): " + ex.Message);
            }
}

        public async void getTickets()
        {
            try { 
            List<Ticket> tickets = new List<Ticket>();
           
            if (ParseUser.CurrentUser == null)
            {
                tickets.Add(new Ticket()
                {
                    Description = "Looks like youre not logged in, login so you can see your support tickets"
                });
            }
            else
            { 
                ParseQuery<ParseObject> query = ParseObject.GetQuery("HelpDeskTickets").WhereEqualTo("user", ParseUser.CurrentUser);

                Ticket t;
                foreach (ParseObject obj in await query.FindAsync())
                {
                    t = new Ticket();
                    t.Created = obj.CreatedAt.Value;
                    t.Description = obj["description"].ToString();
                    tickets.Add(t);
                }
            }
            Tickets.Source = from ti in tickets orderby ti.Created descending select ti;
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, getTickets(): " + ex.Message);
            }
        }

      
        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button b = sender as Button;
                Ticket t = b.DataContext as Ticket;
                if (t.ProblemDescription != null)
                {
                    ParseObject ticket = new ParseObject("HelpDeskTickets");


                    ticket["description"] = t.ProblemDescription;
                    ticket["user"] = ParseUser.CurrentUser;
                    ticket["category"] = new ParseObject("HelpDesk")
                    {
                        ObjectId = t.objectId
                    };
                    await ticket.SaveAsync();

                    await new Windows.UI.Popups.MessageDialog("Your message has been sent!", "Thank you for letting us know").ShowAsync();
                    getTickets();
                }
            }
            catch(Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, btnSubmit: " + ex.Message);
            }

        }

        private async void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try { 
            if (ParseUser.CurrentUser == null)
                await new Windows.UI.Popups.MessageDialog("Please sign in before reporting an incident", "Youre not logged in").ShowAsync();
            else
                FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
            }
            catch(Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, StackPanel_Tapped: " + ex.Message);
            }
}
    }
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProblemDescription { get; set; }
        public string objectId { get; set; }
        public DateTime Created { get; set; }
        public string Time { get { return Created.ToString("G"); } }
    }


}
