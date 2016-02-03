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
    public sealed partial class TicketPage : Page
    {

        Ticket t;
        public TicketPage()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                MainPage.title.Value = "TICKET";
                t = e.Parameter as Ticket;
                grdTicket.DataContext = t;
                
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, OnNavigatedTo: " + ex.Message);
            }
        }

       

        private async void btnReissue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ParseQuery<ParseObject> query = new ParseQuery<ParseObject>("HelpDeskTickets");
               var q = await query.Where(obj => obj.ObjectId == t.ObjectId).FindAsync();
                ParseObject ticket=q.First();
                ticket["status"] = "Open";
                await ticket.SaveAsync();


                }
            catch
            {

            }
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (ParseUser.CurrentUser != null)
                //{
                //    Ticket t = cmbCategories.SelectedItem as Ticket;
                //    if (txtDescription.Text != "" && txtLocation.Text != "" && txtTitle.Text != "")
                //    {
                //        ParseObject ticket = new ParseObject("HelpDeskTickets");
                //        ticket["subCategory"] = cmbSubCategories.SelectedItem.ToString();
                //        ticket["status"] = "Open";
                //        ticket["notifiedFlag"] = false;
                //        ticket["subject"] = txtTitle.Text;
                //        ticket["description"] = txtDescription.Text;
                //        ticket["user"] = ParseUser.CurrentUser;
                //        ticket["location"] = txtLocation.Text;
                //        ticket["category"] = new ParseObject("HelpDesk")
                //        {
                //            ObjectId = t.Category
                //        };
                //        await ticket.SaveAsync();

                //        await new Windows.UI.Popups.MessageDialog("Your message has been sent!", "Thank you for letting us know").ShowAsync();
                //        btnEdit.Flyout.Hide();
                        
                //    }
                //}
                //else
                //{
                //    await new Windows.UI.Popups.MessageDialog("login so you can see your support tickets", "Looks like you're not logged in").ShowAsync();
                //}
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, btnSubmit: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtTitle.Text = "";
                txtDescription.Text = "";
                txtLocation.Text = "";
                btnEdit.Flyout.Hide();
            }
            catch { }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtTitle.Text = t.Title;
                txtDescription.Text = t.Description;
                txtLocation.Text = t.Location;
               
                btnEdit.Flyout.Hide();
            }
            catch { }
        }
    }
}
