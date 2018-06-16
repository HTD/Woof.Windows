using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Woof.WindowsEx {

    /// <summary>
    /// Simplest possible base for WPF view-models.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, ICommand {

        /// <summary>
        /// Occurs when a visual control checks if a command associated with it can be executed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Occurs when bound property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Override this to provide data validation. Return true to enable execute.
        /// </summary>
        /// <param name="parameter">Optional parameter passed from visual control.</param>
        /// <returns></returns>
        virtual public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Override this to provide action on control's command.
        /// </summary>
        /// <param name="parameter">Optional parameter passed from visual control.</param>
        virtual public void Execute(object parameter) { }

        /// <summary>
        /// Notifies the view the property was changed and it needs to update.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Trigger to enable or disable command control.
        /// </summary>
        protected virtual void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }

}