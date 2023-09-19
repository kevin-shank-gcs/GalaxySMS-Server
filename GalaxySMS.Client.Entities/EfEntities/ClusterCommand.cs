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
    /// <summary>   A cluster command. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class ClusterCommand : DbObjectBase
    {
    	
        /// <summary>   The cluster command UID. </summary>
    	private System.Guid _clusterCommandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster command UID. </summary>
        ///
        /// <value> The cluster command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ClusterCommandUid
    	{ 
    		get { return _clusterCommandUid; }
    		set
    		{
    			if (_clusterCommandUid != value )
    			{
    				_clusterCommandUid = value;
    				OnPropertyChanged(() => ClusterCommandUid);
    			}
    		}
    	}
    	
        /// <summary>   The display. </summary>
    	private string _display;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display. </summary>
        ///
        /// <value> The display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Display
    	{ 
    		get { return _display; }
    		set
    		{
    			if (_display != value )
    			{
    				_display = value;
    				OnPropertyChanged(() => Display);
    			}
    		}
    	}
    	
        /// <summary>   The display resource key. </summary>
    	private Nullable<System.Guid> _displayResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display resource key. </summary>
        ///
        /// <value> The display resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DisplayResourceKey
    	{ 
    		get { return _displayResourceKey; }
    		set
    		{
    			if (_displayResourceKey != value )
    			{
    				_displayResourceKey = value;
    				OnPropertyChanged(() => DisplayResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The description. </summary>
    	private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Description
    	{ 
    		get { return _description; }
    		set
    		{
    			if (_description != value )
    			{
    				_description = value;
    				OnPropertyChanged(() => Description);
    			}
    		}
    	}
    	
        /// <summary>   The description resource key. </summary>
    	private Nullable<System.Guid> _descriptionResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description resource key. </summary>
        ///
        /// <value> The description resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> DescriptionResourceKey
    	{ 
    		get { return _descriptionResourceKey; }
    		set
    		{
    			if (_descriptionResourceKey != value )
    			{
    				_descriptionResourceKey = value;
    				OnPropertyChanged(() => DescriptionResourceKey);
    			}
    		}
    	}
    	
        /// <summary>   The command code. </summary>
    	private short _commandCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command code. </summary>
        ///
        /// <value> The command code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short CommandCode
    	{ 
    		get { return _commandCode; }
    		set
    		{
    			if (_commandCode != value )
    			{
    				_commandCode = value;
    				OnPropertyChanged(() => CommandCode);
    			}
    		}
    	}
    	
        /// <summary>   The is active. </summary>
    	private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the is active. </summary>
        ///
        /// <value> The is active. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsActive
    	{ 
    		get { return _isActive; }
    		set
    		{
    			if (_isActive != value )
    			{
    				_isActive = value;
    				OnPropertyChanged(() => IsActive);
    			}
    		}
    	}


        private bool _isFlashingCommand;
      

        [DataMember]

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ClusterCommand is flashing command.
        /// </summary>
        ///
        /// <value> True if this ClusterCommand is flashing command, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsFlashingCommand
        {
            get { return _isFlashingCommand; }
            set
            {
                if (_isFlashingCommand != value)
                {
                    _isFlashingCommand = value;
                    OnPropertyChanged(() => IsFlashingCommand, true);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string InsertName
    	{ 
    		get { return _insertName; }
    		set
    		{
    			if (_insertName != value )
    			{
    				_insertName = value;
    				OnPropertyChanged(() => InsertName);
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
    	
        /// <summary>   Name of the update. </summary>
    	private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string UpdateName
    	{ 
    		get { return _updateName; }
    		set
    		{
    			if (_updateName != value )
    			{
    				_updateName = value;
    				OnPropertyChanged(() => UpdateName);
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
    	
        /// <summary>   The concurrency value. </summary>
    	private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<short> ConcurrencyValue
    	{ 
    		get { return _concurrencyValue; }
    		set
    		{
    			if (_concurrencyValue != value )
    			{
    				_concurrencyValue = value;
    				OnPropertyChanged(() => ConcurrencyValue);
    			}
    		}
    	}
    
    	
        /// <summary>   The cluster type cluster commands. </summary>
    	private ICollection<ClusterTypeClusterCommand> _clusterTypeClusterCommands;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster type cluster commands. </summary>
        ///
        /// <value> The cluster type cluster commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual ICollection<ClusterTypeClusterCommand> ClusterTypeClusterCommands
    	{ 
    		get { return _clusterTypeClusterCommands; }
    		set
    		{
    			if (_clusterTypeClusterCommands != value )
    			{
    				_clusterTypeClusterCommands = value;
    				OnPropertyChanged(() => ClusterTypeClusterCommands);
    			}
    		}
    	}

        [DataMember]
        public ICollection<Guid> ClusterTypeIds { get; set; }

    }

}
