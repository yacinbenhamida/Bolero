﻿#pragma checksum "..\..\..\Layouts\ModifierMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A0FC0A52027179BCFBE2453C84D4FD25"
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


namespace Bolero {
    
    
    /// <summary>
    /// ModifierMenu
    /// </summary>
    public partial class ModifierMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSupprimer;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnuler;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifier;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSauvegarder;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjouter;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDate;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Layouts\ModifierMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHeure;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolero;component/layouts/modifiermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Layouts\ModifierMenu.xaml"
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
            
            #line 4 "..\..\..\Layouts\ModifierMenu.xaml"
            ((Bolero.ModifierMenu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnSupprimer = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Layouts\ModifierMenu.xaml"
            this.btnSupprimer.Click += new System.Windows.RoutedEventHandler(this.btnSupprimer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAnnuler = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Layouts\ModifierMenu.xaml"
            this.btnAnnuler.Click += new System.Windows.RoutedEventHandler(this.btnAnnuler_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnModifier = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Layouts\ModifierMenu.xaml"
            this.btnModifier.Click += new System.Windows.RoutedEventHandler(this.btnModifier_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSauvegarder = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Layouts\ModifierMenu.xaml"
            this.btnSauvegarder.Click += new System.Windows.RoutedEventHandler(this.btnSauvegarder_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAjouter = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\Layouts\ModifierMenu.xaml"
            this.btnAjouter.Click += new System.Windows.RoutedEventHandler(this.btnAjouter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblDate = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblHeure = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

