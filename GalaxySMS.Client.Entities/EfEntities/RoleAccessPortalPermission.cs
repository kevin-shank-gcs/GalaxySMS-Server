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
    /// <summary>   Role access portal permission descriptor. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class RoleAccessPortalPermission : DbObjectBase, ITableEntityBase
    {
        /// <summary>   The role access portal permission UID. </summary>
    	private System.Guid _roleAccessPortalPermissionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the role access portal permission UID. </summary>
        ///
        /// <value> The role access portal permission UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid RoleAccessPortalPermissionUid
    	{ 
    		get { return _roleAccessPortalPermissionUid; }
    		set
    		{
    			if (_roleAccessPortalPermissionUid != value )
    			{
    				_roleAccessPortalPermissionUid = value;
    				OnPropertyChanged(() => RoleAccessPortalPermissionUid);
    			}
    		}
    	}
    	
        /// <summary>   The role access portal UID. </summary>
    	private System.Guid _roleAccessPortalUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the role access portal UID. </summary>
        ///
        /// <value> The role access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid RoleAccessPortalUid
    	{ 
    		get { return _roleAccessPortalUid; }
    		set
    		{
    			if (_roleAccessPortalUid != value )
    			{
    				_roleAccessPortalUid = value;
    				OnPropertyChanged(() => RoleAccessPortalUid);
    			}
    		}
    	}
    	
        /// <summary>   Identifier for the permission. </summary>
    	private System.Guid _permissionId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the permission. </summary>
        ///
        /// <value> The identifier of the permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid PermissionId
    	{ 
    		get { return _permissionId; }
    		set
    		{
    			if (_permissionId != value )
    			{
    				_permissionId = value;
    				OnPropertyChanged(() => PermissionId);
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
    
    	
        /// <summary>   The gcs permission. </summary>
    	private gcsPermission _gcsPermission;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs permission. </summary>
        ///
        /// <value> The gcs permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual gcsPermission gcsPermission
    	{ 
    		get { return _gcsPermission; }
    		set
    		{
    			if (_gcsPermission != value )
    			{
    				_gcsPermission = value;
    				OnPropertyChanged(() => gcsPermission);
    			}
    		}
    	}
    	
        /// <summary>   The role access portal. </summary>
    	private RoleAccessPortal _roleAccessPortal;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the role access portal. </summary>
        ///
        /// <value> The role access portal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual RoleAccessPortal RoleAccessPortal
    	{ 
    		get { return _roleAccessPortal; }
    		set
    		{
    			if (_roleAccessPortal != value )
    			{
    				_roleAccessPortal = value;
    				OnPropertyChanged(() => RoleAccessPortal);
    			}
    		}
    	}
    }
    
}
