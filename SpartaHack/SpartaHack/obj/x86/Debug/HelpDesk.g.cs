﻿#pragma checksum "C:\Users\Matt\Documents\GitHub\SpartaHack2016-Windows\SpartaHack\SpartaHack\HelpDesk.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2B1B6BC1586964E2F09CFA90A851FAE3"
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
    partial class HelpDesk : 
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
                    this.ticketHeaderView = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 2:
                {
                    this.Tickets = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 3:
                {
                    this.Categories = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 38 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.btnDelete_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.WideState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 6:
                {
                    this.NarrowState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 7:
                {
                    this.grdAddTicket = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 8:
                {
                    this.grdListTickets = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9:
                {
                    this.cmbCategories = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 10:
                {
                    this.txtTitle = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11:
                {
                    this.txtLocation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12:
                {
                    this.txtDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13:
                {
                    this.btnSubmit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 100 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmit).Click += this.btnSubmit_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 101 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btnCancel_Click;
                    #line default
                }
                break;
            case 15:
                {
                    this.TopAppBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 16:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element16 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 116 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element16).Click += this.btnRefresh_Click;
                    #line default
                }
                break;
            case 17:
                {
                    this.BottomAppBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 18:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element18 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 121 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element18).Click += this.btnRefresh_Click;
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

