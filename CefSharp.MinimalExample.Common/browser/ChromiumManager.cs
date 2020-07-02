using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CefSharp.MinimalExample.Common.args;

namespace CefSharp.MinimalExample.Common.browser
{
    public class ChromiumManager
    {
        static ChromiumManager()
        {
            CefArgmentsManager.Initialize();
        }
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
        }
    }
}