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

using SpartaHack.BLL.Models;
using SpartaHack.BLL.APICalls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TicketPage : Page
    {
       
        public Ticket ticket { get; set; }
        private SpartaHackMentor shMentorRepo;
       
        public TicketPage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Help Desk";
            shMentorRepo = new SpartaHackMentor();
            ticket = new Ticket();

           
            DataContext = this;
        }


        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            User User = SpartaHackUser.getCurrentUser();
            if (User == null)
            {
                await new Windows.UI.Popups.MessageDialog("You must be logged in to submit a ticket","Please login in").ShowAsync();
            }
            else
            {
                ticket.username = User.first_name + " " + User.last_name;
                await shMentorRepo.SubmitTicket(ticket);
                ticket.text = "";
            }
        }
    }
}
