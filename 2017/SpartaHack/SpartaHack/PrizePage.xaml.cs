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

using SpartaHack.BLL.APICalls;
using SpartaHack.BLL.Models;
using SpartaHack.MVVM;
using Windows.UI.Xaml.Media.Animation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrizePage : Page
    {
        SpartaHackPrize _prizesCaller;
        public ObservableValue<List<Prize>> Prizes { get; set; }

        public PrizePage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Prizes";
            _prizesCaller = new SpartaHackPrize();
            Prizes = new ObservableValue<List<Prize>>();

            init();
            DataContext = this;
        }

        public async void init()
        {
            //try
            //{
                Prizes.Value = _prizesCaller.getPrizesLocal();
                btnRefresh.IsRefreshing = true;
                Prizes.Value = await _prizesCaller.getPrizes();
           // }
           // catch { }
            btnRefresh.IsRefreshing = false;
        }


        private void RefreshButton_RefreshClicked(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
