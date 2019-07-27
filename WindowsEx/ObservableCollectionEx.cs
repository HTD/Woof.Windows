using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Woof.WindowsEx {

    /// <summary>
    /// Represents a dynamic data collection that provides notifications when items get
    /// added, removed, or when the whole list is refreshed.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class ObservableCollectionEx<T> : ObservableCollection<T> {

        /// <summary>
        /// Creates an empty observable collection.
        /// </summary>
        public ObservableCollectionEx() { }

        /// <summary>
        /// Creates an observable collection from any base collection.
        /// </summary>
        /// <param name="baseCollection">Any collection.</param>
        public ObservableCollectionEx(IEnumerable<T> baseCollection) => Add(baseCollection);

        /// <summary>
        /// Adds a collection of items and triggers notification after all items are added.
        /// </summary>
        /// <param name="items"></param>
        public virtual void Add(IEnumerable<T> items) {
            IsNotificationDisabled = true;
            foreach (var item in items) Items.Add(item);
            IsNotificationDisabled = false;
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Raises CollectionChanged event if notification is not disabled with adding items from source collection.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
            if (!IsNotificationDisabled) base.OnCollectionChanged(e);
        }

        /// <summary>
        /// Set true to disable notifications.
        /// </summary>
        protected bool IsNotificationDisabled;

    }

}