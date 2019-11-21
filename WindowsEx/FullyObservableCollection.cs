using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Woof.WindowsEx {

    /// <summary>
    /// Represents a dynamic data collection that provides notifications when items get
    /// added, removed, when the whole list is refreshed or when a property of an item is changed.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection, must implement INotifyPropertyChanged.</typeparam>
    public class FullyObservableCollection<T> : ObservableCollectionEx<T> where T: INotifyPropertyChanged {

        /// <summary>
        /// Creates an empty observable collection.
        /// </summary>
        public FullyObservableCollection() { }

        /// <summary>
        /// Creates an observable collection from any base collection.
        /// </summary>
        /// <param name="baseCollection">Any collection.</param>
        public FullyObservableCollection(IEnumerable<T> baseCollection) : base(baseCollection) { }

        /// <summary>
        /// Add the item to the collection.
        /// When <see cref="ObservableCollection{T}"/> is not bound directly to WPF, but another <see cref="ObservableCollection{T}"/>,
        /// this will propagate collection property changed events properly.
        /// </summary>
        /// <param name="item">Item.</param>
        public void AddAndObserve(T item) {
            Items.Add(item);
            item.PropertyChanged += OnItemPropertyChanged;
        }

        /// <summary>
        /// Adds a collection of items and triggers notification after all items are added.
        /// When <see cref="ObservableCollection{T}"/> is not bound directly to WPF, but another <see cref="ObservableCollection{T}"/>,
        /// this will propagate collection property changed events properly.
        /// </summary>
        /// <param name="items">Items collection.</param>
        public void AddAndObserve(IEnumerable<T> items) {
            IsNotificationDisabled = true;
            foreach (var item in items) {
                Items.Add(item);
                item.PropertyChanged += OnItemPropertyChanged;
            }
            IsNotificationDisabled = false;
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }

        /// <summary>
        /// Notifies collection the item's property is changed and the item should be updated.
        /// </summary>
        /// <param name="sender">Item.</param>
        /// <param name="e">Event arguments.</param>
        protected void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (!(sender is T item)) throw new ArgumentException($"Invalid argument type: {sender.GetType().Name}, {typeof(T).Name} expected", nameof(sender));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }


    }

}