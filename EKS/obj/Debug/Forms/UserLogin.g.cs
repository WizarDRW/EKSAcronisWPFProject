﻿#pragma checksum "..\..\..\Forms\UserLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CA42869460774D331697A72545A70D15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace EKS.Forms {
    
    
    /// <summary>
    /// UserLogin
    /// </summary>
    public partial class UserLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameTXTBX;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordPB;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_Copy;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogInBTN;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitBTN;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Forms\UserLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform spin;
        
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
            System.Uri resourceLocater = new System.Uri("/EKS;component/forms/userlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\UserLogin.xaml"
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
            this.UserNameTXTBX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PasswordPB = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            
            #line 10 "..\..\..\Forms\UserLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UserCreateBTNClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.textBlock_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.LogInBTN = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Forms\UserLogin.xaml"
            this.LogInBTN.Click += new System.Windows.RoutedEventHandler(this.LogInBTN_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ExitBTN = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Forms\UserLogin.xaml"
            this.ExitBTN.Click += new System.Windows.RoutedEventHandler(this.ExitBTN_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.canvas2 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 9:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.spin = ((System.Windows.Media.RotateTransform)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

