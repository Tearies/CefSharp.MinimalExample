using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.MinimalExample.Common.args;
using NLog;
using NLog.Config;

namespace CefSharp.MinimalExample.Common.log
{
    public class Logger
    {
        private NLog.ILogger _DefaultLogger;

        public Logger()
        {
            NLog.GlobalDiagnosticsContext.Set("productpath", FileHelper.GetProductPath());
            this.LoadLogConfig();
        }

        private void LoadLogConfig()
        {
            NLog.Config.XmlLoggingConfiguration config = new XmlLoggingConfiguration(FileHelper.GetPhysicalPath("config\\nlog.config"), false);
            var factory = new NLog.LogFactory(config);
            _DefaultLogger = factory.GetLogger("DefaultLog");
        }

        /// <summary>
        /// 更改日志存储路径
        /// </summary>
        /// <param name="name"></param>
        public void UpdateLogPath(Func<string, string> func)
        {
            NLog.Config.XmlLoggingConfiguration config = new XmlLoggingConfiguration(FileHelper.GetPhysicalPath("config\\nlog.config"), true);
            foreach (var item in config.AllTargets)
            {
                var ftarget = item as NLog.Targets.FileTarget;
                if (ftarget == null) continue;
                var lay = ftarget.FileName as NLog.Layouts.SimpleLayout;
                lay.Text = func(lay.Text);
            }
            var factory = new NLog.LogFactory(config);
            _DefaultLogger = factory.GetLogger("DefaultLog");
        }

        public void Info(string message)
        {
            _DefaultLogger.Info(message);
        }

        public void Warn(string message)
        {
            _DefaultLogger.Warn(message);
        }

        public void Error(string message, Exception ex = null)
        {
            _DefaultLogger.Error(message + Environment.NewLine + ex.ToString());
        }

        public void Debug(string message)
        {
            _DefaultLogger.Debug(message);
        }

        /// <summary>
        /// 记录Trace信息
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message)
        {

            _DefaultLogger.Trace(message);
        }
    }
}
