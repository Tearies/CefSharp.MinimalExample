using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CefSharp.MinimalExample.Common.browser;
using CefSharp.Wpf;

namespace CefSharp.MinimalExample.FlushTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ChromiumManager.Initialize();
        }
    }
}
