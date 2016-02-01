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

            List<TicketCategory> categories = new List<TicketCategory>();
            TicketCategory category;
            foreach(ParseObject obj in await query.FindAsync())
            {
                category = new TicketCategory();
                category.Title = obj["category"].ToString();
                category.Description = obj["Description"].ToString();
                category.Category = obj.ObjectId;

                    category.SubCategories = obj.Get<List<object>>("subCategory");
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
                        Description = "Looks like youre not logged in, login so you can see your support tickets",
                        Created = DateTime.Now
                });
                    
            }
            else
            {
                    ParseQuery<ParseObject> query;
                    if(ParseUser.CurrentUser["role"].ToString()=="admin")
                    {
                        query = ParseObject.GetQuery("HelpDeskTickets");
                    }
                    else
                    {
                        query = ParseObject.GetQuery("HelpDeskTickets").WhereEqualTo("user", ParseUser.CurrentUser).WhereNotEqualTo("status", "Expired");
                    }

                Ticket t;
                foreach (ParseObject obj in await query.FindAsync())
                {
                    t = new Ticket();
                    t.Created = obj.CreatedAt.Value.ToLocalTime();
                        string val;
                         obj.TryGetValue<string>("subject",out val);
                        t.Title = val;
                        obj.TryGetValue<string>("location", out val);
                        t.Location = val;
                        obj.TryGetValue<string>("description", out val);
                        t.Description = val;
                        tickets.Add(t);
                        t.ObjectId = obj.ObjectId;
                }
            }
            Tickets.Source = from ti in tickets orderby ti.Created descending select ti;
                showLoading();
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, getTickets(): " + ex.Message);
            }
        }

        private async void showLoading()
        {
            pgrRing.IsActive = true;
            lsvTickets.Visibility = Visibility.Collapsed;
            await System.Threading.Tasks.Task.Delay(300);
            lsvTickets.Visibility = Visibility.Visible;
            pgrRing.IsActive = false;
        }
        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ParseUser.CurrentUser != null)
                {
                    Ticket t = cmbCategories.SelectedItem as Ticket;
                    if (txtDescription.Text != "" && txtLocation.Text != "" && txtTitle.Text != "")
                    {
                        ParseObject ticket = new ParseObject("HelpDeskTickets");
                        ticket["subCategory"] = cmbSubCategories.SelectedItem.ToString();
                        ticket["status"] = "Open";
                        ticket["notifiedFlag"] = false;
                        ticket["subject"] = txtTitle.Text;
                        ticket["description"] = txtDescription.Text;
                        ticket["user"] = ParseUser.CurrentUser;
                        ticket["location"] = txtLocation.Text;
                        ticket["category"] = new ParseObject("HelpDesk")
                        {
                            ObjectId = t.Category
                        };
                        await ticket.SaveAsync();

                        await new Windows.UI.Popups.MessageDialog("Your message has been sent!", "Thank you for letting us know").ShowAsync();
                        btnAdd.Flyout.Hide();
                        getTickets();
                    }
                }
                else
                {
                    await new Windows.UI.Popups.MessageDialog("login so you can see your support tickets", "Looks like you're not logged in").ShowAsync();
                }
            }
            catch (Exception ex)
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

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ParseUser.CurrentUser != null)
                {
                    ParseObject ticket = new ParseObject("HelpDeskTickets");
                    Ticket t = ((sender as Button).DataContext as Ticket);
                    ticket.ObjectId = t.ObjectId;
                    
                    Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(t.Title,"Are you sure you want to delete your ticket?");
                    
                    md.Commands.Add(new Windows.UI.Popups.UICommand("ok", (s) =>
                     {
                         ticket["status"] = "Expired";
                         getTickets();
                     }));
                    md.Commands.Add(new Windows.UI.Popups.UICommand("cancel"));

                    await md.ShowAsync();







                }
            }
            catch(Exception ex)
            {
                DebugingHelper.ShowError("Error in HelpDesk, btnDelete: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtTitle.Text = "";
                txtDescription.Text = "";
                txtLocation.Text = "";
                btnAdd.Flyout.Hide();
            }
            catch { }
        }

        private void PullToRefreshBox_RefreshInvoked(DependencyObject sender, object args)
        {
            try
            {
                getCategories();
                getTickets();
            }
            catch { }
        }

        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SubCategories.Source = (cmbCategories.SelectedItem as TicketCategory).SubCategories;
            }
            catch { }
        }
    }
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }
        public string ObjectId { get; set; }
        public DateTime Created { get; set; }
        public string Time { get { return Created.ToString("G"); } }
    }

    public class TicketCategory:Ticket
    {
        public List<object> SubCategories { get; set; }
    }


}
