﻿#pragma checksum "C:\Users\Matt\Documents\GitHub\SpartaHack2016-Windows\SpartaHack\SpartaHack\HelpDesk.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9269EA50637EA50E9F140B7939FBDD6A"
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
                    this.lsvHeader = (global::Windows.UI.Xaml.DataTemplate)(target);
                }
                break;
            case 3:
                {
                    this.Tickets = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 4:
                {
                    this.Categories = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 5:
                {
                    this.SubCategories = (global::Windows.UI.Xaml.Data.CollectionViewSource)(target);
                }
                break;
            case 6:
                {
                    this.MyPivot = (global::Windows.UI.Xaml.Controls.Pivot)(target);
                    #line 67 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Pivot)this.MyPivot).SelectionChanged += this.Pivot_SelectionChanged;
                    #line default
                }
                break;
            case 7:
                {
                    this.pgrRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 8:
                {
                    this.btnAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 9:
                {
                    this.grdAddTicket = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 10:
                {
                    this.cmbCategories = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 238 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cmbCategories).SelectionChanged += this.cmbCategories_SelectionChanged;
                    #line default
                }
                break;
            case 11:
                {
                    this.cmbSubCategories = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 12:
                {
                    this.txtTitle = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13:
                {
                    this.txtLocation = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14:
                {
                    this.txtDescription = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15:
                {
                    this.btnSubmit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 250 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmit).Click += this.btnSubmit_Click;
                    #line default
                }
                break;
            case 16:
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 251 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btnCancel_Click;
                    #line default
                }
                break;
            case 17:
                {
                    global::PullToRefresh.UWP.PullToRefreshBox element17 = (global::PullToRefresh.UWP.PullToRefreshBox)(target);
                    #line 76 "..\..\..\HelpDesk.xaml"
                    ((global::PullToRefresh.UWP.PullToRefreshBox)element17).RefreshInvoked += this.PullToRefreshBox_RefreshInvoked;
                    #line default
                }
                break;
            case 18:
                {
                    global::Windows.UI.Xaml.Controls.ListView element18 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 98 "..\..\..\HelpDesk.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)element18).ItemClick += this.lsvTickets_ItemClick;
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

