////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\Panel5xxRoute.cs
//
// summary:	Implements the panel 5xx route class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel 5xx route. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
    public class Panel5xxRoute : ObjectBase
	{
        /// <summary>   Identifier for the cluster. </summary>
	    private int _clusterId;
        /// <summary>   Identifier for from panel. </summary>
	    private ushort _fromPanelId;
        /// <summary>   Identifier for to panel. </summary>
	    private ushort _toPanelId;
        /// <summary>   from port board. </summary>
	    private ushort _fromPortBoard;
        /// <summary>   to port board. </summary>
	    private ushort _toPortBoard;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the cluster. </summary>
        ///
        /// <value> The identifier of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public Int32 ClusterId
	    {
	        get { return _clusterId; }
            set
            {
                if (_clusterId != value)
                {
                    _clusterId = value;
                    OnPropertyChanged(() => ClusterId);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of from panel. </summary>
        ///
        /// <value> The identifier of from panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 FromPanelId
	    {
	        get { return _fromPanelId; }
            set
            {
                if (_fromPanelId != value)
                {
                    _fromPanelId = value;
                    OnPropertyChanged(() => FromPanelId);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of to panel. </summary>
        ///
        /// <value> The identifier of to panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 ToPanelId
	    {
	        get { return _toPanelId; }
            set
            {
                if (_toPanelId != value)
                {
                    _toPanelId = value;
                    OnPropertyChanged(() => ToPanelId);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets from port board. </summary>
        ///
        /// <value> from port board. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 FromPortBoard
	    {
	        get { return _fromPortBoard; }
            set
            {
                if (_fromPortBoard != value)
                {
                    _fromPortBoard = value;
                    OnPropertyChanged(() => FromPortBoard);
                }
            }
	    }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets to port board. </summary>
        ///
        /// <value> to port board. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

	    [DataMember]
	    public UInt16 ToPortBoard
	    {
	        get { return _toPortBoard; }
            set
            {
                if (_toPortBoard != value)
                {
                    _toPortBoard = value;
                    OnPropertyChanged(() => ToPortBoard);
                }
            }
	    }
	}
}
