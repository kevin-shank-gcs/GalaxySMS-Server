////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\RadPaneViewBase.cs
//
// summary:	Implements the radians pane view base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The radians pane view base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RadPaneViewBase : RadPane
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RadPaneViewBase()
        {
            if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
                this.FlowDirection = FlowDirection.RightToLeft;
            else
                this.FlowDirection = FlowDirection.LeftToRight;

            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding("ViewLoaded"));
            Unloaded += OnUnloaded;
            DataContextChanged += OnDataContextChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the routed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>   The view loaded property. </summary>
        public static readonly DependencyProperty ViewLoadedProperty =
            DependencyProperty.Register("ViewLoaded", typeof(object), typeof(UserControlViewBase),
            new PropertyMetadata(null));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the unwire view model events action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnUnwireViewModelEvents(ViewModelBase viewModel) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the wire view model events action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnWireViewModelEvents(ViewModelBase viewModel) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the system. windows. dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                if (e.OldValue != null)
                {
                    // view going out of scope and view-model disconnected (but still around in the parent)
                    // unwire events to allow view to dispose

                    OnUnwireViewModelEvents(e.OldValue as ViewModelBase);
                }
            }
            else
            {
                OnWireViewModelEvents(e.NewValue as ViewModelBase);
            }
        }
    }
}
