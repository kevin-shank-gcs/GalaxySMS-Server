////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\InputOutputGroupNumber.cs
//
// summary:	Implements the input output group number class
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
    /// <summary>   Values that represent system input output groups. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum SystemInputOutputGroup { None = 0 }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input output group number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class InputOutputGroupNumber : ObjectBase
	{
        /// <summary>   The i/o group number. </summary>
		private Int32 _ioGroupNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent input output group number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum InputOutputGroupNumberLimits { MinimumInputOutputGroupNumber = 0, MaximumInputOutputGroupNumber = 255 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", GroupNumber); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the group number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 GroupNumber
		{
			get { return _ioGroupNumber; }
			set
			{
				if (value >= (Int32)InputOutputGroupNumberLimits.MinimumInputOutputGroupNumber && value <= (Int32)InputOutputGroupNumberLimits.MaximumInputOutputGroupNumber)
				{
                    if (_ioGroupNumber != value)
                    {
                        _ioGroupNumber = value;
                        OnPropertyChanged(() => GroupNumber);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("GroupNumber", value, string.Format("The GroupNumber value must be between {0} and {1}",
						InputOutputGroupNumberLimits.MinimumInputOutputGroupNumber, InputOutputGroupNumberLimits.MaximumInputOutputGroupNumber));
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
