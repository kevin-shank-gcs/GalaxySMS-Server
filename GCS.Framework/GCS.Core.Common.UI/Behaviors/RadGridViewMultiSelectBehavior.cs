////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Behaviors\RadGridViewMultiSelectBehavior.cs
//
// summary:	Implements the radians grid view multi select behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;
using System.Collections.Specialized;
using System.Windows;
using System.Collections;


namespace GCS.Core.Common.UI.Behaviors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   my multi select behavior. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MyMultiSelectBehavior : Behavior<RadGridView>
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the grid. </summary>
        ///
        /// <value> The grid. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private RadGridView Grid
        {
            get { return AssociatedObject as RadGridView; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected items. </summary>
        ///
        /// <value> The selected items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public INotifyCollectionChanged SelectedItems
        {
            get { return (INotifyCollectionChanged) GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Using a DependencyProperty as the backing store for SelectedItemsProperty.  This enables
        /// animation, styling, binding, etc...
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof (INotifyCollectionChanged),
                typeof (MyMultiSelectBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        /// <param name="args">     Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void OnSelectedItemsPropertyChanged(DependencyObject target,
            DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged += ((MyMultiSelectBehavior) target).ContextSelectedItems_CollectionChanged;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Called after the behavior is attached to an AssociatedObject. </summary>
        ///
        /// <remarks>   Override this to hook up functionality to the AssociatedObject. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnAttached()
        {
            base.OnAttached();

            Grid.SelectedItems.CollectionChanged += GridSelectedItems_CollectionChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by ContextSelectedItems for collection changed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Notify collection changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();

            Transfer(SelectedItems as IList, Grid.SelectedItems);

            SubscribeToEvents();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event handler. Called by GridSelectedItems for collection changed events.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Notify collection changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void GridSelectedItems_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UnsubscribeFromEvents();

            Transfer(Grid.SelectedItems, SelectedItems as IList);

            SubscribeToEvents();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Subscribe to events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SubscribeToEvents()
        {
            Grid.SelectedItems.CollectionChanged += GridSelectedItems_CollectionChanged;

            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged += ContextSelectedItems_CollectionChanged;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Unsubscribe from events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UnsubscribeFromEvents()
        {
            Grid.SelectedItems.CollectionChanged -= GridSelectedItems_CollectionChanged;

            if (SelectedItems != null)
            {
                SelectedItems.CollectionChanged -= ContextSelectedItems_CollectionChanged;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Transfers. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="source">   Source for the. </param>
        /// <param name="target">   Target for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Transfer(IList source, IList target)
        {
            if (source == null || target == null)
                return;

            target.Clear();

            foreach (var o in source)
            {
                target.Add(o);
            }
        }
    }

}
