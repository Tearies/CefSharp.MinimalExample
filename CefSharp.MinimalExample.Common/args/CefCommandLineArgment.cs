using System.Xml.Serialization;

namespace CefSharp.MinimalExample.Common.args
{
    [XmlRoot("Argment")]
    public class CefCommandLineArgment
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public CefCommandLineArgment()
        {
        }

        public CefCommandLineArgment(string key, string value, UseAge useAge, Target target)
        {
            Key = key;
            Value = value;
            Used = useAge;
            Target = target;
        }

        public string Key { get; set; }

        [XmlElement("Value", Namespace = "", IsNullable = false)]
        public string Value { get; set; }

        public UseAge Used { get; set; }

        public Target Target { get; set; }

    }
}