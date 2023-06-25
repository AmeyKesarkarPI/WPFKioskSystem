﻿#pragma checksum "..\..\OptionWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2361F235FAA2264381D572C3B81278F9B880A19D44A6008AC06757D1DD9C45A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KioskSystemAgent;
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


namespace KioskSystemAgent {
    
    
    /// <summary>
    /// OptionWindow
    /// </summary>
    public partial class OptionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\OptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DynamicOptions;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\OptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetCustomerInfo;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\OptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MarkServing;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\OptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MarkServed;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\OptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Controls;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KioskSystemAgent;component/optionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OptionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DynamicOptions = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.GetCustomerInfo = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\OptionWindow.xaml"
            this.GetCustomerInfo.Click += new System.Windows.RoutedEventHandler(this.GetCustomer);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MarkServing = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\OptionWindow.xaml"
            this.MarkServing.Click += new System.Windows.RoutedEventHandler(this.Serving);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MarkServed = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\OptionWindow.xaml"
            this.MarkServed.Click += new System.Windows.RoutedEventHandler(this.Served);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Controls = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 72 "..\..\OptionWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

