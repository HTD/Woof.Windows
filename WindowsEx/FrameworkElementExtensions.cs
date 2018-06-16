using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Woof.WindowsEx {

    /// <summary>
    /// Provides extensions for <see cref="FrameworkElement"/>.
    /// </summary>
    public static class FrameworkElementExtensions {

        /// <summary>
        /// Finds ancestor of a framework element.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="e">This element.</param>
        /// <param name="level">Ancestor level - 1 is parent, 2 is grandparent and so on.</param>
        /// <returns>Matched element or null.</returns>
        public static T Ancestor<T>(this FrameworkElement e, int level = 1) where T : FrameworkElement {
            var target = e.Parent as FrameworkElement;
            while (target != null && (!(target is T) || --level > 0)) target = target.Parent as FrameworkElement;
            return target as T;
        }

        /// <summary>
        /// Fades out the element.
        /// </summary>
        /// <param name="e">Element to fade out/</param>
        /// <param name="delay">Delay in seconds.</param>
        /// <param name="duration">Fading duration in seconds.</param>
        /// <returns>Awaitable task.</returns>
        public static async Task FadeOutAsync(this FrameworkElement e, double delay, double duration) {
            await Task.Delay((int)(1000d * delay));
            using (var s1 = new SemaphoreSlim(0, 1)) {
                Application.Current.Dispatcher.Invoke(() => {
                    var a = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(duration)), FillBehavior.Stop);
                    a.Completed += (s, e1) => { e.Visibility = Visibility.Hidden; s1.Release(); };
                    e.BeginAnimation(UIElement.OpacityProperty, a);
                });
                await s1.WaitAsync();
            }
        }

    }

}