////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Behaviors\MultiSelectBehavior.cs
//
// summary:	Implements the multi select behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System;

namespace GCS.Core.Common.UI.Behaviors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A sync behavior for a multi-selector. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class MultiSelectorBehaviours
    {
        /// <summary>   The synchronized selected items. </summary>
        public static readonly DependencyProperty SynchronizedSelectedItems = DependencyProperty.RegisterAttached(
            "SynchronizedSelectedItems", typeof(IList), typeof(MultiSelectorBehaviours), new PropertyMetadata(null, OnSynchronizedSelectedItemsChanged));

        /// <summary>   The synchronization manager property. </summary>
        private static readonly DependencyProperty SynchronizationManagerProperty = DependencyProperty.RegisterAttached(
            "SynchronizationManager", typeof(SynchronizationManager), typeof(MultiSelectorBehaviours), new PropertyMetadata(null));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the synchronized selected items. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        ///
        /// <returns>   The list that is acting as the sync list. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IList GetSynchronizedSelectedItems(DependencyObject dependencyObject)
        {
            return (IList)dependencyObject.GetValue(SynchronizedSelectedItems);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the synchronized selected items. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="value">            The value to be set as synchronized items. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetSynchronizedSelectedItems(DependencyObject dependencyObject, IList value)
        {
            dependencyObject.SetValue(SynchronizedSelectedItems, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets synchronization manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        ///
        /// <returns>   The synchronization manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static SynchronizationManager GetSynchronizationManager(DependencyObject dependencyObject)
        {
            return (SynchronizationManager)dependencyObject.GetValue(SynchronizationManagerProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets synchronization manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="value">            The value to be set as synchronized items. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void SetSynchronizationManager(DependencyObject dependencyObject, SynchronizationManager value)
        {
            dependencyObject.SetValue(SynchronizationManagerProperty, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="e">                Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void OnSynchronizedSelectedItemsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                SynchronizationManager synchronizer = GetSynchronizationManager(dependencyObject);
                synchronizer.StopSynchronizing();

                SetSynchronizationManager(dependencyObject, null);
            }

            IList list = e.NewValue as IList;
            Selector selector = dependencyObject as Selector;

            // check that this property is an IList, and that it is being set on a ListBox
            if (list != null && selector != null)
            {
                SynchronizationManager synchronizer = GetSynchronizationManager(dependencyObject);
                if (synchronizer == null)
                {
                    synchronizer = new SynchronizationManager(selector);
                    SetSynchronizationManager(dependencyObject, synchronizer);
                }

                synchronizer.StartSynchronizingList();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A synchronization manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private class SynchronizationManager
        {
            /// <summary>   The multi selector. </summary>
            private readonly Selector _multiSelector;
            /// <summary>   The synchronizer. </summary>
            private TwoListSynchronizer _synchronizer;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Initializes a new instance of the <see cref="SynchronizationManager"/> class.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="selector"> The selector. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            internal SynchronizationManager(Selector selector)
            {
                _multiSelector = selector;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Starts synchronizing the list. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public void StartSynchronizingList()
            {
                IList list = GetSynchronizedSelectedItems(_multiSelector);

                if (list != null)
                {
                    _synchronizer = new TwoListSynchronizer(GetSelectedItemsCollection(_multiSelector), list);
                    _synchronizer.StartSynchronizing();
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Stops synchronizing the list. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public void StopSynchronizing()
            {
                _synchronizer.StopSynchronizing();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets selected items collection. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <exception cref="InvalidOperationException">    Thrown when the requested operation is
            ///                                                 invalid. </exception>
            ///
            /// <param name="selector"> The selector. </param>
            ///
            /// <returns>   The selected items collection. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static IList GetSelectedItemsCollection(Selector selector)
            {
                if (selector is MultiSelector)
                {
                    return (selector as MultiSelector).SelectedItems;
                }
                else if (selector is ListBox)
                {
                    return (selector as ListBox).SelectedItems;
                }
                else
                {
                    throw new InvalidOperationException("Target object has no SelectedItems property to bind.");
                }
            }

        }
    }
}
