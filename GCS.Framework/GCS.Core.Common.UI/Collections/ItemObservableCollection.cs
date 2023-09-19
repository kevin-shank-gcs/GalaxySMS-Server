////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Collections\ItemObservableCollection.cs
//
// summary:	Implements the item observable collection class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GCS.Core.Common.UI.Collections
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Collection of item observables. This class cannot be inherited. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed class ItemObservableCollection<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
    {
        /// <summary>   Event queue for all listeners interested in ItemPropertyChanged events. </summary>
        public event EventHandler<ItemPropertyChangedEventArgs<T>> ItemPropertyChanged;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserts an item into the collection at the specified index. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="index">    The zero-based index at which <paramref name="item" /> should be
        ///                         inserted. </param>
        /// <param name="item">     The object to insert. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            item.PropertyChanged += item_PropertyChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the item at the specified index of the collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="index">    The zero-based index of the element to remove. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            base.RemoveItem(index);
            item.PropertyChanged -= item_PropertyChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes all items from the collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.PropertyChanged -= item_PropertyChanged;
            }

            base.ClearItems();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Replaces the element at the specified index. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="index">    The zero-based index of the element to replace. </param>
        /// <param name="item">     The new value for the element at the specified index. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void SetItem(int index, T item)
        {
            var oldItem = this[index];
            oldItem.PropertyChanged -= item_PropertyChanged;
            base.SetItem(index, item);
            item.PropertyChanged += item_PropertyChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by item for property changed events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Property changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnItemPropertyChanged((T)sender, e.PropertyName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the item property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="item">         The item. </param>
        /// <param name="propertyName"> Name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnItemPropertyChanged(T item, string propertyName)
        {
            var handler = this.ItemPropertyChanged;

            if (handler != null)
            {
                handler(this, new ItemPropertyChangedEventArgs<T>(item, propertyName));
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Additional information for item property changed events. This class cannot be inherited.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed class ItemPropertyChangedEventArgs<T> : EventArgs
    {
        /// <summary>   The item. </summary>
        private readonly T _item;
        /// <summary>   Name of the property. </summary>
        private readonly string _propertyName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="item">         The item. </param>
        /// <param name="propertyName"> The name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ItemPropertyChangedEventArgs(T item, string propertyName)
        {
            _item = item;
            _propertyName = propertyName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the item. </summary>
        ///
        /// <value> The item. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T Item
        {
            get { return _item; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the name of the property. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}
