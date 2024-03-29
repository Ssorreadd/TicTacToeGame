﻿#pragma checksum "..\..\SettingsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FA2DD21688A9EDC80EA7F18D18DDE627BB10A60ECA6A60A9716BE21A6A96AE4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using TicTacToe;


namespace TicTacToe {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Log;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UseRandomGeneration;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AI;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UseAI;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UseSessionData;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SessionsWindow;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox UseSoundManager;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveAndGoBack;
        
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
            System.Uri resourceLocater = new System.Uri("/TicTacToe;component/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingsWindow.xaml"
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
            
            #line 9 "..\..\SettingsWindow.xaml"
            ((TicTacToe.SettingsWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Log = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.UseRandomGeneration = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\SettingsWindow.xaml"
            this.UseRandomGeneration.Click += new System.Windows.RoutedEventHandler(this.Sound_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AI = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.UseAI = ((System.Windows.Controls.CheckBox)(target));
            
            #line 46 "..\..\SettingsWindow.xaml"
            this.UseAI.Click += new System.Windows.RoutedEventHandler(this.Sound_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UseSessionData = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\SettingsWindow.xaml"
            this.UseSessionData.Click += new System.Windows.RoutedEventHandler(this.Sound_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SessionsWindow = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\SettingsWindow.xaml"
            this.SessionsWindow.Click += new System.Windows.RoutedEventHandler(this.SessionsWindow_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.UseSoundManager = ((System.Windows.Controls.CheckBox)(target));
            
            #line 69 "..\..\SettingsWindow.xaml"
            this.UseSoundManager.Click += new System.Windows.RoutedEventHandler(this.Sound_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SaveAndGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\SettingsWindow.xaml"
            this.SaveAndGoBack.Click += new System.Windows.RoutedEventHandler(this.SaveAndGoBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

