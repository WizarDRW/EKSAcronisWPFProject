﻿#pragma checksum "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4A040A4EA26C53E1D704163F602FC0AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EKS.Forms.MPFMenus;
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


namespace EKS.Forms.MPFMenus {
    
    
    /// <summary>
    /// UserAuthority
    /// </summary>
    public partial class UserAuthority : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBTN;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBTN;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserNamesCMBBX;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AAuthorityCMBBX;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem AUnknownU;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem AOtherU;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem AUser;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem AAdmin;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserNamesLBL;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AuthorityLBL;
        
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
            System.Uri resourceLocater = new System.Uri("/EKS;component/forms/mpfmenus/userauthority.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
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
            
            #line 8 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
            ((EKS.Forms.MPFMenus.UserAuthority)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SaveBTN = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
            this.SaveBTN.Click += new System.Windows.RoutedEventHandler(this.SaveBTN_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CancelBTN = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
            this.CancelBTN.Click += new System.Windows.RoutedEventHandler(this.CancelBTN_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UserNamesCMBBX = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\..\..\Forms\MPFMenus\UserAuthority.xaml"
            this.UserNamesCMBBX.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UserNamesCMBBX_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AAuthorityCMBBX = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AUnknownU = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.AOtherU = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.AUser = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.AAdmin = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.UserNamesLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.AuthorityLBL = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

