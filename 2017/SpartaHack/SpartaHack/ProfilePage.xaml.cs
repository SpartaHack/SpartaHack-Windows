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
    public sealed partial class ProfilePage : Page
    {
        public ObservableValue<bool> LoggedIn;

        private SpartaHackUser userRepo;
        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                if (user == null)
                {
                    user = new User();
                    LoggedIn.Value = false;
                }
                else if( user.auth_token!=null)
                {
                    LoggedIn.Value = true;
                }
            }
        }

        public ProfilePage()
        {
            this.InitializeComponent();
            init();
        }

        private void init()
        {
            LoggedIn = new ObservableValue<bool>();
            LoggedIn.Value = false;
            MainPage.LoggedIn = LoggedIn;
            MainPage.Title.Value = "Login";
            userRepo = new SpartaHackUser();


            User = SpartaHackUser.getCurrentUser();
            
            DataContext = this;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User=await userRepo.CreateSession(User);
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
           User= await userRepo.createUser(User);
        }
    }
}
