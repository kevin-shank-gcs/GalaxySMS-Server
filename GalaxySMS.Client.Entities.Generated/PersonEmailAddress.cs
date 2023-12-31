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
	public partial class PersonEmailAddress : DbObjectBase, ITableEntityBase
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
        public partial class PersonEmailAddress
        {
        	public PersonEmailAddress() : base()
        	{
        		Initialize();
        	}
        
        	public PersonEmailAddress(PersonEmailAddress e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(PersonEmailAddress e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.PersonPhoneNumberUid = e.PersonPhoneNumberUid;
        		this.PersonUid = e.PersonUid;
        		this.Label = e.Label;
        		this.EmailAddress = e.EmailAddress;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.PersonEmailAddressUid = e.PersonEmailAddressUid;
        		
        	}
        
        	public PersonEmailAddress Clone(PersonEmailAddress e)
        	{
        		return new PersonEmailAddress(e);
        	}
        
        	public bool Equals(PersonEmailAddress other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonEmailAddress other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonPhoneNumberUid != this.PersonPhoneNumberUid )
        			return false;
        	if(other.PersonEmailAddressUid != this.PersonEmailAddressUid )
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
    
    	
    	private System.Guid _personPhoneNumberUid;
    
    	[DataMember]
    	public System.Guid PersonPhoneNumberUid
    	{ 
    		get { return _personPhoneNumberUid; }
    		set
    		{
    			if (_personPhoneNumberUid != value )
    			{
    				_personPhoneNumberUid = value;
    				OnPropertyChanged(() => PersonPhoneNumberUid);
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
    	
    	private string _emailAddress;
    
    	[DataMember]
    	public string EmailAddress
    	{ 
    		get { return _emailAddress; }
    		set
    		{
    			if (_emailAddress != value )
    			{
    				_emailAddress = value;
    				OnPropertyChanged(() => EmailAddress);
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
    	
    	private System.Guid _personEmailAddressUid;
    
    	[DataMember]
    	public System.Guid PersonEmailAddressUid
    	{ 
    		get { return _personEmailAddressUid; }
    		set
    		{
    			if (_personEmailAddressUid != value )
    			{
    				_personEmailAddressUid = value;
    				OnPropertyChanged(() => PersonEmailAddressUid);
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
