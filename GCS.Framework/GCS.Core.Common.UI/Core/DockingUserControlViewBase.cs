////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\UserControlViewBase.cs
//
// summary:	Implements the user control view base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using GCS.Core.Common.UI.Interfaces;
using GCS.Core.Common.Utils;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user control view base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DockingUserControlViewBase : RadDocumentPane, IPaneModel, INotifyPropertyChanged
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DockingUserControlViewBase()
        {
            if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
                this.FlowDirection = FlowDirection.RightToLeft;
            else
                this.FlowDirection = FlowDirection.LeftToRight;

            // Programmatically bind the view-model's ViewLoaded property to the view's ViewLoaded property.
            BindingOperations.SetBinding(this, ViewLoadedProperty, new Binding("ViewLoaded"));
            Unloaded += OnUnloaded;
            DataContextChanged += OnDataContextChanged;

            if (_PropertyChangedSubscribers == null)
                _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

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

        #region INotifyPropertyChanged
        /// <summary>   Event queue for all listeners interested in Property_Changed events. </summary>
        private event PropertyChangedEventHandler _PropertyChangedEvent;

        /// <summary>   The property changed subscribers. </summary>
        protected List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        public DockState Position { get; set; }

        /// <summary>   Occurs when a property value changes. </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                object h = this.GetHashCode();
                Type t = this.GetType();
                if (_PropertyChangedSubscribers == null)
                {
                    _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();
                }

                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChangedEvent += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                if (_PropertyChangedSubscribers != null)
                {
                    _PropertyChangedEvent -= value;
                    _PropertyChangedSubscribers.Remove(value);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> Name of the property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (_PropertyChangedEvent != null)
                _PropertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the property changed action. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="propertyExpression">   The property expression. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}
