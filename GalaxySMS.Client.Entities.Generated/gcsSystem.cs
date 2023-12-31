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
	public partial class gcsSystem : DbObjectBase, ITableEntityBase
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
        public partial class gcsSystem
        {
        	public gcsSystem() : base()
        	{
        		Initialize();
        	}
        
        	public gcsSystem(gcsSystem e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(gcsSystem e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.SystemId = e.SystemId;
        		this.License = e.License;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.SystemName = e.SystemName;
        		this.CompanyName = e.CompanyName;
        		this.SupportCompany = e.SupportCompany;
        		this.SupportContact = e.SupportContact;
        		this.SupportPhone = e.SupportPhone;
        		this.SupportEmail = e.SupportEmail;
        		this.SupportUrl = e.SupportUrl;
        		this.SupportImage = e.SupportImage;
        		this.SystemImage = e.SystemImage;
        		this.PublicKey = e.PublicKey;
        		
        	}
        
        	public gcsSystem Clone(gcsSystem e)
        	{
        		return new gcsSystem(e);
        	}
        
        	public bool Equals(gcsSystem other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsSystem other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.SystemId != this.SystemId )
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
    
    	
    	private System.Guid _systemId;
    
    	[DataMember]
    	public System.Guid SystemId
    	{ 
    		get { return _systemId; }
    		set
    		{
    			if (_systemId != value )
    			{
    				_systemId = value;
    				OnPropertyChanged(() => SystemId);
    			}
    		}
    	}
    	
    	private string _license;
    
    	[DataMember]
    	public string License
    	{ 
    		get { return _license; }
    		set
    		{
    			if (_license != value )
    			{
    				_license = value;
    				OnPropertyChanged(() => License);
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
    	
    	private string _systemName;
    
    	[DataMember]
    	public string SystemName
    	{ 
    		get { return _systemName; }
    		set
    		{
    			if (_systemName != value )
    			{
    				_systemName = value;
    				OnPropertyChanged(() => SystemName);
    			}
    		}
    	}
    	
    	private string _companyName;
    
    	[DataMember]
    	public string CompanyName
    	{ 
    		get { return _companyName; }
    		set
    		{
    			if (_companyName != value )
    			{
    				_companyName = value;
    				OnPropertyChanged(() => CompanyName);
    			}
    		}
    	}
    	
    	private string _supportCompany;
    
    	[DataMember]
    	public string SupportCompany
    	{ 
    		get { return _supportCompany; }
    		set
    		{
    			if (_supportCompany != value )
    			{
    				_supportCompany = value;
    				OnPropertyChanged(() => SupportCompany);
    			}
    		}
    	}
    	
    	private string _supportContact;
    
    	[DataMember]
    	public string SupportContact
    	{ 
    		get { return _supportContact; }
    		set
    		{
    			if (_supportContact != value )
    			{
    				_supportContact = value;
    				OnPropertyChanged(() => SupportContact);
    			}
    		}
    	}
    	
    	private string _supportPhone;
    
    	[DataMember]
    	public string SupportPhone
    	{ 
    		get { return _supportPhone; }
    		set
    		{
    			if (_supportPhone != value )
    			{
    				_supportPhone = value;
    				OnPropertyChanged(() => SupportPhone);
    			}
    		}
    	}
    	
    	private string _supportEmail;
    
    	[DataMember]
    	public string SupportEmail
    	{ 
    		get { return _supportEmail; }
    		set
    		{
    			if (_supportEmail != value )
    			{
    				_supportEmail = value;
    				OnPropertyChanged(() => SupportEmail);
    			}
    		}
    	}
    	
    	private string _supportUrl;
    
    	[DataMember]
    	public string SupportUrl
    	{ 
    		get { return _supportUrl; }
    		set
    		{
    			if (_supportUrl != value )
    			{
    				_supportUrl = value;
    				OnPropertyChanged(() => SupportUrl);
    			}
    		}
    	}
    	
    	private byte[] _supportImage;
    
    	[DataMember]
    	public byte[] SupportImage
    	{ 
    		get { return _supportImage; }
    		set
    		{
    			if (_supportImage != value )
    			{
    				_supportImage = value;
    				OnPropertyChanged(() => SupportImage);
    			}
    		}
    	}
    	
    	private byte[] _systemImage;
    
    	[DataMember]
    	public byte[] SystemImage
    	{ 
    		get { return _systemImage; }
    		set
    		{
    			if (_systemImage != value )
    			{
    				_systemImage = value;
    				OnPropertyChanged(() => SystemImage);
    			}
    		}
    	}
    	
    	private string _publicKey;
    
    	[DataMember]
    	public string PublicKey
    	{ 
    		get { return _publicKey; }
    		set
    		{
    			if (_publicKey != value )
    			{
    				_publicKey = value;
    				OnPropertyChanged(() => PublicKey);
    			}
    		}
    	}
    }
    
}
