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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
           
        }
        bool loggedIn = false;
        ParseUser user;




        async void login()
        {

            try {
                user = await ParseUser.LogInAsync(txtEmail.Text, txtPassword.Password);
                getQRCode(user["qrCode"] as ParseFile);
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Application").WhereEqualTo("userId", user.ObjectId);
                ParseObject applicant = await query.FirstAsync();
               
                //grdFlyout.DataContext = applicant;
              

                grdLogin.Visibility = Visibility.Collapsed;
                grdLoggedIn.Visibility = Visibility.Visible;
                txtHeader.Text = "WELCOME " + applicant["firstName"];
            }
            catch(Exception e)
            {
                await new Windows.UI.Popups.MessageDialog("Looks like you typed in something wrong", "Woops...").ShowAsync();
            }
        }
        async void logout()
        {
            await ParseUser.LogOutAsync();
            txtHeader.Text = "SPARTAHACK 2016";

            MainPage.title.Value = "LOGIN";
            grdLogin.Visibility = Visibility.Visible;
            grdLoggedIn.Visibility = Visibility.Collapsed;

        }

        async void setupProfileScreen()
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Application").WhereEqualTo("userId", ParseUser.CurrentUser.ObjectId);
            ParseObject applicant = await query.FirstAsync();

            //grdFlyout.DataContext = applicant;


            grdLogin.Visibility = Visibility.Collapsed;
            grdLoggedIn.Visibility = Visibility.Visible;
            txtHeader.Text = "WELCOME " + applicant["firstName"];
        }

        async void getQRCode(ParseFile file)
        {
            Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            HttpClient client = new HttpClient();
            bi.UriSource = file.Url;

            imgQR.Source = bi;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.title.Value = "LOGIN";
            if(ParseUser.CurrentUser==null)
            {
                txtHeader.Text = "SPARTAHACK 2016";

                MainPage.title.Value = "LOGIN";
                grdLogin.Visibility = Visibility.Visible;
                grdLoggedIn.Visibility = Visibility.Collapsed;
            }
            else
            {
                setupProfileScreen();
            }

        }

        private void txtPassword_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                login();
                e.Handled = true;
            }
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }
    }
}
