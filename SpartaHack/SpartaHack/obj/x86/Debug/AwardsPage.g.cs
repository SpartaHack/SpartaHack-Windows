﻿#pragma checksum "C:\Users\Matt\Documents\GitHub\SpartaHack2016-Windows\SpartaHack\SpartaHack\AwardsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3B3EF7D61CEF3D47089941C184F52BF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpartaHack
{
    partial class AwardsPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.Awards = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 2:
                {
                    this.grdAward = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 3:
                {
                    this.lsvHeader = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 4:
                {
                    global::PullToRefresh.UWP.PullToRefreshBox element4 = (global::PullToRefresh.UWP.PullToRefreshBox)(target);
                    #line 35 "..\..\..\AwardsPage.xaml"
                    ((global::PullToRefresh.UWP.PullToRefreshBox)element4).RefreshInvoked += this.PullToRefreshBox_RefreshInvoked;
                    #line default
                }
                break;
            case 5:
                {
                    this.pgrRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 6:
                {
                    this.grdAwards = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

