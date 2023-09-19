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
	public partial class PersonCredentialCommandScript : DbObjectBase, ITableEntityBase
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
        public partial class PersonCredentialCommandScript
        {
        	public PersonCredentialCommandScript() : base()
        	{
        		Initialize();
        	}
        
        	public PersonCredentialCommandScript(PersonCredentialCommandScript e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonCredentialCommandScript e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonCredentialCommandScriptUid = e.PersonCredentialCommandScriptUid;
        		this.PersonCredentialUid = e.PersonCredentialUid;
        		this.CommandScriptUid = e.CommandScriptUid;
        		this.DelayedCommandScriptUid = e.DelayedCommandScriptUid;
        		this.DelayTime = e.DelayTime;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonCredentialCommandScript Clone(PersonCredentialCommandScript e)
        	{
        		return new PersonCredentialCommandScript(e);
        	}
        
        	public bool Equals(PersonCredentialCommandScript other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonCredentialCommandScript other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonCredentialCommandScriptUid != this.PersonCredentialCommandScriptUid )
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
    
    	
    	private System.Guid _personCredentialCommandScriptUid;
    
    	[DataMember]
    	public System.Guid PersonCredentialCommandScriptUid
    	{ 
    		get { return _personCredentialCommandScriptUid; }
    		set
    		{
    			if (_personCredentialCommandScriptUid != value )
    			{
    				_personCredentialCommandScriptUid = value;
    				OnPropertyChanged(() => PersonCredentialCommandScriptUid);
    			}
    		}
    	}
    	
    	private System.Guid _personCredentialUid;
    
    	[DataMember]
    	public System.Guid PersonCredentialUid
    	{ 
    		get { return _personCredentialUid; }
    		set
    		{
    			if (_personCredentialUid != value )
    			{
    				_personCredentialUid = value;
    				OnPropertyChanged(() => PersonCredentialUid);
    			}
    		}
    	}
    	
    	private System.Guid _commandScriptUid;
    
    	[DataMember]
    	public System.Guid CommandScriptUid
    	{ 
    		get { return _commandScriptUid; }
    		set
    		{
    			if (_commandScriptUid != value )
    			{
    				_commandScriptUid = value;
    				OnPropertyChanged(() => CommandScriptUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _delayedCommandScriptUid;
    
    	[DataMember]
    	public Nullable<System.Guid> DelayedCommandScriptUid
    	{ 
    		get { return _delayedCommandScriptUid; }
    		set
    		{
    			if (_delayedCommandScriptUid != value )
    			{
    				_delayedCommandScriptUid = value;
    				OnPropertyChanged(() => DelayedCommandScriptUid);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTimeOffset> _delayTime;
    
    	[DataMember]
    	public Nullable<System.DateTimeOffset> DelayTime
    	{ 
    		get { return _delayTime; }
    		set
    		{
    			if (_delayTime != value )
    			{
    				_delayTime = value;
    				OnPropertyChanged(() => DelayTime);
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
    
    	
    	private PersonCredential _personCredential;
    
    	[DataMember]
    	public virtual PersonCredential PersonCredential
    	{ 
    		get { return _personCredential; }
    		set
    		{
    			if (_personCredential != value )
    			{
    				_personCredential = value;
    				OnPropertyChanged(() => PersonCredential);
    			}
    		}
    	}
    }
    
}
