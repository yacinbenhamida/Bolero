﻿#pragma checksum "..\..\..\Layout\AccesSessionCaissier2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F3201F21272E54DB1FFAC4E0A0FB3FCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.17929
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
    /// AccesSessionCaissier2
    /// </summary>
    public partial class AccesSessionCaissier2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label User;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPW;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtOubli;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtNotice;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Layout\AccesSessionCaissier2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDate;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Layout\AccesSessionCaissier2.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Bolero;component/layout/accessessioncaissier2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Layout\AccesSessionCaissier2.xaml"
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
            
            #line 5 "..\..\..\Layout\AccesSessionCaissier2.xaml"
            ((Bolero.AccesSessionCaissier2)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\..\Layout\AccesSessionCaissier2.xaml"
            ((Bolero.AccesSessionCaissier2)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.User = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtPW = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.txtOubli = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 24 "..\..\..\Layout\AccesSessionCaissier2.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Layout\AccesSessionCaissier2.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtNotice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.lblDate = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblHeure = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

