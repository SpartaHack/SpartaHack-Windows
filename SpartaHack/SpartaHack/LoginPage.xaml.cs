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


           user = await ParseUser.LogInAsync(txtEmail.Text, txtPassword.Password);

          
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Application").WhereEqualTo("userId", user.ObjectId);
            ParseObject applicant = await query.FirstAsync();
            List<KeyValuePair<string, object>> data = applicant.ToList<KeyValuePair<string, object>>();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (KeyValuePair<string, object> d in data)
                sb.AppendLine(string.Format("{0}    {1}", d.Key, d.Value));
            await new Windows.UI.Popups.MessageDialog(sb.ToString()).ShowAsync();

            grdLogin.Visibility = Visibility.Collapsed;
            grdLoggedIn.Visibility = Visibility.Visible;
            MainPage.title.Value = "WELCOME " + applicant["firstName"];
        }
        async void logout()
        {
            await ParseUser.LogOutAsync();
            MainPage.title.Value = "GOODBYE " + user.Username;

            MainPage.title.Value = "LOGIN";
            grdLogin.Visibility = Visibility.Visible;
            grdLoggedIn.Visibility = Visibility.Collapsed;

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPage.title.Value = "LOGIN";
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
