using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CefSharp.MinimalExample.Common.args
{
    public static class XmlCommentExtensions
    {
        const string XmlCommentPropertyPostfix = "XmlComment";

        private static XmlCommentAttribute GetXmlCommentAttribute(this Type type, string memberName, bool classDocument)
        {
            if (classDocument)
            {
                return type.GetCustomAttribute<XmlCommentAttribute>();
            }
            var member = type.GetProperty(memberName);
            if (member == null)
                return null;
            var attr = member.GetCustomAttribute<XmlCommentAttribute>();
            return attr;
        }

        public static XmlComment GetXmlComment(this Type type, [CallerMemberName] string memberName = "", bool classDocument = false)
        {
            var attr = GetXmlCommentAttribute(type, memberName, classDocument);
            if (attr == null)
            {
                if (memberName.EndsWith(XmlCommentPropertyPostfix))
                    attr = GetXmlCommentAttribute(type, memberName.Substring(0, memberName.Length - XmlCommentPropertyPostfix.Length), classDocument);
            }
            if (attr == null || string.IsNullOrEmpty(attr.Value))
                return null;
            return new XmlDocument().CreateComment(attr.Value);
        }
    }
}