﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;

namespace CefSharp.MinimalExample.FlushTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Browser = new ChromiumWebBrowser();
            Browser.BrowserSettings = new BrowserSettings();
            Browser.BrowserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            Browser.BrowserSettings.WindowlessFrameRate = 25;
            Browser.BrowserSettings.BackgroundColor = 444444U;
            this.RegisterName("Browser", Browser);
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }



        private ChromiumWebBrowser Browser { get; set; }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Browser.LoadingStateChanged -= Browser_LoadingStateChanged;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BrowserContent.Content = Browser;
             
            Browser.Address = "http://www.baidu.com";
            this.Browser.LoadingStateChanged += Browser_LoadingStateChanged;
        }

      

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

    }
}
