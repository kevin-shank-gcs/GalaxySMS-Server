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
	public partial class PersonAddress : DbObjectBase, ITableEntityBase
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
        public partial class PersonAddress
        {
        	public PersonAddress() : base()
        	{
        		Initialize();
        	}
        
        	public PersonAddress(PersonAddress e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonAddress e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonAddressUid = e.PersonAddressUid;
        		this.PersonUid = e.PersonUid;
        		this.AddressUid = e.AddressUid;
        		this.Label = e.Label;
        		this.IsCurrent = e.IsCurrent;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public PersonAddress Clone(PersonAddress e)
        	{
        		return new PersonAddress(e);
        	}
        
        	public bool Equals(PersonAddress other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonAddress other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonAddressUid != this.PersonAddressUid )
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
    
    	
    	private System.Guid _personAddressUid;
    
    	[DataMember]
    	public System.Guid PersonAddressUid
    	{ 
    		get { return _personAddressUid; }
    		set
    		{
    			if (_personAddressUid != value )
    			{
    				_personAddressUid = value;
    				OnPropertyChanged(() => PersonAddressUid);
    			}
    		}
    	}
    	
    	private System.Guid _personUid;
    
    	[DataMember]
    	public System.Guid PersonUid
    	{ 
    		get { return _personUid; }
    		set
    		{
    			if (_personUid != value )
    			{
    				_personUid = value;
    				OnPropertyChanged(() => PersonUid);
    			}
    		}
    	}
    	
    	private System.Guid _addressUid;
    
    	[DataMember]
    	public System.Guid AddressUid
    	{ 
    		get { return _addressUid; }
    		set
    		{
    			if (_addressUid != value )
    			{
    				_addressUid = value;
    				OnPropertyChanged(() => AddressUid);
    			}
    		}
    	}
    	
    	private string _label;
    
    	[DataMember]
    	public string Label
    	{ 
    		get { return _label; }
    		set
    		{
    			if (_label != value )
    			{
    				_label = value;
    				OnPropertyChanged(() => Label);
    			}
    		}
    	}
    	
    	private bool _isCurrent;
    
    	[DataMember]
    	public bool IsCurrent
    	{ 
    		get { return _isCurrent; }
    		set
    		{
    			if (_isCurrent != value )
    			{
    				_isCurrent = value;
    				OnPropertyChanged(() => IsCurrent);
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
    
    	
    	private Person _person;
    
    	[DataMember]
    	public virtual Person Person
    	{ 
    		get { return _person; }
    		set
    		{
    			if (_person != value )
    			{
    				_person = value;
    				OnPropertyChanged(() => Person);
    			}
    		}
    	}
    }
    
}
