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
    public sealed partial class HelpDesk : Page
    {
        public HelpDesk()
        {
            this.InitializeComponent();
        }

        bool isMentor = true;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            { 
            MainPage.title.Value = "HELP DESK";
        
            getCategories();
            getTickets();
                load();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, OnNavigatedTo: " + ex.Message);
            }
        }


        public async void load()
        {
            try
            {
                ParseQuery<ParseObject> query;

                query = ParseObject.GetQuery("Mentors").Where(p => p["mentor"] == ParseUser.CurrentUser);

                ParseObject mentor = (await query.FindAsync()).First();
                if (mentor["categories"] == null)
                {
                    //not a mentor
                    grdMentor.Visibility = Visibility.Collapsed;
                    isMentor = false;
                }
            }
            catch
            {
                //not a mentor
                grdMentor.Visibility = Visibility.Collapsed;
                isMentor = false;
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
                DebuggingHelper.ShowError("Error in HelpDesk, getCategories(): " + ex.Message);
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
                        query = ParseObject.GetQuery("HelpDeskTickets").WhereEqualTo("user", ParseUser.CurrentUser);
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
                        obj.TryGetValue<string>("status", out val);
                        t.Status = val; 
                        tickets.Add(t);
                        t.ObjectId = obj.ObjectId;
                }
            }
                Tickets.Source = from ti in tickets
                                 orderby ti.StatusNum, ti.Created descending
                                 group ti by ti.Status into grouped
                                 select new HeaderGroup(grouped)
                                 {
                                     Header = grouped.Key
                                 };
                showLoading();
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, getTickets(): " + ex.Message);
            }
        }



        public async void getTicketsForMentor()
        {
            try
            {
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
                    
                        query = ParseObject.GetQuery("Mentors").Where(p => p["mentor"] == ParseUser.CurrentUser);

                        ParseObject mentor = (await query.FindAsync()).First();

                    query = ParseObject.GetQuery("HelpDeskTickets").Where(p => (mentor["categories"] as List<object>).Contains(p["subCategory"])).Where(p => p["user"] != ParseUser.CurrentUser);



                    Ticket t;
                        foreach (ParseObject obj in await query.FindAsync())
                        {
                            t = new Ticket();
                            t.Created = obj.CreatedAt.Value.ToLocalTime();
                            string val;
                            obj.TryGetValue<string>("subject", out val);
                            t.Title = val;
                            obj.TryGetValue<string>("location", out val);
                            t.Location = val;
                            obj.TryGetValue<string>("description", out val);
                            t.Description = val;
                            obj.TryGetValue<string>("status", out val);
                            t.Status = val;
                            tickets.Add(t);
                            t.ObjectId = obj.ObjectId;
                        }

                        if(tickets.Count()==0)
                         {
                            t = new Ticket()
                            {
                                Title = "Looks like there are no tickets to be found"
                            };

                        }
                        

                    }

                
                Tickets.Source = from ti in tickets
                                 orderby ti.StatusNum, ti.Created descending
                                 group ti by ti.Status into grouped
                                 select new HeaderGroup(grouped)
                                 {
                                     Header = grouped.Key
                                 };
                showLoading();
            }
            catch { }


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
                DebuggingHelper.ShowError("Error in HelpDesk, btnSubmit: " + ex.Message);
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
                DebuggingHelper.ShowError("Error in HelpDesk, StackPanel_Tapped: " + ex.Message);
            }
}

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ParseUser.CurrentUser != null)
                {
                    ParseObject ticket = new ParseObject("HelpDeskTickets");
                    Ticket t = ((sender as Button).DataContext as Ticket);
                    ticket.ObjectId = t.ObjectId;
                    Windows.UI.Popups.MessageDialog md;
                    string status;
                    string title;
                    if(isMentor)
                    {
                        title = "Accept the ticket?";
                        status = "Accepted";
                    }

                   else if (t.Status == "Open"||t.Status=="Accepted")
                    {
                        title = "Are you sure you want to delete your ticket?";
                        status = "Expired";
                    }
                    else
                    {
                        title = "Reissue the ticket?";
                        status = "Open";
                    }
                    md = new Windows.UI.Popups.MessageDialog(t.Title, title);

                    md.Commands.Add(new Windows.UI.Popups.UICommand("Yes", (s) =>
                    {
                        ticket["status"] = status;
                        ticket.SaveAsync();
                        getTickets();
                    }));

                    md.Commands.Add(new Windows.UI.Popups.UICommand("Cancel"));

                    await md.ShowAsync();







                }
            }
            catch(Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, btnDelete: " + ex.Message);
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

        

        private void tglMentor_Toggled(object sender, RoutedEventArgs e)
        {
            if (tglMentor.IsOn)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                getTicketsForMentor();
            }
            else
            {
                getTickets();
                btnAdd.Visibility = Visibility.Visible;
            }
        }



    }
    public class Ticket
    {
        public string UserName
        {
            get
            {
                return "";
            }
        }
        public ParseUser user { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }
        public string ObjectId { get; set; }
        public DateTime Created { get; set; }
        public string Time { get { return Created.ToString("G"); } }

        public string Status { get; set; }

        public int StatusNum
        {
            get
            {
                if (Status == "Accepted")
                    return 0;
                else if (Status == "Open")
                    return 1;
                else if (Status == "Expired")
                    return 2;
                else
                    return 3;
            }
        }
      

    }

    public class TicketCategory:Ticket
    {
        public List<object> SubCategories { get; set; }
    }


}
