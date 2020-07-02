using System;
using System.IO;
using System.Linq;

namespace CefSharp.MinimalExample.Common.args
{
    public class CefArgmentsManager
    {
        private static string _configFile = @"config\cef_commandline_args.rcfg";

        private static CefCommandLineArgments CommandLineArgments { get; set; }
        public static bool DebugMode => CommandLineArgments.DebugMode;

        public static void Initialize()
        {
            int offset = 1;
            var tempConfigPath = FileHelper.GetPhysicalPath(_configFile);
            string configContent = "";
            if (File.Exists(tempConfigPath))
                configContent = File.ReadAllText(tempConfigPath);
            if (string.IsNullOrEmpty(configContent))
            {
                UseDefaultArgments();
                return;
            }
            try
            {
                var config = configContent.ToObjectFromXml<CefCommandLineArgments>();
                if (config != null)
                {
                    CommandLineArgments = config;
                }
                else
                {
                    UseDefaultArgments();
                }
            }
            catch (Exception e)
            {
                UseDefaultArgments();
            }
        }

        private static void UseDefaultArgments()
        {
            CommandLineArgments = new CefCommandLineArgments();
            CommandLineArgments.Add("show-fps-counter", "", UseAge.Debug, Target.Common);
            CommandLineArgments.Add("show-taps", string.Empty, UseAge.Debug, Target.Common);
            CommandLineArgments.Add("process-per-site", string.Empty, UseAge.None, Target.Common);
            CommandLineArgments.Add("ignore-urlfetcher-cert-requests", "1", UseAge.None, Target.Common);
            CommandLineArgments.Add("ignore-certificate-errors", "1", UseAge.None, Target.Common);
            CommandLineArgments.Add("enable-media-stream", "1", UseAge.None, Target.Common);
            CommandLineArgments.Add("enable-webgl", "1", UseAge.None, Target.Common);
            CommandLineArgments.Add("ignore-gpu-blacklist", "1", UseAge.None, Target.Common);
            CommandLineArgments.Add("allow-file-access-from-files", "1", UseAge.None, Target.Common);
            CommandLineArgments.DebugMode = false;
            SaveConfig();
        }


        private static void SaveConfig()
        {
            CommandLineArgments.ToXmlFile(FileHelper.GetPhysicalPath(_configFile));
        }


        public static void SetArgments(UseAge use, Target target, Action<CefCommandLineArgment> action)
        {
            var findArgments = CommandLineArgments.Argments.Where(o => use.HasFlag(o.Used) && target.HasFlag(o.Target) && TypeExtension.IsValid((string)o.Key));
            if (findArgments.Any())
            {
                findArgments.ForEach(p => { action(p); });
            }
        }
    }
}