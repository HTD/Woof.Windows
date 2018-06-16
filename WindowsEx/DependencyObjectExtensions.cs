using System.Windows;
using System.Windows.Media;

namespace Woof.WindowsEx {

    /// <summary>
    /// Provides extensions for <see cref="DependencyObject"/>.
    /// </summary>
    public static class DependencyObjectExtensions {

        /// <summary>
        /// Finds ancestor of a <see cref="DependencyObject"/>.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="d">This object.</param>
        /// <param name="level">Ancestor level - 1 is parent, 2 is grandparent and so on.</param>
        /// <returns>Matched descendant or null.</returns>
        public static T Ancestor<T>(this DependencyObject d, int level = 1) where T : DependencyObject {
            var item = d;
            while (item != null && (!(item is T) || --level > 0)) item = VisualTreeHelper.GetParent(item);
            return item as T;
        }

    }

}