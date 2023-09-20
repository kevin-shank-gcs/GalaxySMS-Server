////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\AssaAbloyAddress.cs
//
// summary:	Implements the assa abloy address class
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
    /// <summary>   An assa abloy address. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class AssaAbloyAddress : ObjectBase
	{
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent hub number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum HubNumberLimits {MinimumHubNumber = 1, MaximumHubNumber = 15}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent reader number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public enum ReaderNumberLimits {MinimumReaderNumber = 1, MaximumReaderNumber = 8}	// must be converted to 0 - 7 for panel

        /// <summary>   The hub number. </summary>
		private Int32 _hubNumber;
        /// <summary>   The reader number. </summary>
		private Int32 _readerNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the hub number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The hub number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 HubNumber
		{
			get { return _hubNumber; }
			set
			{
				if (value >= (Int32)HubNumberLimits.MinimumHubNumber && value <= (Int32)HubNumberLimits.MaximumHubNumber)
				{
                    if (_hubNumber != value)
                    {
                        _hubNumber = value;
                        OnPropertyChanged(() => HubNumber);
                    }
                }
				else
					throw new ArgumentOutOfRangeException("AssaAbloyAddress.HubNumber", value, string.Format("The HubNumber value must be between {0} and {1}",
						HubNumberLimits.MinimumHubNumber, HubNumberLimits.MaximumHubNumber));
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the reader number. </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The reader number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Int32 ReaderNumber
		{
			get { return _readerNumber; }
			set
			{
				if (value >= (Int32)ReaderNumberLimits.MinimumReaderNumber && value <= (Int32)ReaderNumberLimits.MaximumReaderNumber)
				{
                    if (_readerNumber != value)
                    {
                        _readerNumber = value;
                        OnPropertyChanged(() => ReaderNumber);
                    }
				    
				}
				else
					throw new ArgumentOutOfRangeException("AssaAbloyAddress.ReaderNumber", value, string.Format("The ReaderNumber value must be between {0} and {1}",
						ReaderNumberLimits.MinimumReaderNumber, ReaderNumberLimits.MaximumReaderNumber));
			}
		}
	}
}
