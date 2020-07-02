using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CefSharp.MinimalExample.Common.args;
using CefSharp.MinimalExample.Common.log;

namespace CefSharp.MinimalExample.Common.browser
{
    public class ChromiumManager
    {
        static ChromiumManager()
        {
            CefArgmentsManager.Initialize();
        }

        private static BrowserSettings CreateBrowserSettings()
        {
            BrowserSettings browserSettings = null;
            var coninfo = typeof(BrowserSettings).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, CallingConventions.Any, new[] { typeof(bool) }, new[] { new ParameterModifier(1) });
            if (coninfo != null)
                browserSettings = (BrowserSettings)coninfo.Invoke(BindingFlags.NonPublic, null, new object[] { true }, CultureInfo.CurrentCulture);
            else
                browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            browserSettings.LocalStorage = CefState.Enabled;
            browserSettings.ApplicationCache = CefState.Enabled;
            return browserSettings;
        }

        public static BrowserSettings BrowserSetting => CreateBrowserSettings();

        public static void Initialize()
        {
            var setting = new CefSetting();
            setting.LogFile = FileHelper.GetPhysicalPath(
                $"./logs/{Assembly.GetEntryAssembly().GetName().Name}/{Process.GetCurrentProcess().Id}.cefSharp.log");
            setting.SetArgments();
            setting.WindowlessRenderingEnabled = setting.CurrentRuntimeTarget == Target.WPF;
            setting.Locale = CultureInfo.CurrentCulture.IetfLanguageTag;
            setting.AcceptLanguageList = CultureInfo.CurrentCulture.IetfLanguageTag;
            setting.RemoteDebuggingPort = SocketPort.GetNextTCPPort();
            setting.LogSeverity = LogSeverity.Error;
            setting.MultiThreadedMessageLoop = true;
            setting.ExternalMessagePump = false;
            setting.UncaughtExceptionStackSize = 10;
            setting.PersistUserPreferences = false;
            setting.IgnoreCertificateErrors = true;

            Cef.EnableHighDPISupport();
            CefSharpSettings.ShutdownOnExit = true;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            CefSharpSettings.SubprocessExitIfParentProcessClosed = true;
            Cef.Initialize(setting, performDependencyCheck: true, browserProcessHandler: null);
            Log.Info(
                $"CEF Settings:{JsonHelper.SerializeObject(setting)} BrowserSetting:{JsonHelper.SerializeObject(BrowserSetting)} ");
            Log.Info(
                $"CEF Version:[cefSharp({Cef.CefSharpVersion})-cef({Cef.CefVersion})-Chromium({Cef.ChromiumVersion})-Commit({Cef.CefCommitHash})");
        }
    }
}