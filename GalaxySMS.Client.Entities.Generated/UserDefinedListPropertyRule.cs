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
	public partial class UserDefinedListPropertyRule : DbObjectBase, ITableEntityBase
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
        public partial class UserDefinedListPropertyRule
        {
        	public UserDefinedListPropertyRule() : base()
        	{
        		Initialize();
        	}
        
        	public UserDefinedListPropertyRule(UserDefinedListPropertyRule e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(UserDefinedListPropertyRule e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.UserDefinedListPropertyRulesUid = e.UserDefinedListPropertyRulesUid;
        		this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
        		this.AllowMultipleSelections = e.AllowMultipleSelections;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public UserDefinedListPropertyRule Clone(UserDefinedListPropertyRule e)
        	{
        		return new UserDefinedListPropertyRule(e);
        	}
        
        	public bool Equals(UserDefinedListPropertyRule other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(UserDefinedListPropertyRule other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserDefinedListPropertyRulesUid != this.UserDefinedListPropertyRulesUid )
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
    
    	
    	private System.Guid _userDefinedListPropertyRulesUid;
    
    	[DataMember]
    	public System.Guid UserDefinedListPropertyRulesUid
    	{ 
    		get { return _userDefinedListPropertyRulesUid; }
    		set
    		{
    			if (_userDefinedListPropertyRulesUid != value )
    			{
    				_userDefinedListPropertyRulesUid = value;
    				OnPropertyChanged(() => UserDefinedListPropertyRulesUid);
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
    	
    	private bool _allowMultipleSelections;
    
    	[DataMember]
    	public bool AllowMultipleSelections
    	{ 
    		get { return _allowMultipleSelections; }
    		set
    		{
    			if (_allowMultipleSelections != value )
    			{
    				_allowMultipleSelections = value;
    				OnPropertyChanged(() => AllowMultipleSelections);
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
