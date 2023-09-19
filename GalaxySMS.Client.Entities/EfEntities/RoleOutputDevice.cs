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
	using GCS.Core.Common.Contracts;	
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A role output device. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class RoleOutputDevice : DbObjectBase, ITableEntityBase
    {
  	
        /// <summary>   The role output device UID. </summary>
    	private System.Guid _roleOutputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the role output device UID. </summary>
        ///
        /// <value> The role output device UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid RoleOutputDeviceUid
    	{ 
    		get { return _roleOutputDeviceUid; }
    		set
    		{
    			if (_roleOutputDeviceUid != value )
    			{
    				_roleOutputDeviceUid = value;
    				OnPropertyChanged(() => RoleOutputDeviceUid);
    			}
    		}
    	}
    	
        /// <summary>   Identifier for the role. </summary>
    	private System.Guid _roleId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the role. </summary>
        ///
        /// <value> The identifier of the role. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid RoleId
    	{ 
    		get { return _roleId; }
    		set
    		{
    			if (_roleId != value )
    			{
    				_roleId = value;
    				OnPropertyChanged(() => RoleId);
    			}
    		}
    	}
    	
        /// <summary>   The output device UID. </summary>
    	private System.Guid _outputDeviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the output device UID. </summary>
        ///
        /// <value> The output device UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid OutputDeviceUid
    	{ 
    		get { return _outputDeviceUid; }
    		set
    		{
    			if (_outputDeviceUid != value )
    			{
    				_outputDeviceUid = value;
    				OnPropertyChanged(() => OutputDeviceUid);
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
    
    	
     //   /// <summary>   The gcs role. </summary>
    	//private gcsRole _gcsRole;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the gcs role. </summary>
     //   ///
     //   /// <value> The gcs role. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public virtual gcsRole gcsRole
    	//{ 
    	//	get { return _gcsRole; }
    	//	set
    	//	{
    	//		if (_gcsRole != value )
    	//		{
    	//			_gcsRole = value;
    	//			OnPropertyChanged(() => gcsRole);
    	//		}
    	//	}
    	//}
    	
     //   /// <summary>   The output device. </summary>
    	//private OutputDevice _outputDevice;

     //   ////////////////////////////////////////////////////////////////////////////////////////////////////
     //   /// <summary>   Gets or sets the output device. </summary>
     //   ///
     //   /// <value> The output device. </value>
     //   ////////////////////////////////////////////////////////////////////////////////////////////////////

    	//[DataMember]
    	//public virtual OutputDevice OutputDevice
    	//{ 
    	//	get { return _outputDevice; }
    	//	set
    	//	{
    	//		if (_outputDevice != value )
    	//		{
    	//			_outputDevice = value;
    	//			OnPropertyChanged(() => OutputDevice);
    	//		}
    	//	}
    	//}
    	
        /// <summary>   The role output device permissions. </summary>
    	private ICollection<RoleOutputDevicePermission> _roleOutputDevicePermissions;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the role output device permissions. </summary>
        ///
        /// <value> The role output device permissions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual ICollection<RoleOutputDevicePermission> RoleOutputDevicePermissions
    	{ 
    		get { return _roleOutputDevicePermissions; }
    		set
    		{
    			if (_roleOutputDevicePermissions != value )
    			{
    				_roleOutputDevicePermissions = value;
    				OnPropertyChanged(() => RoleOutputDevicePermissions);
    			}
    		}
    	}
    }
    
}
