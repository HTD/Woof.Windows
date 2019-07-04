using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace Woof.WindowsEx {

    /// <summary>
    /// A trigger action that allows mapping events to commands.
    /// </summary>
    public sealed class EventToCommand : TriggerAction<DependencyObject> {

        /// <summary>
        /// Command property definition.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(EventToCommand), null);

        /// <summary>
        /// Tag property definition.
        /// </summary>
        public static readonly DependencyProperty TagProperty = DependencyProperty.Register(
            "Tag", typeof(object), typeof(EventToCommand), null);

        /// <summary>
        /// Gets or sets the command property.
        /// </summary>
        public ICommand Command {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the tag property.
        /// </summary>
        public object Tag {
            get => GetValue(TagProperty);
            set => SetValue(TagProperty, value);
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Invoke(object parameter) => Command.Execute(new Data(AssociatedObject, parameter, Tag));


        /// <summary>
        /// Complete event data for <see cref="EventToCommand"/> trigger action.
        /// </summary>
        public sealed class Data {

            /// <summary>
            /// Gets the event sender.
            /// </summary>
            public object Sender { get; }

            /// <summary>
            /// Gets the event arguments.
            /// </summary>
            public object Arguments { get; }

            /// <summary>
            /// Gets the optional trigger action tag.
            /// </summary>
            public object Tag { get; }

            /// <summary>
            /// Creates the <see cref="Data"/>.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="arguments"></param>
            /// <param name="tag"></param>
            public Data(object sender, object arguments, object tag = null) {
                Sender = sender;
                Arguments = arguments;
                Tag = tag;
            }

        }

    }

}
