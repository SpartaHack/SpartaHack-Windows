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
        




        async void login()
        {

            try {
                await ParseUser.LogInAsync(txtEmail.Text, txtPassword.Password);
                getQRCode();
                setupProfileScreen();

            }
            catch(Exception e)
            {
                await new Windows.UI.Popups.MessageDialog("Looks like you typed in something wrong", "Woops...").ShowAsync();
                txtPassword.Password = "";
            }
        }
        async void logout()
        {
            try
            {
                deleteQRCodeFromFile();
                await ParseUser.LogOutAsync();
            txtHeader.Text = "SPARTAHACK 2016";
                imgQR.Source = null;
            MainPage.title.Value = "LOGIN";
            grdLogin.Visibility = Visibility.Visible;
            grdLoggedIn.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, logout(): " + ex.Message);
            }

        }

        async void setupProfileScreen()
        {
            try
            {
                grdLogin.Visibility = Visibility.Collapsed;
                grdLoggedIn.Visibility = Visibility.Visible;
                txtEmail.Text = "";
                txtPassword.Password = "";
                try {
                    ParseQuery<ParseObject> query = ParseObject.GetQuery("Application").WhereEqualTo("userId", ParseUser.CurrentUser.ObjectId);
                    ParseObject applicant = await query.FirstAsync();

                    //grdFlyout.DataContext = applicant;
                    txtHeader.Text = "WELCOME " + applicant["firstName"];

                }
                catch
                {
                    txtHeader.Text = "WELCOME " + ParseUser.CurrentUser.Username;
                }           
            
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, setupProfileScreen(): " + ex.Message);
            }
        }
        async void deleteQRCodeFromFile()
        {
            try
            {
                var file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("QR.png");
                await file.DeleteAsync();
             
            }
            catch(Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, deleteQRCodeFromFile(): " + ex.Message);
            }
        }
        async void getQRCodeFromFile()
        {
            try { 
            var fileio = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("QR.png");

            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(fileio);
            Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();

            await bi.SetSourceAsync(buffer.AsStream().AsRandomAccessStream());
            imgQR.Source = bi;
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, getQRCodeFromFile(): " + ex.Message);
            }
        }
        async void getQRCode()
        {
            try
            {
                ParseFile file = ParseUser.CurrentUser["qrCode"] as ParseFile;
            Windows.UI.Xaml.Media.Imaging.BitmapImage bi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            HttpClient client = new HttpClient();
                byte[] data=await client.GetByteArrayAsync(file.Url);
                // bi.UriSource = file.Url;
             await bi.SetSourceAsync(new MemoryStream(data).AsRandomAccessStream());
            imgQR.Source = bi;

               var fileio = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("QR.png", Windows.Storage.CreationCollisionOption.ReplaceExisting);



                await Windows.Storage.FileIO.WriteBytesAsync(fileio, data);
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, getQRCode(): " + ex.Message);
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
                    getQRCodeFromFile();
            }
            }
            catch (Exception ex)
            {
                DebugingHelper.ShowError("Error in LoginPage, OnNavigatedTo(): " + ex.Message);
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
                DebugingHelper.ShowError("Error in LoginPage, txtPassword_KeyDown(): " + ex.Message);
            }

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }
    }
}
