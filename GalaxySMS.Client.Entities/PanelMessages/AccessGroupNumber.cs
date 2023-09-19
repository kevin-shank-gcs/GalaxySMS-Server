////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\AccessGroupNumber.cs
//
// summary:	Implements the access group number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent system access groups. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public enum SystemAccessGroup { None = 0, Unlimited = 255 }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class AccessGroupNumber : ObjectBase
	{
        /// <summary>   The access group number. </summary>
		private Int32 _accessGroupNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent access group number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum AccessGroupNumberLimits { MinimumAccessGroupNumber = 0, MaximumAccessGroupNumber = 2000 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public String UniqueId { get { return string.Format("{0:D3}", Number); } }

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
			get { return _accessGroupNumber; }
			set
			{
			    if (value >= (Int32) AccessGroupNumberLimits.MinimumAccessGroupNumber &&
			        value <= (Int32) AccessGroupNumberLimits.MaximumAccessGroupNumber)
			    {
                    if (_accessGroupNumber != value)
                    {
                        _accessGroupNumber = value;
                        OnPropertyChanged(() => Number);
                    }
			    }
			    else
			        throw new ArgumentOutOfRangeException("AccessGroupNumber.Number", value,
			            string.Format("The Number value must be between {0} and {1}",
			                AccessGroupNumberLimits.MinimumAccessGroupNumber, AccessGroupNumberLimits.MaximumAccessGroupNumber));
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this AccessGroupNumber is extended. </summary>
        ///
        /// <value> True if this AccessGroupNumber is extended, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Boolean IsExtended
		{
			get
			{
				if (Number > (Int32)SystemAccessGroup.Unlimited)
					return true;
				return false;
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
