////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\PassbackAreaNumber.cs
//
// summary:	Implements the passback area number class
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
    /// <summary>   Values that represent system areas. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum SystemArea { None = 0, NoChange = 255}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A passback area number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class PassbackAreaNumber : ObjectBase
	{
        /// <summary>   The area number. </summary>
		private Int32 _areaNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent passback area number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum PassbackAreaNumberLimits { MinimumAreaNumber = 0, MaximumAreaNumber = 255 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", AreaNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the area number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The area number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 AreaNumber
		{
			get { return _areaNumber; }
			set
			{
				if (value >= (Int32)PassbackAreaNumberLimits.MinimumAreaNumber && value <= (Int32)PassbackAreaNumberLimits.MaximumAreaNumber)
				{
                    if (_areaNumber != value)
                    {
                        _areaNumber = value;
                        OnPropertyChanged(() => AreaNumber);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("PassbackAreaNumber.AreaNumber", value, string.Format("The AreaNumber value must be between {0} and {1}",
						PassbackAreaNumberLimits.MinimumAreaNumber, PassbackAreaNumberLimits.MaximumAreaNumber));
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
			return UniqueId;
		}
	}
}
