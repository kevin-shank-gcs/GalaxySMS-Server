//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A panel data packet log. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class PanelDataPacketLog : DbObjectBase
    {
        /// <summary>   The identifier. </summary>
    	private System.Guid _id;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid Id
    	{ 
    		get { return _id; }
    		set
    		{
    			if (_id != value )
    			{
    				_id = value;
    				OnPropertyChanged(() => Id);
    			}
    		}
    	}
        
        /// <summary>   The insert date. </summary>
    	private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.DateTimeOffset InsertDate
    	{ 
    		get { return _insertDate; }
    		set
    		{
    			if (_insertDate != value )
    			{
    				_insertDate = value;
    				OnPropertyChanged(() => InsertDate);
    			}
    		}
    	}
        
        /// <summary>   The update. </summary>
    	private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.DateTimeOffset> UpdateDate
    	{ 
    		get { return _updateDate; }
    		set
    		{
    			if (_updateDate != value )
    			{
    				_updateDate = value;
    				OnPropertyChanged(() => UpdateDate);
    			}
    		}
    	}
        
        /// <summary>   The length. </summary>
    	private short _length;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the length. </summary>
        ///
        /// <value> The length. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short Length
    	{ 
    		get { return _length; }
    		set
    		{
    			if (_length != value )
    			{
    				_length = value;
    				OnPropertyChanged(() => Length);
    			}
    		}
    	}
        
        /// <summary>   The distribute. </summary>
    	private short _distribute;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the distribute. </summary>
        ///
        /// <value> The distribute. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short Distribute
    	{ 
    		get { return _distribute; }
    		set
    		{
    			if (_distribute != value )
    			{
    				_distribute = value;
    				OnPropertyChanged(() => Distribute);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the cluster. </summary>
    	private int _clusterId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the cluster. </summary>
        ///
        /// <value> The identifier of the cluster. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int ClusterId
    	{ 
    		get { return _clusterId; }
    		set
    		{
    			if (_clusterId != value )
    			{
    				_clusterId = value;
    				OnPropertyChanged(() => ClusterId);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the panel. </summary>
    	private int _panelId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the panel. </summary>
        ///
        /// <value> The identifier of the panel. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int PanelId
    	{ 
    		get { return _panelId; }
    		set
    		{
    			if (_panelId != value )
    			{
    				_panelId = value;
    				OnPropertyChanged(() => PanelId);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the CPU. </summary>
    	private short _cpuId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the CPU. </summary>
        ///
        /// <value> The identifier of the CPU. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short CpuId
    	{ 
    		get { return _cpuId; }
    		set
    		{
    			if (_cpuId != value )
    			{
    				_cpuId = value;
    				OnPropertyChanged(() => CpuId);
    			}
    		}
    	}
        
        /// <summary>   The board number. </summary>
    	private short _boardNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the board number. </summary>
        ///
        /// <value> The board number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short BoardNumber
    	{ 
    		get { return _boardNumber; }
    		set
    		{
    			if (_boardNumber != value )
    			{
    				_boardNumber = value;
    				OnPropertyChanged(() => BoardNumber);
    			}
    		}
    	}
        
        /// <summary>   The section number. </summary>
    	private short _sectionNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the section number. </summary>
        ///
        /// <value> The section number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short SectionNumber
    	{ 
    		get { return _sectionNumber; }
    		set
    		{
    			if (_sectionNumber != value )
    			{
    				_sectionNumber = value;
    				OnPropertyChanged(() => SectionNumber);
    			}
    		}
    	}
        
        /// <summary>   The seconds from week start. </summary>
    	private int _secondsFromWeekStart;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the seconds from week start. </summary>
        ///
        /// <value> The seconds from week start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int SecondsFromWeekStart
    	{ 
    		get { return _secondsFromWeekStart; }
    		set
    		{
    			if (_secondsFromWeekStart != value )
    			{
    				_secondsFromWeekStart = value;
    				OnPropertyChanged(() => SecondsFromWeekStart);
    			}
    		}
    	}
        
        /// <summary>   The sequence. </summary>
    	private int _sequence;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sequence. </summary>
        ///
        /// <value> The sequence. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int Sequence
    	{ 
    		get { return _sequence; }
    		set
    		{
    			if (_sequence != value )
    			{
    				_sequence = value;
    				OnPropertyChanged(() => Sequence);
    			}
    		}
    	}
        
        /// <summary>   Information describing the raw. </summary>
    	private byte[] _rawData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the raw. </summary>
        ///
        /// <value> Information describing the raw. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public byte[] RawData
    	{ 
    		get { return _rawData; }
    		set
    		{
    			if (_rawData != value )
    			{
    				_rawData = value;
    				OnPropertyChanged(() => RawData);
    			}
    		}
    	}

        /// <summary>   True to direction. </summary>
        private bool _direction;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the direction. </summary>
        ///
        /// <value> True if direction, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool Direction
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    OnPropertyChanged(() => Direction);
                }
            }
        }

    }
    
}
