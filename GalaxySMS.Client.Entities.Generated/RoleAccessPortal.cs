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
	public partial class RoleAccessPortal : DbObjectBase, ITableEntityBase
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
        public partial class RoleAccessPortal
        {
        	public RoleAccessPortal() : base()
        	{
        		Initialize();
        	}
        
        	public RoleAccessPortal(RoleAccessPortal e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.RoleAccessPortalPermissions = new HashSet<RoleAccessPortalPermission>();
        }
        
        	public void Initialize(RoleAccessPortal e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.RoleAccessPortalUid = e.RoleAccessPortalUid;
        		this.RoleId = e.RoleId;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleAccessPortalPermissions = e.RoleAccessPortalPermissions.ToCollection();
        		
        	}
        
        	public RoleAccessPortal Clone(RoleAccessPortal e)
        	{
        		return new RoleAccessPortal(e);
        	}
        
        	public bool Equals(RoleAccessPortal other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleAccessPortal other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleAccessPortalUid != this.RoleAccessPortalUid )
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
    
    	
    	private System.Guid _roleAccessPortalUid;
    
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
    	
    	private System.Guid _roleId;
    
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
    	
    	private System.Guid _accessPortalUid;
    
    	[DataMember]
    	public System.Guid AccessPortalUid
    	{ 
    		get { return _accessPortalUid; }
    		set
    		{
    			if (_accessPortalUid != value )
    			{
    				_accessPortalUid = value;
    				OnPropertyChanged(() => AccessPortalUid);
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
    
    	
    	private AccessPortal _accessPortal;
    
    	[DataMember]
    	public virtual AccessPortal AccessPortal
    	{ 
    		get { return _accessPortal; }
    		set
    		{
    			if (_accessPortal != value )
    			{
    				_accessPortal = value;
    				OnPropertyChanged(() => AccessPortal);
    			}
    		}
    	}
    	
    	private gcsRole _gcsRole;
    
    	[DataMember]
    	public virtual gcsRole gcsRole
    	{ 
    		get { return _gcsRole; }
    		set
    		{
    			if (_gcsRole != value )
    			{
    				_gcsRole = value;
    				OnPropertyChanged(() => gcsRole);
    			}
    		}
    	}
    	
    	private ICollection<RoleAccessPortalPermission> _roleAccessPortalPermissions;
    
    	[DataMember]
    	public virtual ICollection<RoleAccessPortalPermission> RoleAccessPortalPermissions
    	{ 
    		get { return _roleAccessPortalPermissions; }
    		set
    		{
    			if (_roleAccessPortalPermissions != value )
    			{
    				_roleAccessPortalPermissions = value;
    				OnPropertyChanged(() => RoleAccessPortalPermissions);
    			}
    		}
    	}
    }
    
}
