////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\RawDataToSend.cs
//
// summary:	Implements the raw data to send class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A raw data to send. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class RawDataToSend : ObjectBase
	{
        /// <summary>   The CPU model. </summary>
	    private CpuModel _cpuModel;
        /// <summary>   The address. </summary>
	    private BoardSectionNodeHardwareAddress _address;
        /// <summary>   The route 5 xx. </summary>
	    private Panel5xxRoute _route5Xx;
        /// <summary>   The data. </summary>
	    private byte[] _data;
        /// <summary>   Information describing the string. </summary>
	    private string _stringData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    public RawDataToSend()
		{
			Address = new BoardSectionNodeHardwareAddress();
			Route5xx = new Panel5xxRoute();
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU model. </summary>
        ///
        /// <value> The CPU model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public CpuModel CpuModel
	    {
	        get { return _cpuModel; }
            set
            {
                if (_cpuModel != value)
                {
                    _cpuModel = value;
                    OnPropertyChanged(() => CpuModel);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the address. </summary>
        ///
        /// <value> The address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public BoardSectionNodeHardwareAddress Address
	    {
	        get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(() => Address);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the route 5xx. </summary>
        ///
        /// <value> The route 5xx. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Panel5xxRoute Route5xx
	    {
	        get { return _route5Xx; }
            set
            {
                if (_route5Xx != value)
                {
                    _route5Xx = value;
                    OnPropertyChanged(() => Route5xx);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Byte[] Data
	    {
	        get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(() => Data);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the string. </summary>
        ///
        /// <value> Information describing the string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public String StringData
	    {
	        get { return _stringData; }
            set
            {
                if (_stringData != value)
                {
                    _stringData = value;
                    OnPropertyChanged(() => StringData);
                }
            }
	    }
	}
}
