using System;
using System.Collections.Generic;
using System.Text;

namespace WPFHelpers.XamlStrings
{
    public static class XamlNamespacesHelper
    {
        private const string Presentation = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        private const string X = "http://schemas.microsoft.com/winfx/2006/xaml";
        private const string XMLNS = "xmlns";
        public const string Clr = "clr-namespace";
        public static string PresentationAttribute { get; } = AttributeAndValue(Presentation, XMLNS);
        public static string XAttribute { get; } = AttributeAndValue(X, XMLNS, "x");
        public static string AttributeAndValue(string value,string attributeName,string prefix = null)
        {
            var attribute = prefix == null ? attributeName : $"{attributeName}:{prefix}";
            return $"{attribute}='{value}'";
        }

        public static string NamespaceAttribute(string value,string prefix = null)
        {
            return AttributeAndValue(value, XMLNS, prefix);
        }

        public static string FromType(Type type,string prefix)
        {
            var attributeValue = $"{Clr}:{type.Namespace};assembly={type.Assembly.FullName}";
            return NamespaceAttribute(attributeValue, prefix);
        }

        public static string EmptyElement(string type, IEnumerable<string> attributes)
        {
            var sb = new StringBuilder();
            sb.Append($"<{type}");
            foreach(var attribute in attributes)
            {
                sb.Append($" {attribute}");
            }
            sb.Append("/>");
            return sb.ToString();
        }

        public static string ClrAttribute(string prefix, string @namespace, string assembly)
        {
            return NamespaceAttribute($"{Clr}:{@namespace};assembly={assembly}",prefix);
        }
    }
}
