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
	using GCS.Core.Common.Contracts;	using FluentValidation;
    
	[DataContract]
	public partial class RoleClusterPermission : DbObjectBase, ITableEntityBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class RoleClusterPermission
        {
        	public RoleClusterPermission() : base()
        	{
        		Initialize();
        	}
        
        	public RoleClusterPermission(RoleClusterPermission e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(RoleClusterPermission e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.RoleClusterPermissionUid = e.RoleClusterPermissionUid;
        		this.RoleClusterUid = e.RoleClusterUid;
        		this.PermissionId = e.PermissionId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public RoleClusterPermission Clone(RoleClusterPermission e)
        	{
        		return new RoleClusterPermission(e);
        	}
        
        	public bool Equals(RoleClusterPermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleClusterPermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleClusterPermissionUid != this.RoleClusterPermissionUid )
        			return false;
        		return true;
        	}
        
        	public override int GetHashCode()
        	{
        		return base.GetHashCode();
        	}
        
        	public override string ToString()
        	{
        		return base.ToString();
        	}
        }
    }
    */
    
    	
    	private System.Guid _roleClusterPermissionUid;
    
    	[DataMember]
    	public System.Guid RoleClusterPermissionUid
    	{ 
    		get { return _roleClusterPermissionUid; }
    		set
    		{
    			if (_roleClusterPermissionUid != value )
    			{
    				_roleClusterPermissionUid = value;
    				OnPropertyChanged(() => RoleClusterPermissionUid);
    			}
    		}
    	}
    	
    	private System.Guid _roleClusterUid;
    
    	[DataMember]
    	public System.Guid RoleClusterUid
    	{ 
    		get { return _roleClusterUid; }
    		set
    		{
    			if (_roleClusterUid != value )
    			{
    				_roleClusterUid = value;
    				OnPropertyChanged(() => RoleClusterUid);
    			}
    		}
    	}
    	
    	private System.Guid _permissionId;
    
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
    	
    	private string _insertName;
    
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
    	
    	private Nullable<System.DateTime> _insertDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> InsertDate
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
    	
    	private string _updateName;
    
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
    	
    	private Nullable<System.DateTime> _updateDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> UpdateDate
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
    	
    	private Nullable<short> _concurrencyValue;
    
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
    
    	
    	private gcsPermission _gcsPermission;
    
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
    	
    	private RoleCluster _roleCluster;
    
    	[DataMember]
    	public virtual RoleCluster RoleCluster
    	{ 
    		get { return _roleCluster; }
    		set
    		{
    			if (_roleCluster != value )
    			{
    				_roleCluster = value;
    				OnPropertyChanged(() => RoleCluster);
    			}
    		}
    	}
    }
    
}
