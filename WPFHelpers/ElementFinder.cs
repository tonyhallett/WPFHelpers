using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFHelpers
{
    public static class ElementFinder
    {
        public static IEnumerable<DependencyObject> GetChildObjects(
                                            this DependencyObject parent)
        {
            if (parent == null)
                yield break;


            if (parent is ContentElement || parent is FrameworkElement)
            {
                //use the logical tree for content / framework elements
                foreach (object obj in LogicalTreeHelper.GetChildren(parent))
                {
                    if (obj is DependencyObject depObj)
                        yield return depObj;
                }
            }
            else
            {
                //use the visual tree per default
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    yield return VisualTreeHelper.GetChild(parent, i);
                }
            }
        }

        public static IEnumerable<T> FindChildren<T>(this DependencyObject source)
                                             where T : DependencyObject
        {
            if (source != null)
            {
                var childs = GetChildObjects(source);
                foreach (DependencyObject child in childs)
                {
                    //analyze if children match the requested type
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }

                    //recurse tree
                    foreach (T descendant in FindChildren<T>(child))
                    {
                        yield return descendant;
                    }
                }
            }
        }
    }
}
