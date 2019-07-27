using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Woof.WindowsEx {

    /// <summary>
    /// Provides extensions for <see cref="Visual"/>.
    /// </summary>
    public static class VisualExtensions {

        /// <summary>
        /// Searches visual tree forward using fast DFS algorithm and returns first matching element.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="v">This visual.</param>
        /// <returns>Matched visual or null.</returns>
        public static T FirstVisualDescendantOfType<T>(this Visual v) where T : Visual {
            var stack = new Stack<Visual>();
            stack.Push(v);
            while (stack.Any()) {
                v = stack.Pop();
                if (v is T) return v as T;
                if (v is FrameworkElement) (v as FrameworkElement).ApplyTemplate();
                for (int i = 0, n = VisualTreeHelper.GetChildrenCount(v); i < n; i++) stack.Push(VisualTreeHelper.GetChild(v, i) as Visual);
            }
            return default;
        }

    }

}