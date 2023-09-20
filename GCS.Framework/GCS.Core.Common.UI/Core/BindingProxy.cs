////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\BindingProxy.cs
//
// summary:	Implements the binding proxy class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A binding proxy. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When implemented in a derived class, creates a new instance of the
        /// <see cref="T:System.Windows.Freezable" /> derived class.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new instance. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object Data
        {
            get { return (object) GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Using a DependencyProperty as the backing store for Data.  This enables animation, styling,
        /// binding, etc...
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
}
