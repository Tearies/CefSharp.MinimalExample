using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using CefSharp.MinimalExample.Common.args;

namespace CefSharp.MinimalExample.Common.browser
{
    public class CefSetting : CefSettingsBase
    {

        public Target CurrentRuntimeTarget
        {
            get;
            private set;
        }

        /// <summary>Default Constructor.</summary>
        public CefSetting()
        {
            if (AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(o=>o.GetName(true).Name=="WindowsBase") != null)
            {
                CurrentRuntimeTarget = Target.WPF;
            }
            else if (AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(o => o.GetName(true).Name == "System.Windows.Forms") != null)
            {
                CurrentRuntimeTarget = Target.Winform;
            }
          
        }

        private void AddCommandLine(CefCommandLineArgment cefCommandLineArgment)
        {
            if (CefCommandLineArgs.ContainsKey(cefCommandLineArgment.Key))
            {
                CefCommandLineArgs[cefCommandLineArgment.Key] = cefCommandLineArgment.Value;
            }
            else
            {
                CefCommandLineArgs.Add(cefCommandLineArgment.Key, cefCommandLineArgment.Value.ToString());
            }
         
        }
         
        public void SetArgments()
        {
            CefArgmentsManager.SetArgments(UseAge.None, Target.Common, AddCommandLine);
            CefArgmentsManager.SetArgments(UseAge.None,CurrentRuntimeTarget,AddCommandLine);
        }
    }
}