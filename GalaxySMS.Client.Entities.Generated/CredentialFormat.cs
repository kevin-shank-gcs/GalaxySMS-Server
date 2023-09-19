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
	public partial class CredentialFormat : DbObjectBase, ITableEntityBase
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
        public partial class CredentialFormat
        {
        	public CredentialFormat() : base()
        	{
        		Initialize();
        	}
        
        	public CredentialFormat(CredentialFormat e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.Credentials = new HashSet<Credential>();
        		this.CredentialFormatDataFields = new HashSet<CredentialFormatDataField>();
        		this.CredentialFormatParities = new HashSet<CredentialFormatParity>();
        }
        
        	public void Initialize(CredentialFormat e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.CredentialFormatCode = e.CredentialFormatCode;
        		this.BitLength = e.BitLength;
        		this.IsEnabled = e.IsEnabled;
        		this.BiomenticEnrollmentSupported = e.BiomenticEnrollmentSupported;
        		this.BiometricIdField = e.BiometricIdField;
        		this.UseFullCardCode = e.UseFullCardCode;
        		this.BatchLoadSupported = e.BatchLoadSupported;
        		this.BatchLoadIncrementField = e.BatchLoadIncrementField;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.BiometricEnrollmentSupported = e.BiometricEnrollmentSupported;
        		this.UseCardNumber = e.UseCardNumber;
        		this.Credentials = e.Credentials.ToCollection();
        		this.CredentialFormatDataFields = e.CredentialFormatDataFields.ToCollection();
        		this.CredentialFormatParities = e.CredentialFormatParities.ToCollection();
        		
        	}
        
        	public CredentialFormat Clone(CredentialFormat e)
        	{
        		return new CredentialFormat(e);
        	}
        
        	public bool Equals(CredentialFormat other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialFormat other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialFormatUid != this.CredentialFormatUid )
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
    	
    	private Nullable<System.Guid> _displayResourceKey;
    
    	[DataMember]
    	public Nullable<System.Guid> DisplayResourceKey
    	{ 
    		get { return _displayResourceKey; }
    		set
    		{
    			if (_displayResourceKey != value )
    			{
    				_displayResourceKey = value;
    				OnPropertyChanged(() => DisplayResourceKey);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _descriptionResourceKey;
    
    	[DataMember]
    	public Nullable<System.Guid> DescriptionResourceKey
    	{ 
    		get { return _descriptionResourceKey; }
    		set
    		{
    			if (_descriptionResourceKey != value )
    			{
    				_descriptionResourceKey = value;
    				OnPropertyChanged(() => DescriptionResourceKey);
    			}
    		}
    	}
    	
    	private string _display;
    
    	[DataMember]
    	public string Display
    	{ 
    		get { return _display; }
    		set
    		{
    			if (_display != value )
    			{
    				_display = value;
    				OnPropertyChanged(() => Display);
    			}
    		}
    	}
    	
    	private string _description;
    
    	[DataMember]
    	public string Description
    	{ 
    		get { return _description; }
    		set
    		{
    			if (_description != value )
    			{
    				_description = value;
    				OnPropertyChanged(() => Description);
    			}
    		}
    	}
    	
    	private short _credentialFormatCode;
    
    	[DataMember]
    	public short CredentialFormatCode
    	{ 
    		get { return _credentialFormatCode; }
    		set
    		{
    			if (_credentialFormatCode != value )
    			{
    				_credentialFormatCode = value;
    				OnPropertyChanged(() => CredentialFormatCode);
    			}
    		}
    	}
    	
    	private short _bitLength;
    
    	[DataMember]
    	public short BitLength
    	{ 
    		get { return _bitLength; }
    		set
    		{
    			if (_bitLength != value )
    			{
    				_bitLength = value;
    				OnPropertyChanged(() => BitLength);
    			}
    		}
    	}
    	
    	private bool _isEnabled;
    
    	[DataMember]
    	public bool IsEnabled
    	{ 
    		get { return _isEnabled; }
    		set
    		{
    			if (_isEnabled != value )
    			{
    				_isEnabled = value;
    				OnPropertyChanged(() => IsEnabled);
    			}
    		}
    	}
    	
    	private bool _biomenticEnrollmentSupported;
    
    	[DataMember]
    	public bool BiomenticEnrollmentSupported
    	{ 
    		get { return _biomenticEnrollmentSupported; }
    		set
    		{
    			if (_biomenticEnrollmentSupported != value )
    			{
    				_biomenticEnrollmentSupported = value;
    				OnPropertyChanged(() => BiomenticEnrollmentSupported);
    			}
    		}
    	}
    	
    	private short _biometricIdField;
    
    	[DataMember]
    	public short BiometricIdField
    	{ 
    		get { return _biometricIdField; }
    		set
    		{
    			if (_biometricIdField != value )
    			{
    				_biometricIdField = value;
    				OnPropertyChanged(() => BiometricIdField);
    			}
    		}
    	}
    	
    	private bool _useFullCardCode;
    
    	[DataMember]
    	public bool UseFullCardCode
    	{ 
    		get { return _useFullCardCode; }
    		set
    		{
    			if (_useFullCardCode != value )
    			{
    				_useFullCardCode = value;
    				OnPropertyChanged(() => UseFullCardCode);
    			}
    		}
    	}
    	
    	private bool _batchLoadSupported;
    
    	[DataMember]
    	public bool BatchLoadSupported
    	{ 
    		get { return _batchLoadSupported; }
    		set
    		{
    			if (_batchLoadSupported != value )
    			{
    				_batchLoadSupported = value;
    				OnPropertyChanged(() => BatchLoadSupported);
    			}
    		}
    	}
    	
    	private short _batchLoadIncrementField;
    
    	[DataMember]
    	public short BatchLoadIncrementField
    	{ 
    		get { return _batchLoadIncrementField; }
    		set
    		{
    			if (_batchLoadIncrementField != value )
    			{
    				_batchLoadIncrementField = value;
    				OnPropertyChanged(() => BatchLoadIncrementField);
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
    	
    	private bool _biometricEnrollmentSupported;
    
    	[DataMember]
    	public bool BiometricEnrollmentSupported
    	{ 
    		get { return _biometricEnrollmentSupported; }
    		set
    		{
    			if (_biometricEnrollmentSupported != value )
    			{
    				_biometricEnrollmentSupported = value;
    				OnPropertyChanged(() => BiometricEnrollmentSupported);
    			}
    		}
    	}
    	
    	private bool _useCardNumber;
    
    	[DataMember]
    	public bool UseCardNumber
    	{ 
    		get { return _useCardNumber; }
    		set
    		{
    			if (_useCardNumber != value )
    			{
    				_useCardNumber = value;
    				OnPropertyChanged(() => UseCardNumber);
    			}
    		}
    	}
    
    	
    	private ICollection<Credential> _credentials;
    
    	[DataMember]
    	public virtual ICollection<Credential> Credentials
    	{ 
    		get { return _credentials; }
    		set
    		{
    			if (_credentials != value )
    			{
    				_credentials = value;
    				OnPropertyChanged(() => Credentials);
    			}
    		}
    	}
    	
    	private ICollection<CredentialFormatDataField> _credentialFormatDataFields;
    
    	[DataMember]
    	public virtual ICollection<CredentialFormatDataField> CredentialFormatDataFields
    	{ 
    		get { return _credentialFormatDataFields; }
    		set
    		{
    			if (_credentialFormatDataFields != value )
    			{
    				_credentialFormatDataFields = value;
    				OnPropertyChanged(() => CredentialFormatDataFields);
    			}
    		}
    	}
    	
    	private gcsResourceString _gcsResourceString;
    
    	[DataMember]
    	public virtual gcsResourceString gcsResourceString
    	{ 
    		get { return _gcsResourceString; }
    		set
    		{
    			if (_gcsResourceString != value )
    			{
    				_gcsResourceString = value;
    				OnPropertyChanged(() => gcsResourceString);
    			}
    		}
    	}
    	
    	private ICollection<CredentialFormatParity> _credentialFormatParities;
    
    	[DataMember]
    	public virtual ICollection<CredentialFormatParity> CredentialFormatParities
    	{ 
    		get { return _credentialFormatParities; }
    		set
    		{
    			if (_credentialFormatParities != value )
    			{
    				_credentialFormatParities = value;
    				OnPropertyChanged(() => CredentialFormatParities);
    			}
    		}
    	}
    }
    
}
