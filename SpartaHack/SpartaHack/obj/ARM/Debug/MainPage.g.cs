﻿#pragma checksum "C:\Users\Matt\Documents\GitHub\SpartaHack2016-Windows\SpartaHack\SpartaHack\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EBA769E96E2E91F0A5A1593F1A2242B9"
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
    partial class MainPage : 
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
                    global::Windows.UI.Xaml.Controls.Grid element1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 20 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element1).Loaded += this.Grid_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 3:
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 5:
                {
                    this.bgPane = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.rdLogin = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 93 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdLogin).Checked += this.OnLoginChecked;
                    #line default
                }
                break;
            case 7:
                {
                    this.rdSchedule = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 83 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdSchedule).Checked += this.OnScheduleChecked;
                    #line default
                }
                break;
            case 8:
                {
                    this.rdNotifications = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 84 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdNotifications).Checked += this.OnNotificationsChecked;
                    #line default
                }
                break;
            case 9:
                {
                    this.rdMap = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 85 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdMap).Checked += this.OnMapsChecked;
                    #line default
                }
                break;
            case 10:
                {
                    this.rdHelpDesk = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 86 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdHelpDesk).Checked += this.OnHelpChecked;
                    #line default
                }
                break;
            case 11:
                {
                    this.rdSponsors = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 87 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdSponsors).Checked += this.OnSponsorsChecked;
                    #line default
                }
                break;
            case 12:
                {
                    this.rdAwards = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 88 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdAwards).Checked += this.OnAwardsChecked;
                    #line default
                }
                break;
            case 13:
                {
                    this.HambButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 58 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HambButton).Click += this.HambButton_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.txtCountDown = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

