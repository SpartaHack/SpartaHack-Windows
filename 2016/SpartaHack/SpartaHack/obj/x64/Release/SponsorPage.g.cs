﻿#pragma checksum "C:\Users\Matt\Documents\GitHub\SpartaHack2016-Windows\SpartaHack\SpartaHack\SponsorPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2F46D5300527E2F3094495BD44F385A6"
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
    partial class SponsorPage : 
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
                    this.Sponsors = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 2:
                {
                    global::PullToRefresh.UWP.PullToRefreshBox element2 = (global::PullToRefresh.UWP.PullToRefreshBox)(target);
                    #line 21 "..\..\..\SponsorPage.xaml"
                    ((global::PullToRefresh.UWP.PullToRefreshBox)element2).RefreshInvoked += this.PullToRefreshBox_RefreshInvoked;
                    #line default
                }
                break;
            case 3:
                {
                    this.pgrRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 4:
                {
                    this.grdSponsors = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 42 "..\..\..\SponsorPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.grdSponsors).SelectionChanged += this.grdSponsors_SelectionChanged;
                    #line default
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

