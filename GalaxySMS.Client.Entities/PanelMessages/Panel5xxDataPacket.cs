////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\Panel5xxDataPacket.cs
//
// summary:	Implements the panel 5xx data packet class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel 5xx data packet. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public class Panel5xxDataPacket : Panel5xxRoute
	{
        /// <summary>   The data. </summary>
		private Byte[] _data;
        /// <summary>   The length. </summary>
	    private ushort _length;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the length. </summary>
        ///
        /// <value> The length. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 Length
	    {
	        get { return _length; }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged(() => Length);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the type of the data. </summary>
        ///
        /// <value> The type of the data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
		public PacketDataType DataType { get { return (PacketDataType)Data[0]; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Byte[] Data
		{
			get
			{
				return _data;
			}
			set{
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(() => Data);
                }
            }
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Trim data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public void TrimData()
		{
			if (Data != null)
				Array.Resize(ref _data, Length );
		}
	}
}
