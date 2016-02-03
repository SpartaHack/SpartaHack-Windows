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
using System.Xml.Linq;

using Windows.UI.Notifications;
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
                if (t.IsMentor)
                {
                    btnDelete.Visibility = Visibility.Collapsed;
                    btnReissue.Visibility = Visibility.Collapsed;
                    if (t.Status == "Accepted")
                        btnAcceptTicket.Visibility = Visibility.Collapsed;
                }
                else
                {
                    btnAcceptTicket.Visibility = Visibility.Collapsed;
                }
                if (t.Status == "Expired")
                {
                    btnDelete.Visibility = Visibility.Collapsed;
                }
                else if(t.Status=="Open")
                {
                    btnReissue.Visibility = Visibility.Collapsed;
                }

            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in HelpDesk, OnNavigatedTo: " + ex.Message);
            }
        }

       

        private void btnReissue_Click(object sender, RoutedEventArgs e)
        {
            updateTicket("Open");
        }

      

  

        private void btnAcceptTicket_Click(object sender, RoutedEventArgs e)
        {
            updateTicket("Accepted");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            updateTicket("Expired");
        }


        private async void updateTicket(string status)
        {
            try
            {
                ParseQuery<ParseObject> query = new ParseQuery<ParseObject>("HelpDeskTickets");
                var q = await query.Where(obj => obj.ObjectId == t.ObjectId).FindAsync();
                ParseObject ticket = q.First();
                ticket["status"] = status;
                await ticket.SaveAsync();
                var xDoc = new XDocument(
             new XElement("toast",
                 new XElement("visual",
                     new XElement("binding", new XAttribute("template", "ToastGeneric"),
                         new XElement("text", "SpartaHack 2016"),
                         new XElement("text", "Ticket Updated")
                         )
                     )
                 )
             );

                var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
                xmlDoc.LoadXml(xDoc.ToString());
                var notifi = ToastNotificationManager.CreateToastNotifier();
                notifi.Show(new ToastNotification(xmlDoc));
                if (MainPage.rootFrame.CanGoBack)
                    MainPage.rootFrame.GoBack();

            }
            catch
            {

            }
        }

    }
}
