﻿#pragma checksum "C:\Users\adrian\Documents\Visual Studio 2015\Projects\KursyWalut\KursyWalut\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AFE57693DABFCF2B4D66714E1AF6C469"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KursyWalut
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
                    this.pageRoot = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2:
                {
                    this.pobierz = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 39 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.pobierz).Click += this.pobierz_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.dateList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 40 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.dateList).SelectionChanged += this.Listbox_daty_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.listBox_waluty = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 5:
                {
                    this.info = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.pageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.button).Click += this.button_exitClicked;
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

