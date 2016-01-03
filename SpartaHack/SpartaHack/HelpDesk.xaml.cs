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
            List<Ticket> t = new List<Ticket>()
            {
                new Ticket() {Title="Help Ive fallen", Description="and I cant get up"},
                new Ticket() {Title="Insomnia Cookies", Description="Crumbs stuck in keyboard" },
                new Ticket() {Title="Need help with Java" , Description="Getting error 0x123456789ABCDEF"}
            };
            Tickets.Source = t;
        }
    }
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
