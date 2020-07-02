using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace CefSharp.MinimalExample.Common.args
{
    [XmlRoot("CommandLineArgs")]
    public class CefCommandLineArgments
    {
        private static readonly Type thisType;
        static CefCommandLineArgments()
        {
            thisType = typeof(CefCommandLineArgments);
        }
        public CefCommandLineArgments()
        {
            Argments = new List<CefCommandLineArgment>();
        }

        [XmlAnyElement("ArgmentsXmlComment")]
        public XmlLinkedNode ArgmentsXmlComment { get { return thisType.GetXmlComment(); } set { } }

        [XmlElement(ElementName = "Argments")]
        [XmlComment("此配置将会影响高速浏览器的运行! 请不要轻易修改. 如果确实需要修改请联系相关开发人员.修改时请参考:https://peter.sh/experiments/chromium-command-line-switches/")]
        public List<CefCommandLineArgment> Argments { get; set; }


        [XmlAnyElement(nameof(DebugModeXmlComment))]
        public XmlLinkedNode DebugModeXmlComment { get { return thisType.GetXmlComment(); } set { } }
        [XmlComment("CEF组件是否启用调试参数, 如果启用 命令行参数中标记为Debug的参数会生效!")]
        public bool DebugMode { get; set; }

        public void Add(string key, string value, UseAge useAge,Target target)
        {
            Argments.Add(new CefCommandLineArgment(key, value, useAge,target));
        }
    }
}