////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\IOGroupAssignment.cs
//
// summary:	Implements the i/o group assignment class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An i/o group assignment. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class IOGroupAssignment : InputOutputGroupNumber
	{
        /// <summary>   The i/o offset number. </summary>
		private Int32 _ioOffsetNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent input output group offset limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum InputOutputGroupOffsetLimits { MinimumOffset = 0, MaximumOffset = 31 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public new String UniqueId { get { return string.Format("{0:D3}:{1:D2}", GroupNumber, OffsetNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the offset number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The offset number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 OffsetNumber
		{
			get { return _ioOffsetNumber; }
			set
			{
				if (value >= (Int32)InputOutputGroupOffsetLimits.MinimumOffset && value <= (Int32)InputOutputGroupOffsetLimits.MaximumOffset)
				{
                    if (_ioOffsetNumber != value)
                    {
                        _ioOffsetNumber = value;
                        OnPropertyChanged(() => OffsetNumber);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("OffsetNumber", value, string.Format("The OffsetNumber value must be between {0} and {1}",
						InputOutputGroupOffsetLimits.MinimumOffset, InputOutputGroupOffsetLimits.MaximumOffset));
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
