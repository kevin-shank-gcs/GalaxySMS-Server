////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\FromPanel\PanelMessageBase.cs
//
// summary:	Implements the panel message base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using System.Runtime.CompilerServices;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel message base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class PanelMessageBase : BoardSectionNodeHardwareAddress 
	{
        /// <summary>   The acknowledge nack. </summary>
	    private AckNack _ackNack;
        /// <summary>   Information describing the raw. </summary>
	    private byte[] _rawData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public PanelMessageBase()
		{

		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public PanelMessageBase(PanelMessageBase o) : base(o)
		{
			if (o != null)
			{
				AckNack = o.AckNack;
                RawData = o.RawData;
                IpAddress = o.IpAddress;
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the acknowledge nack. </summary>
        ///
        /// <value> The acknowledge nack. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public AckNack AckNack
	    {
	        get { return _ackNack; }
	        set
	        {
                if (_ackNack != value)
                {
                    _ackNack = value;
                    OnPropertyChanged(() => AckNack);
                }
	        }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the seconds from beginning of week. </summary>
        ///
        /// <value> The seconds from beginning of week. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 SecondsFromBeginningOfWeek { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sequence. </summary>
        ///
        /// <value> The sequence. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 Sequence { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the distribute. </summary>
        ///
        /// <value> The distribute. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int16 Distribute { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the raw. </summary>
        ///
        /// <value> Information describing the raw. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
	    public Byte[] RawData
	    {
	        get { return _rawData; }
            set
            {
                if (_rawData != value)
                {
                    _rawData = value;
                    OnPropertyChanged(() => RawData);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the created date time. </summary>
        ///
        /// <value> The created date time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DateTimeOffset CreatedDateTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP address. </summary>
        ///
        /// <value> The IP address. </value>
        ///=================================================================================================

        [DataMember]
        public string IpAddress { get; set; }
    }
}
