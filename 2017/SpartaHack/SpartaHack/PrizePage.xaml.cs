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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PrizePage : Page
    {
        SpartaHackPrize _prizesCaller;
        public PrizePage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Prizes";
            _prizesCaller = new SpartaHackPrize();

            init();
            DataContext = this;
        }

        public async void init()
        {
            var data = await _prizesCaller.getPrizes();
        }
    }
}
