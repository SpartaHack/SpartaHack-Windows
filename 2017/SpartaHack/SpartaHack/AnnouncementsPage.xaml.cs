﻿using System;
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
    public sealed partial class AnnouncementsPage : Page
    {
        private SpartaHackAnnouncement _announcementCaller;
        

        public AnnouncementsPage()
        {
            this.InitializeComponent();
            MainPage.Title.Value = "Announcements";
            _announcementCaller = new SpartaHackAnnouncement();
            
            DataContext = this;

            init();
        }

        public async void init()
        {
            try
            {
                GroupedAnnouncements.Source = _announcementCaller.getLocalAnnouncementGrouped();
                btnRefresh.IsRefreshing = true;
                var data = await _announcementCaller.getAnnouncementGrouped();
                if (data != null)
                {
                    GroupedAnnouncements.Source = data;
                }
            }
            catch { }
            btnRefresh.IsRefreshing = false;


        }
        private void RefreshButton_RefreshClicked(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
