////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Telerik\HundredthsTimeSpanComponent.cs
//
// summary:	Implements the hundredths time span component class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace GCS.Core.Common.UI
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The hundredths time span component. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HundredthsTimeSpanComponent: StepTimeSpanComponentBase
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
            return new HundredthsTimeSpanComponent();
        }

        #endregion

        #region Overrides of TimeSpanComponentBase

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Returns a long <see cref="T:System.TimeSpan" />.Ticks value corresponding to an item from the
        /// <see cref="P:Telerik.Windows.Controls.TimeSpanComponentBase.ItemsSource" />.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="item"> An item from the
        ///                     <see cref="P:Telerik.Windows.Controls.TimeSpanComponentBase.ItemsSource" />. </param>
        ///
        /// <returns>
        /// A long number that is the <see cref="T:System.TimeSpan" />.Ticks representation of the item.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override long GetTicksFromItem(object item)
        {
            if (item != null)
            {
                decimal selectedItemDecimal;
                if (decimal.TryParse(item.ToString(), out selectedItemDecimal))
                {
                    return TimeSpan.FromMilliseconds((double)(selectedItemDecimal * 10)).Ticks;
                }
            }

            return 0;
        }

        #endregion
    }
}
