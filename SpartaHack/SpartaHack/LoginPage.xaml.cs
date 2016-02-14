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
using System.Net.Http;
using Parse;
using Windows.Graphics.Imaging;
using ZXing;

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
     



        async void login()
        {

            try {
                await ParseUser.LogInAsync(txtEmail.Text, txtPassword.Password);
                try
                {
                    ParseInstallation.CurrentInstallation.Add("user", ParseUser.CurrentUser);
                }
                catch { }

                await ParseInstallation.CurrentInstallation.SaveAsync();
                
               
                setupProfileScreen();

            }
            catch(Exception e)
            {
                await new Windows.UI.Popups.MessageDialog("Looks like you typed in something wrong", "Woops...").ShowAsync();
                DebuggingHelper.ShowError(e.Message);
                txtPassword.Password = "";
            }
        }
        async void logout()
        {
            try
            {
               // deleteQRCodeFromFile();
                await ParseUser.LogOutAsync();
                ParseInstallation.CurrentInstallation.Remove("user");
                await ParseInstallation.CurrentInstallation.SaveAsync();
                txtHeader.Text = "SPARTAHACK 2016";
                imgBC.Source = null;
            MainPage.title.Value = "LOGIN";
                MainPage.loggedIn.Value = "Login";
            grdLogin.Visibility = Visibility.Visible;
            grdLoggedIn.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in LoginPage, logout(): " + ex.Message);
            }

        }

        void setupProfileScreen()
        {
            try
            {
                grdLogin.Visibility = Visibility.Collapsed;
                grdLoggedIn.Visibility = Visibility.Visible;
                txtEmail.Text = "";
                txtPassword.Password = "";
                MainPage.title.Value = "Profile";
                MainPage.loggedIn.Value = "Profile";
                try {
                    

                    txtHeader.Text = "WELCOME " + ParseUser.CurrentUser["firstName"].ToString();

                }
                catch
                {
                    txtHeader.Text = "WELCOME " + ParseUser.CurrentUser.Username;
                }
                try
                {
                    BarcodeWriter writer = new BarcodeWriter();
                    writer.Format = BarcodeFormat.CODE_128;
                    writer.Options.Height = 200;
                    writer.Options.Width = 400;
                    writer.Options.Margin = 10;
                    var result = writer.Write(ParseUser.CurrentUser.ObjectId);
                    imgBC.Source = result.ToBitmap() as Windows.UI.Xaml.Media.Imaging.WriteableBitmap;

                }
                catch { }
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in LoginPage, setupProfileScreen(): " + ex.Message);
            }
        }
    
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try {
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
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in LoginPage, OnNavigatedTo(): " + ex.Message);
            }

        }

        private void txtPassword_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try { 
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                login();
                e.Handled = true;
            }
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in LoginPage, txtPassword_KeyDown(): " + ex.Message);
            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }

        private async void tsPush_Toggled(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tsPush.IsOn)
                {
                    ParseInstallation.CurrentInstallation["user"] = ParseUser.CurrentUser;
                    //await ParsePush.SubscribeAsync("");
                }
                else
                {
                    ParseInstallation.CurrentInstallation["user"] = null;
                    //await ParsePush.UnsubscribeAsync("");
                }
                await ParseInstallation.CurrentInstallation.SaveAsync();
            }
            catch { }
                
        }

        private void tsPush_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ParseInstallation.CurrentInstallation.Channels != null)
                    tsPush.IsOn = ParseInstallation.CurrentInstallation.Channels.Contains("");
            }
            catch { }
        }

        private void txtEmail_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    txtPassword.Focus(FocusState.Programmatic);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                DebuggingHelper.ShowError("Error in LoginPage, txtPassword_KeyDown(): " + ex.Message);
            }
        }
    }
}
