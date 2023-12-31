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
	public partial class CredentialFormatEntity : DbObjectBase, ITableEntityBase
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
        public partial class CredentialFormatEntity
        {
        	public CredentialFormatEntity() : base()
        	{
        		Initialize();
        	}
        
        	public CredentialFormatEntity(CredentialFormatEntity e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(CredentialFormatEntity e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialFormatEntityUid = e.CredentialFormatEntityUid;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.EntityId = e.EntityId;
        		this.IsAllowed = e.IsAllowed;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public CredentialFormatEntity Clone(CredentialFormatEntity e)
        	{
        		return new CredentialFormatEntity(e);
        	}
        
        	public bool Equals(CredentialFormatEntity other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialFormatEntity other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialFormatEntityUid != this.CredentialFormatEntityUid )
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
    
    	
    	private System.Guid _credentialFormatEntityUid;
    
    	[DataMember]
    	public System.Guid CredentialFormatEntityUid
    	{ 
    		get { return _credentialFormatEntityUid; }
    		set
    		{
    			if (_credentialFormatEntityUid != value )
    			{
    				_credentialFormatEntityUid = value;
    				OnPropertyChanged(() => CredentialFormatEntityUid);
    			}
    		}
    	}
    	
    	private System.Guid _credentialFormatUid;
    
    	[DataMember]
    	public System.Guid CredentialFormatUid
    	{ 
    		get { return _credentialFormatUid; }
    		set
    		{
    			if (_credentialFormatUid != value )
    			{
    				_credentialFormatUid = value;
    				OnPropertyChanged(() => CredentialFormatUid);
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
    	
    	private bool _isAllowed;
    
    	[DataMember]
    	public bool IsAllowed
    	{ 
    		get { return _isAllowed; }
    		set
    		{
    			if (_isAllowed != value )
    			{
    				_isAllowed = value;
    				OnPropertyChanged(() => IsAllowed);
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
    	
    	private System.DateTime _insertDate;
    
    	[DataMember]
    	public System.DateTime InsertDate
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
    }
    
}
