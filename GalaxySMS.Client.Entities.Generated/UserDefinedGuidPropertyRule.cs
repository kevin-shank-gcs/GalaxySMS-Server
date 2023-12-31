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
	public partial class UserDefinedGuidPropertyRule : DbObjectBase, ITableEntityBase
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
        public partial class UserDefinedGuidPropertyRule
        {
        	public UserDefinedGuidPropertyRule() : base()
        	{
        		Initialize();
        	}
        
        	public UserDefinedGuidPropertyRule(UserDefinedGuidPropertyRule e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(UserDefinedGuidPropertyRule e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.UserDefinedGuidPropertyRulesUid = e.UserDefinedGuidPropertyRulesUid;
        		this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
        		this.IsRequired = e.IsRequired;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public UserDefinedGuidPropertyRule Clone(UserDefinedGuidPropertyRule e)
        	{
        		return new UserDefinedGuidPropertyRule(e);
        	}
        
        	public bool Equals(UserDefinedGuidPropertyRule other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(UserDefinedGuidPropertyRule other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserDefinedGuidPropertyRulesUid != this.UserDefinedGuidPropertyRulesUid )
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
    
    	
    	private System.Guid _userDefinedGuidPropertyRulesUid;
    
    	[DataMember]
    	public System.Guid UserDefinedGuidPropertyRulesUid
    	{ 
    		get { return _userDefinedGuidPropertyRulesUid; }
    		set
    		{
    			if (_userDefinedGuidPropertyRulesUid != value )
    			{
    				_userDefinedGuidPropertyRulesUid = value;
    				OnPropertyChanged(() => UserDefinedGuidPropertyRulesUid);
    			}
    		}
    	}
    	
    	private System.Guid _userDefinedPropertyUid;
    
    	[DataMember]
    	public System.Guid UserDefinedPropertyUid
    	{ 
    		get { return _userDefinedPropertyUid; }
    		set
    		{
    			if (_userDefinedPropertyUid != value )
    			{
    				_userDefinedPropertyUid = value;
    				OnPropertyChanged(() => UserDefinedPropertyUid);
    			}
    		}
    	}
    	
    	private bool _isRequired;
    
    	[DataMember]
    	public bool IsRequired
    	{ 
    		get { return _isRequired; }
    		set
    		{
    			if (_isRequired != value )
    			{
    				_isRequired = value;
    				OnPropertyChanged(() => IsRequired);
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
    
    	
    	private UserDefinedProperty _userDefinedProperty;
    
    	[DataMember]
    	public virtual UserDefinedProperty UserDefinedProperty
    	{ 
    		get { return _userDefinedProperty; }
    		set
    		{
    			if (_userDefinedProperty != value )
    			{
    				_userDefinedProperty = value;
    				OnPropertyChanged(() => UserDefinedProperty);
    			}
    		}
    	}
    }
    
}
