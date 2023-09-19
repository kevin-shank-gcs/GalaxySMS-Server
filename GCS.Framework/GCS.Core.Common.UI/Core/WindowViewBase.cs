////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\WindowViewBase.cs
//
// summary:	Implements the window view base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A window view base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class WindowViewBase : Window
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public WindowViewBase()
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

        /// <summary>   The dialog result property. </summary>
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Dialog result changed. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="d">    The DependencyObject to process. </param>
        /// <param name="e">    Dependency property changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void DialogResultChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets dialog result. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="target">   Target for the. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
