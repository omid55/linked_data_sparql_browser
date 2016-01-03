﻿#pragma checksum "..\..\BrowserWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3558243B89DC5E047D4BE7C73C09D4D1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyRdfBrowserUserControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RdfUsing {
    
    
    /// <summary>
    /// BrowserWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class BrowserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu MainMenu;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton TripleRadio;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RdfRadio;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl myTabControl;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AddTab;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CloseTab;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\BrowserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyRdfBrowserUserControl.RdfBrowser myBrowser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RdfUsing;component/browserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BrowserWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 1 "..\..\BrowserWindow.xaml"
            ((RdfUsing.BrowserWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            
            #line 5 "..\..\BrowserWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NewTabMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 6 "..\..\BrowserWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseTabMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TripleRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 10 "..\..\BrowserWindow.xaml"
            this.TripleRadio.Checked += new System.Windows.RoutedEventHandler(this.TypesRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RdfRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\BrowserWindow.xaml"
            this.RdfRadio.Checked += new System.Windows.RoutedEventHandler(this.TypesRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.myTabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 8:
            this.AddTab = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\BrowserWindow.xaml"
            this.AddTab.Click += new System.Windows.RoutedEventHandler(this.AddTab_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CloseTab = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\BrowserWindow.xaml"
            this.CloseTab.Click += new System.Windows.RoutedEventHandler(this.CloseTab_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.myBrowser = ((MyRdfBrowserUserControl.RdfBrowser)(target));
            return;
            case 11:
            
            #line 39 "..\..\BrowserWindow.xaml"
            ((System.Windows.Controls.TabItem)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.TabItem_GotFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

