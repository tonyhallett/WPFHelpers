using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace WPFHelpers.XamlStrings
{
    public static class DataTemplateCreator
    {
        public static DataTemplate Create(string contents, params string[] additionalNamespaceAttributes)
        {
            IEnumerable<string> attributes = new string[] { XamlNamespacesHelper.PresentationAttribute, XamlNamespacesHelper.XAttribute }.Concat(additionalNamespaceAttributes);
            return (DataTemplate)
                XamlReader.Parse(
                     GetXamlString(contents, attributes)
                );
        }
        
        private static string GetXamlString(string contents, IEnumerable<string> attributes)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<DataTemplate");
            foreach (var attribute in attributes)
            {
                stringBuilder.Append($" {attribute}");
            }
            stringBuilder.Append(" >");
            stringBuilder.Append(contents);
            stringBuilder.Append("</DataTemplate>");
            return stringBuilder.ToString();
        }
    }
}
