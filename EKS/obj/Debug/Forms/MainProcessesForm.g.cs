﻿#pragma checksum "..\..\..\Forms\MainProcessesForm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5AF1BE8F496C28C2DD591744355BA8EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EKS.Forms;
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
    /// MainProcessesForm
    /// </summary>
    public partial class MainProcessesForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CompanyNameLBL;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label VersionLBL;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseAddMenu;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseDeleteMenu;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseUpdateMenu;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseDataFindMenu;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DatabaseUserControl;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Forms\MainProcessesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MainDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/EKS;component/forms/mainprocessesform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\MainProcessesForm.xaml"
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
            
            #line 8 "..\..\..\Forms\MainProcessesForm.xaml"
            ((EKS.Forms.MainProcessesForm)(target)).Closed += new System.EventHandler(this.MPFClosed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Forms\MainProcessesForm.xaml"
            ((EKS.Forms.MainProcessesForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.WindowLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CompanyNameLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.VersionLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.DatabaseList = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseList.Click += new System.Windows.RoutedEventHandler(this.DatabaseListClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DatabaseAddMenu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseAddMenu.Click += new System.Windows.RoutedEventHandler(this.DatabaseAddMenuClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DatabaseDeleteMenu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 35 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseDeleteMenu.Click += new System.Windows.RoutedEventHandler(this.DatabaseDeleteMenuClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DatabaseUpdateMenu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 43 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseUpdateMenu.Click += new System.Windows.RoutedEventHandler(this.DatabaseUpdateMenuClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DatabaseDataFindMenu = ((System.Windows.Controls.MenuItem)(target));
            
            #line 51 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseDataFindMenu.Click += new System.Windows.RoutedEventHandler(this.DatabaseFindMenuClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DatabaseUserControl = ((System.Windows.Controls.MenuItem)(target));
            
            #line 59 "..\..\..\Forms\MainProcessesForm.xaml"
            this.DatabaseUserControl.Click += new System.Windows.RoutedEventHandler(this.DatabaseUserControlClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.MainDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

