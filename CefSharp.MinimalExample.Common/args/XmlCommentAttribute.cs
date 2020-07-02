using System;

namespace CefSharp.MinimalExample.Common.args
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public class XmlCommentAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Attribute" /> class.</summary>
        public XmlCommentAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; protected set; }
    }
}