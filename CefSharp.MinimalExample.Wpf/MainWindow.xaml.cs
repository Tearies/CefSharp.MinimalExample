using System.Globalization;
using System.Windows;
using CefSharp.MinimalExample.Common;
using CefSharp.MinimalExample.Common.browser;
using CefSharp.MinimalExample.Common.data;
using CefSharp.MinimalExample.Common.log;
using CefSharp.Wpf;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Browser = new ChromiumWebBrowser();
            Browser.BrowserSettings = ChromiumManager.BrowserSetting;
            Browser.WebBrowser.ConsoleMessage += OnBrowserConsoleMessage;
            Browser.WebBrowser.StatusMessage += OnBrowserStatusMessage;
            this.RegisterName("Browser", Browser);
            //Browser.RegisterAsyncJsObject();
            Browser.JavascriptObjectRepository.Register("callBack", DataProvider.CallBackObject, isAsync: true, new BindingOptions { CamelCaseJavascriptNames = false });
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }


        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            Log.Error(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            
            Log.Info(args.Value);
        }

        private ChromiumWebBrowser Browser { get; set; }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Browser.LoadingStateChanged -= Browser_LoadingStateChanged;
            DataProvider.CallBackObject.WebBrowserCallBack -= CallBackObject_WebBrowserCallBack;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BrowserContent.Content = Browser;
            DataProvider.CallBackObject.WebBrowserCallBack += CallBackObject_WebBrowserCallBack;
     
            this.Browser.LoadingStateChanged += Browser_LoadingStateChanged;
        }

        private void CallBackObject_WebBrowserCallBack(object sender, GanttBoundObjectEventArgs e)
        {
            MessageBox.Show($"{e.GanttCallBackName}({e.Data})");
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

    }
}
