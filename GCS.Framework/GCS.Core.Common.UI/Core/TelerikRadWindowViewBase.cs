////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\TelerikRadWindowViewBase.cs
//
// summary:	Implements the telerik radians window view base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A telerik radians window view base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TelerikRadWindowViewBase : RadWindow
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TelerikRadWindowViewBase() : base()
        {
            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding("ViewLoaded"));

            DataContextChanged += OnDataContextChanged;
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

        //public static readonly DependencyProperty DialogResultProperty =
        //    DependencyProperty.RegisterAttached(
        //        "DialogResult",
        //        typeof(bool?),
        //        typeof(DialogCloser),
        //        new PropertyMetadata(DialogResultChanged));

        //private static void DialogResultChanged(
        //    DependencyObject d,
        //    DependencyPropertyChangedEventArgs e)
        //{
        //    var window = d as Window;
        //    if (window != null)
        //        window.DialogResult = e.NewValue as bool?;
        //}
        //public static void SetDialogResult(Window target, bool? value)
        //{
        //    target.SetValue(DialogResultProperty, value);
        //}
    }
}
