////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\NotificationObject.cs
//
// summary:	Implements the notification object class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using GCS.Core.Common.Utils;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A notification object. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>   Event queue for all listeners interested in Property_Changed events. </summary>
        private event PropertyChangedEventHandler _PropertyChangedEvent;

        /// <summary>   The property changed subscribers. </summary>
        protected List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public NotificationObject()
        {
            object h = this.GetHashCode();
            Type t = this.GetType();
            if( _PropertyChangedSubscribers == null )
                _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();
        }

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
    }
}
