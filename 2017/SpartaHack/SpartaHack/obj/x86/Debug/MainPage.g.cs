﻿#pragma checksum "D:\GitHub\SpartaHack-Windows\2017\SpartaHack\SpartaHack\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "17DECE2A32B5EFDC3E2136BE486C0315"
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
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 2:
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 3:
                {
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 4:
                {
                    this.bgPane = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.rdLogin = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 111 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdLogin).Checked += this.OnLoginChecked;
                    #line default
                }
                break;
            case 6:
                {
                    this.rdSchedule = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 102 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdSchedule).Checked += this.OnScheduleChecked;
                    #line default
                }
                break;
            case 7:
                {
                    this.rdMap = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 103 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdMap).Checked += this.OnMapChecked;
                    #line default
                }
                break;
            case 8:
                {
                    this.rdTicket = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 104 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdTicket).Checked += this.OnTicketChecked;
                    #line default
                }
                break;
            case 9:
                {
                    this.rdSponsor = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 105 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdSponsor).Checked += this.OnSponsorChecked;
                    #line default
                }
                break;
            case 10:
                {
                    this.rdPrize = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 106 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.rdPrize).Checked += this.OnPrizeChecked;
                    #line default
                }
                break;
            case 11:
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 96 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.HambButton_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.HambButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 66 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HambButton).Click += this.HambButton_Click;
                    #line default
                }
                break;
            case 13:
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

