using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Woof.WindowsEx {

    /// <summary>
    /// Extends Application allowing disposing registered disposable objects when the application exits.
    /// </summary>
    public static class ApplicationExtensions {

        /// <summary>
        /// Register a disposable object to dispose when the application exits.
        /// </summary>
        /// <param name="application">This application.</param>
        /// <param name="disposable">Disposable object not disposed before application exits.</param>
        public static void RegisterDisposable(this Application application, IDisposable disposable) {
            if (!ApplicationDisposables.Any()) {
                application.Exit += DisposeRegistered;
                application.DispatcherUnhandledException += DisposeRegistered;
            }
            ApplicationDisposables.Push(disposable);
        }

        /// <summary>
        /// Disposes all registered disposable objects.
        /// </summary>
        /// <param name="sender">Application.</param>
        /// <param name="e">Ignored.</param>
        private static void DisposeRegistered(object sender, EventArgs e) {
            lock (ApplicationDisposables) while (ApplicationDisposables.Any()) ApplicationDisposables.Pop().Dispose();
        }

        /// <summary>
        /// A stack of registered application disposable objects.
        /// </summary>
        public static readonly Stack<IDisposable> ApplicationDisposables = new Stack<IDisposable>();

    }

}