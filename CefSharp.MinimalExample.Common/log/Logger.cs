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

    public static class Log
    {
        private static Logger InnerLoger;

        static Log()
        {
            InnerLoger = new Logger();
        }

        
        /// <summary>
        /// 记录消息日志
        /// </summary>
        public static void Info(string message)
        {
            InnerLoger.Info(message);
        }
        /// <summary>
        /// 向日志文件中写入 “警告内容”。
        /// </summary>
        public static void Warn(string message)
        {
            InnerLoger.Warn(message);
        }
        /// <summary>
        /// 记录错误消息
        /// </summary>
        public static void Error(string message, Exception ex = null)
        {
            InnerLoger.Error(message, ex);
        }
        /// <summary>
        /// 记录调试信息
        /// </summary>
        public static void Debug(string message)
        {
            InnerLoger.Debug(message);
        }

        /// <summary>
        /// 向日志文件中写入Trace
        /// </summary>
        public static void Trace(string message)
        {
            InnerLoger.Trace(message);
        }
    }
}
