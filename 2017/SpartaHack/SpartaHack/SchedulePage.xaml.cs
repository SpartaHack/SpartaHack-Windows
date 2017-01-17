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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpartaHack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SchedulePage : Page
    {

        private SpartaHackSchedule _scheduleCaller;
        public ObservableValue<List<Schedule>> Schedule { get; set; }

        public SchedulePage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Schedule";
            _scheduleCaller = new SpartaHackSchedule();
            Schedule = new ObservableValue<List<Schedule>>();
            DataContext = this;
            
            init();
        }

        public async void init()
        {
            Schedule.Value = _scheduleCaller.getScheduleLocal();
            btnRefresh.IsRefreshing = true;
            var data= await _scheduleCaller.getScheduleGrouped();
            if(data!=null)
            {
                GroupedSchedule.Source = data;
            }
            btnRefresh.IsRefreshing = false;

         
        }
        private void RefreshButton_RefreshClicked(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
