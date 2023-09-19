////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\PanelDoorNumber.cs
//
// summary:	Implements the panel door number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel door number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class PanelDoorNumber : ObjectBase
	{
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent panel door number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PanelDoorNumberLimits { MinimumPanelDoorNumber = 0, MaximumPanelDoorNumber = 64 }

        /// <summary>   The door number. </summary>
		private Int32 _doorNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of.  </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 Number
		{
			get { return _doorNumber; }
			set
			{
				if (value >= (Int32)PanelDoorNumberLimits.MinimumPanelDoorNumber && value <= (Int32)PanelDoorNumberLimits.MaximumPanelDoorNumber)
				{
                    if (_doorNumber != value)
                    {    
                        _doorNumber = value;
                        OnPropertyChanged(() => Number);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("PanelDoorNumber.Number", value, string.Format("The Number value must be between {0} and {1}",
						PanelDoorNumberLimits.MinimumPanelDoorNumber, PanelDoorNumberLimits.MaximumPanelDoorNumber));
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public override string ToString()
		{
			return Number.ToString();
		}
	}

}
