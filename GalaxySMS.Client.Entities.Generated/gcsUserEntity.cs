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
	public partial class gcsUserEntity : DbObjectBase, ITableEntityBase
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
        public partial class gcsUserEntity
        {
        	public gcsUserEntity() : base()
        	{
        		Initialize();
        	}
        
        	public gcsUserEntity(gcsUserEntity e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.gcsUserEntityApplicationRoles = new HashSet<gcsUserEntityApplicationRole>();
        }
        
        	public void Initialize(gcsUserEntity e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.UserEntityId = e.UserEntityId;
        		this.UserId = e.UserId;
        		this.EntityId = e.EntityId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.IsAdministrator = e.IsAdministrator;
        		this.InheritParentRoles = e.InheritParentRoles;
        		this.gcsUserEntityApplicationRoles = e.gcsUserEntityApplicationRoles.ToCollection();
        		
        	}
        
        	public gcsUserEntity Clone(gcsUserEntity e)
        	{
        		return new gcsUserEntity(e);
        	}
        
        	public bool Equals(gcsUserEntity other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsUserEntity other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserEntityId != this.UserEntityId )
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
    
    	
    	private System.Guid _userEntityId;
    
    	[DataMember]
    	public System.Guid UserEntityId
    	{ 
    		get { return _userEntityId; }
    		set
    		{
    			if (_userEntityId != value )
    			{
    				_userEntityId = value;
    				OnPropertyChanged(() => UserEntityId);
    			}
    		}
    	}
    	
    	private System.Guid _userId;
    
    	[DataMember]
    	public System.Guid UserId
    	{ 
    		get { return _userId; }
    		set
    		{
    			if (_userId != value )
    			{
    				_userId = value;
    				OnPropertyChanged(() => UserId);
    			}
    		}
    	}
    	
    	private System.Guid _entityId;
    
    	[DataMember]
    	public System.Guid EntityId
    	{ 
    		get { return _entityId; }
    		set
    		{
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
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
    	
    	private bool _isAdministrator;
    
    	[DataMember]
    	public bool IsAdministrator
    	{ 
    		get { return _isAdministrator; }
    		set
    		{
    			if (_isAdministrator != value )
    			{
    				_isAdministrator = value;
    				OnPropertyChanged(() => IsAdministrator);
    			}
    		}
    	}
    	
    	private bool _inheritParentRoles;
    
    	[DataMember]
    	public bool InheritParentRoles
    	{ 
    		get { return _inheritParentRoles; }
    		set
    		{
    			if (_inheritParentRoles != value )
    			{
    				_inheritParentRoles = value;
    				OnPropertyChanged(() => InheritParentRoles);
    			}
    		}
    	}
    
    	
    	private gcsEntity _gcsEntity;
    
    	[DataMember]
    	public virtual gcsEntity gcsEntity
    	{ 
    		get { return _gcsEntity; }
    		set
    		{
    			if (_gcsEntity != value )
    			{
    				_gcsEntity = value;
    				OnPropertyChanged(() => gcsEntity);
    			}
    		}
    	}
    	
    	private gcsUser _gcsUser;
    
    	[DataMember]
    	public virtual gcsUser gcsUser
    	{ 
    		get { return _gcsUser; }
    		set
    		{
    			if (_gcsUser != value )
    			{
    				_gcsUser = value;
    				OnPropertyChanged(() => gcsUser);
    			}
    		}
    	}
    	
    	private ICollection<gcsUserEntityApplicationRole> _gcsUserEntityApplicationRoles;
    
    	[DataMember]
    	public virtual ICollection<gcsUserEntityApplicationRole> gcsUserEntityApplicationRoles
    	{ 
    		get { return _gcsUserEntityApplicationRoles; }
    		set
    		{
    			if (_gcsUserEntityApplicationRoles != value )
    			{
    				_gcsUserEntityApplicationRoles = value;
    				OnPropertyChanged(() => gcsUserEntityApplicationRoles);
    			}
    		}
    	}
    }
    
}
