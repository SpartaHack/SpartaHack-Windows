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
using Windows.UI.Xaml.Media.Imaging;

using SpartaHack.BLL.Models;
using SpartaHack.BLL.APICalls;


using ZXing;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        public ObservableValue<bool> LoggedIn;
        public ObservableValue<ImageSource> QRImage;

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
                    generateQR();
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
            QRImage = new ObservableValue<ImageSource>();
          
            LoggedIn = new ObservableValue<bool>();
            LoggedIn.Value = false;
            MainPage.LoggedIn = LoggedIn;
            MainPage.Title.Value = "Login";
            userRepo = new SpartaHackUser();


            User = SpartaHackUser.getCurrentUser();
            
            DataContext = this;
        }

        private async void login()
        {
            User = await userRepo.CreateSession(User);
            DataContext = null;
            DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
           User= await userRepo.createUser(User);
        }

        private async void btnLogout_Click(object sender, RoutedEventArgs e)
        {
           
             User=await userRepo.DeleteSession(User);
            DataContext = null;
            DataContext = this;
        }

        private void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    login();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
               // DebuggingHelper.ShowError("Error in LoginPage, txtPassword_KeyDown(): " + ex.Message);
            }
        }

        private void generateQR()
        {
            // instantiate a writer object
            var barcodeWriter = new BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
            barcodeWriter.Options.Margin = 10;
            barcodeWriter.Options.Height = 250;
            barcodeWriter.Options.Width = 250;
            // write text and generate a 2-D barcode as a bitmap
           
           QRImage.Value = (ImageSource)barcodeWriter.Write(user.id.ToString()).ToBitmap();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User = await userRepo.updateUser(User);
        }
    }
}
