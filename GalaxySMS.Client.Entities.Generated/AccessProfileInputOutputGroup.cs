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
	public partial class AccessProfileInputOutputGroup : DbObjectBase, ITableEntityBase
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
        public partial class AccessProfileInputOutputGroup
        {
        	public AccessProfileInputOutputGroup() : base()
        	{
        		Initialize();
        	}
        
        	public AccessProfileInputOutputGroup(AccessProfileInputOutputGroup e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessProfileInputOutputGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessProfileInputOutputGroupUid = e.AccessProfileInputOutputGroupUid;
        		this.AccessProfileClusterUid = e.AccessProfileClusterUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.OrderNumber = e.OrderNumber;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AccessProfileInputOutputGroup Clone(AccessProfileInputOutputGroup e)
        	{
        		return new AccessProfileInputOutputGroup(e);
        	}
        
        	public bool Equals(AccessProfileInputOutputGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessProfileInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessProfileInputOutputGroupUid != this.AccessProfileInputOutputGroupUid )
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
    
    	
    	private System.Guid _accessProfileInputOutputGroupUid;
    
    	[DataMember]
    	public System.Guid AccessProfileInputOutputGroupUid
    	{ 
    		get { return _accessProfileInputOutputGroupUid; }
    		set
    		{
    			if (_accessProfileInputOutputGroupUid != value )
    			{
    				_accessProfileInputOutputGroupUid = value;
    				OnPropertyChanged(() => AccessProfileInputOutputGroupUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessProfileClusterUid;
    
    	[DataMember]
    	public System.Guid AccessProfileClusterUid
    	{ 
    		get { return _accessProfileClusterUid; }
    		set
    		{
    			if (_accessProfileClusterUid != value )
    			{
    				_accessProfileClusterUid = value;
    				OnPropertyChanged(() => AccessProfileClusterUid);
    			}
    		}
    	}
    	
    	private System.Guid _inputOutputGroupUid;
    
    	[DataMember]
    	public System.Guid InputOutputGroupUid
    	{ 
    		get { return _inputOutputGroupUid; }
    		set
    		{
    			if (_inputOutputGroupUid != value )
    			{
    				_inputOutputGroupUid = value;
    				OnPropertyChanged(() => InputOutputGroupUid);
    			}
    		}
    	}
    	
    	private short _orderNumber;
    
    	[DataMember]
    	public short OrderNumber
    	{ 
    		get { return _orderNumber; }
    		set
    		{
    			if (_orderNumber != value )
    			{
    				_orderNumber = value;
    				OnPropertyChanged(() => OrderNumber);
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
    
    	
    	private InputOutputGroup _inputOutputGroup;
    
    	[DataMember]
    	public virtual InputOutputGroup InputOutputGroup
    	{ 
    		get { return _inputOutputGroup; }
    		set
    		{
    			if (_inputOutputGroup != value )
    			{
    				_inputOutputGroup = value;
    				OnPropertyChanged(() => InputOutputGroup);
    			}
    		}
    	}
    }
    
}
