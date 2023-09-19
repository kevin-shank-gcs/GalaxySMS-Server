////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\CollectionBase.cs
//
// summary:	Implements the collection base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GCS.Core.Common.Contracts;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A collection base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CollectionBase<T> : ObservableCollection<T>, IDirtyCapable
           where T : ObjectBase
    {
        #region Property change notification
        
        /// <summary>   Event queue for all listeners interested in Item_Property_Changed events. </summary>
        event ItemPropertyChangedEventHandler<T> _ItemPropertyChangedEvent;

        /// <summary>   The item property changed subscribers. </summary>
        protected List<ItemPropertyChangedEventHandler<T>> _ItemPropertyChangedSubscribers = new List<ItemPropertyChangedEventHandler<T>>();

        /// <summary>   Event queue for all listeners interested in ItemPropertyChanged events. </summary>
        public event ItemPropertyChangedEventHandler<T> ItemPropertyChanged
        {
            add
            {
                if (!_ItemPropertyChangedSubscribers.Contains(value))
                {
                    _ItemPropertyChangedEvent += value;
                    _ItemPropertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                _ItemPropertyChangedEvent -= value;
                _ItemPropertyChangedSubscribers.Remove(value);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by item for property changed events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Property changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnItemPropertyChanged((T)sender, e.PropertyName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the item property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="item">         The object to insert. </param>
        /// <param name="propertyName"> Name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnItemPropertyChanged(T item, string propertyName)
        {
            if (_ItemPropertyChangedEvent != null)
                _ItemPropertyChangedEvent(this, new ItemPropertyChangedEventArgs<T>(item, propertyName));
        }

        #endregion

        #region IDirtyCapable members

        /// <summary>   True if this CollectionBase&lt;T&gt; is dirty. </summary>
        private bool _IsDirty = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this IDirtyCapable is dirty. </summary>
        ///
        /// <value> True if this IDirtyCapable is dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public virtual bool IsDirty
        {
            get
            {
                bool isDirty = false;
                
                foreach (var item in this)
                {
                    if (item.IsDirty)
                    {
                        isDirty = true;
                        break;
                    }
                }
                if (_IsDirty == true)
                    return _IsDirty;
                return isDirty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this IDirtyCapable is any property dirty. </summary>
        ///
        /// <value> True if this IDirtyCapable is any property dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public virtual bool IsAnyPropertyDirty
        {
            get
            {
                return IsDirty;
            }
        }


        /// <summary>   True if this CollectionBase&lt;T&gt; is panel data dirty. </summary>
        private bool _IsPanelDataDirty = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this IDirtyCapable is panel data dirty. </summary>
        ///
        /// <value> True if this IDirtyCapable is panel data dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [NotNavigable]
        public virtual bool IsPanelDataDirty
        {
            get
            {
                bool isDirty = false;

                foreach (var item in this)
                {
                    if (item.IsPanelDataDirty)
                    {
                        isDirty = true;
                        break;
                    }
                }
                if (_IsPanelDataDirty == true)
                    return _IsPanelDataDirty;
                return isDirty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if this IDirtyCapable is anything dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   True if anything dirty, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual bool IsAnythingDirty()
        {
            bool isDirty = false;

            foreach (var item in this)
            {
                if (item.IsAnythingDirty())
                {
                    isDirty = true;
                    break;
                }
            }

            if (_IsDirty == true)
                return _IsDirty;
            return isDirty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets dirty objects. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The dirty objects. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<IDirtyCapable> GetDirtyObjects()
        {
            List<IDirtyCapable> dirtyObjects = new List<IDirtyCapable>();

            foreach (var item in this)
                dirtyObjects.AddRange(item.GetDirtyObjects());

            return dirtyObjects;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clean all. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CleanAll()
        {
            _IsDirty = false;
            foreach (var item in this)
                item.CleanAll();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes the dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MakeDirty()
        {
            _IsDirty = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes panel data dirty. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MakePanelDataDirty()
        {
            _IsPanelDataDirty = true;
        }
        #endregion

        #region ObservableCollection<T> overrides

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
                item.PropertyChanged -= item_PropertyChanged;

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

        #endregion
    }
}
