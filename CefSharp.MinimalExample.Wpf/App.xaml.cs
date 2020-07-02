using CefSharp.Wpf;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using CefSharp.MinimalExample.Common.browser;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            ChromiumManager.Initialize();
        }


    }
}

