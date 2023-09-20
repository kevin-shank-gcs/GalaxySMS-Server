////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Behaviors\ListBoxDragDropBehavior.cs
//
// summary:	Implements the list box drag drop behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GCS.Core.Common.UI.DragDrop;
using Telerik.Windows.Controls;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using DragEventArgs = Telerik.Windows.DragDrop.DragEventArgs;
using GiveFeedbackEventArgs = Telerik.Windows.DragDrop.GiveFeedbackEventArgs;

namespace GCS.Core.Common.UI.Behaviors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A list box drag drop behavior. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ListBoxDragDropBehavior
    {
        /// <summary>   The associated object control. </summary>
        private ListBox _associatedObject;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   AssociatedObject Property. </summary>
        ///
        /// <value> The associated object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ListBox AssociatedObject
        {
            get
            {
                return _associatedObject;
            }
            set
            {
                _associatedObject = value;
            }
        }

        /// <summary>   The instances. </summary>
        private static Dictionary<ListBox, ListBoxDragDropBehavior> instances;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Static constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static ListBoxDragDropBehavior()
        {
            instances = new Dictionary<ListBox, ListBoxDragDropBehavior>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets is enabled. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets is enabled. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">      The object. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            ListBoxDragDropBehavior behavior = GetAttachedBehavior(obj as ListBox);

            behavior.AssociatedObject = obj as ListBox;

            if (value)
            {
                behavior.Initialize();
            }
            else
            {
                behavior.CleanUp();
            }
            obj.SetValue(IsEnabledProperty, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Using a DependencyProperty as the backing store for IsEnabled.  This enables animation,
        /// styling, binding, etc...
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ListBoxDragDropBehavior),
                new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="e">                Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            SetIsEnabled(dependencyObject, (bool)e.NewValue);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets attached behavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="listBox">  The list box control. </param>
        ///
        /// <returns>   The attached behavior. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static ListBoxDragDropBehavior GetAttachedBehavior(ListBox listBox)
        {
            if (!instances.ContainsKey(listBox))
            {
                instances[listBox] = new ListBoxDragDropBehavior();
                instances[listBox].AssociatedObject = listBox;
            }

            return instances[listBox];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this ListBoxDragDropBehavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Initialize()
        {
            this.UnsubscribeFromDragDropEvents();
            this.SubscribeToDragDropEvents();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Clean up. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void CleanUp()
        {
            this.UnsubscribeFromDragDropEvents();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Subscribe to drag drop events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SubscribeToDragDropEvents()
        {
            DragDropManager.AddDragInitializeHandler(this.AssociatedObject, OnDragInitialize);
            DragDropManager.AddGiveFeedbackHandler(this.AssociatedObject, OnGiveFeedback);
            DragDropManager.AddDropHandler(this.AssociatedObject, OnDrop);
            DragDropManager.AddDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted);
            DragDropManager.AddDragOverHandler(this.AssociatedObject, OnDragOver);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Unsubscribe from drag drop events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UnsubscribeFromDragDropEvents()
        {
            DragDropManager.RemoveDragInitializeHandler(this.AssociatedObject, OnDragInitialize);
            DragDropManager.RemoveGiveFeedbackHandler(this.AssociatedObject, OnGiveFeedback);
            DragDropManager.RemoveDropHandler(this.AssociatedObject, OnDrop);
            DragDropManager.RemoveDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted);
            DragDropManager.RemoveDragOverHandler(this.AssociatedObject, OnDragOver);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the drag initialize event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnDragInitialize(object sender, DragInitializeEventArgs e)
        {
            DropIndicationDetails details = new DropIndicationDetails();
            var listBoxItem = e.OriginalSource as System.Windows.Controls.ListBoxItem ?? (e.OriginalSource as FrameworkElement).ParentOfType<System.Windows.Controls.ListBoxItem>();

            var item = listBoxItem != null ? listBoxItem.DataContext : (sender as System.Windows.Controls.ListBox).SelectedItem;
            details.CurrentDraggedItem = item;

            IDragPayload dragPayload = DragDropPayloadManager.GeneratePayload(null);

            dragPayload.SetData("DraggedData", item);
            dragPayload.SetData("DropDetails", details);

            e.Data = dragPayload;

            e.DragVisual = new DragVisual()
            {
                Content = details,
                ContentTemplate = this.AssociatedObject.Resources["DraggedItemTemplate"] as DataTemplate
            };
            e.DragVisualOffset = e.RelativeStartPoint;
            e.AllowedEffects = DragDropEffects.All;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the telerik. windows. drag drop. give feedback event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.SetCursor(Cursors.Arrow);
            e.Handled = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the drag drop completed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnDragDropCompleted(object sender, DragDropCompletedEventArgs e)
        {
            var draggedItem = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");

            if (e.Effects != DragDropEffects.None)
            {
                var collection = (sender as ListBox).ItemsSource as IList;
                collection.Remove(draggedItem);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the telerik. windows. drag drop. drag event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnDrop(object sender, DragEventArgs e)
        {
            var draggedItem = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");
            var details = DragDropPayloadManager.GetDataFromObject(e.Data, "DropDetails") as DropIndicationDetails;
            var itemsType = (this.AssociatedObject.ItemsSource as IList).AsQueryable().ElementType;

            if (details == null || draggedItem == null || draggedItem.GetType() != itemsType)
            {
                return;
            }

            if (e.Effects != DragDropEffects.None)
            {
                var collection = (sender as ListBox).ItemsSource as IList;
                collection.Add(draggedItem);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the telerik. windows. drag drop. drag event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnDragOver(object sender, DragEventArgs e)
        {
            var draggedItem = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");
            var itemsType = (this.AssociatedObject.ItemsSource as IList).AsQueryable().ElementType;

            if (draggedItem.GetType() != itemsType)
            {
                e.Effects = DragDropEffects.None;
            }

            var dropDetails = DragDropPayloadManager.GetDataFromObject(e.Data, "DropDetails") as DropIndicationDetails;
            dropDetails.CurrentDraggedOverItem = this.AssociatedObject;
            dropDetails.CurrentDropPosition = DropPosition.Inside;

            e.Handled = true;
        }
    }
}
