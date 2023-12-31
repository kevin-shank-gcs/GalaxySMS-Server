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
	public partial class Credential : DbObjectBase, ITableEntityBase
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
        public partial class Credential
        {
        	public Credential() : base()
        	{
        		Initialize();
        	}
        
        	public Credential(Credential e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.CredentialToLoadToCpus = new HashSet<CredentialToLoadToCpu>();
        }
        
        	public void Initialize(Credential e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialUid = e.CredentialUid;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.CardNumber = e.CardNumber;
        		this.CardNumberIsHex = e.CardNumberIsHex;
        		this.CardBinaryData = e.CardBinaryData;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.BitCount = e.BitCount;
        		this.IsExtended = e.IsExtended;
        		this.CredentialToLoadToCpus = e.CredentialToLoadToCpus.ToCollection();
        		
        	}
        
        	public Credential Clone(Credential e)
        	{
        		return new Credential(e);
        	}
        
        	public bool Equals(Credential other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(Credential other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialUid != this.CredentialUid )
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
    
    	
    	private System.Guid _credentialUid;
    
    	[DataMember]
    	public System.Guid CredentialUid
    	{ 
    		get { return _credentialUid; }
    		set
    		{
    			if (_credentialUid != value )
    			{
    				_credentialUid = value;
    				OnPropertyChanged(() => CredentialUid);
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
    	
    	private string _cardNumber;
    
    	[DataMember]
    	public string CardNumber
    	{ 
    		get { return _cardNumber; }
    		set
    		{
    			if (_cardNumber != value )
    			{
    				_cardNumber = value;
    				OnPropertyChanged(() => CardNumber);
    			}
    		}
    	}
    	
    	private bool _cardNumberIsHex;
    
    	[DataMember]
    	public bool CardNumberIsHex
    	{ 
    		get { return _cardNumberIsHex; }
    		set
    		{
    			if (_cardNumberIsHex != value )
    			{
    				_cardNumberIsHex = value;
    				OnPropertyChanged(() => CardNumberIsHex);
    			}
    		}
    	}
    	
    	private byte[] _cardBinaryData;
    
    	[DataMember]
    	public byte[] CardBinaryData
    	{ 
    		get { return _cardBinaryData; }
    		set
    		{
    			if (_cardBinaryData != value )
    			{
    				_cardBinaryData = value;
    				OnPropertyChanged(() => CardBinaryData);
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
    	
    	private short _bitCount;
    
    	[DataMember]
    	public short BitCount
    	{ 
    		get { return _bitCount; }
    		set
    		{
    			if (_bitCount != value )
    			{
    				_bitCount = value;
    				OnPropertyChanged(() => BitCount);
    			}
    		}
    	}
    	
    	private Nullable<bool> _isExtended;
    
    	[DataMember]
    	public Nullable<bool> IsExtended
    	{ 
    		get { return _isExtended; }
    		set
    		{
    			if (_isExtended != value )
    			{
    				_isExtended = value;
    				OnPropertyChanged(() => IsExtended);
    			}
    		}
    	}
    
    	
    	private Credential26BitStandard _credential26BitStandard;
    
    	[DataMember]
    	public virtual Credential26BitStandard Credential26BitStandard
    	{ 
    		get { return _credential26BitStandard; }
    		set
    		{
    			if (_credential26BitStandard != value )
    			{
    				_credential26BitStandard = value;
    				OnPropertyChanged(() => Credential26BitStandard);
    			}
    		}
    	}
    	
    	private CredentialBqt36Bit _credentialBqt36Bit;
    
    	[DataMember]
    	public virtual CredentialBqt36Bit CredentialBqt36Bit
    	{ 
    		get { return _credentialBqt36Bit; }
    		set
    		{
    			if (_credentialBqt36Bit != value )
    			{
    				_credentialBqt36Bit = value;
    				OnPropertyChanged(() => CredentialBqt36Bit);
    			}
    		}
    	}
    	
    	private CredentialCorporate1K35Bit _credentialCorporate1K35Bit;
    
    	[DataMember]
    	public virtual CredentialCorporate1K35Bit CredentialCorporate1K35Bit
    	{ 
    		get { return _credentialCorporate1K35Bit; }
    		set
    		{
    			if (_credentialCorporate1K35Bit != value )
    			{
    				_credentialCorporate1K35Bit = value;
    				OnPropertyChanged(() => CredentialCorporate1K35Bit);
    			}
    		}
    	}
    	
    	private CredentialCorporate1K48Bit _credentialCorporate1K48Bit;
    
    	[DataMember]
    	public virtual CredentialCorporate1K48Bit CredentialCorporate1K48Bit
    	{ 
    		get { return _credentialCorporate1K48Bit; }
    		set
    		{
    			if (_credentialCorporate1K48Bit != value )
    			{
    				_credentialCorporate1K48Bit = value;
    				OnPropertyChanged(() => CredentialCorporate1K48Bit);
    			}
    		}
    	}
    	
    	private CredentialFormat _credentialFormat;
    
    	[DataMember]
    	public virtual CredentialFormat CredentialFormat
    	{ 
    		get { return _credentialFormat; }
    		set
    		{
    			if (_credentialFormat != value )
    			{
    				_credentialFormat = value;
    				OnPropertyChanged(() => CredentialFormat);
    			}
    		}
    	}
    	
    	private CredentialCypress37Bit _credentialCypress37Bit;
    
    	[DataMember]
    	public virtual CredentialCypress37Bit CredentialCypress37Bit
    	{ 
    		get { return _credentialCypress37Bit; }
    		set
    		{
    			if (_credentialCypress37Bit != value )
    			{
    				_credentialCypress37Bit = value;
    				OnPropertyChanged(() => CredentialCypress37Bit);
    			}
    		}
    	}
    	
    	private CredentialData _credentialData;
    
    	[DataMember]
    	public virtual CredentialData CredentialData
    	{ 
    		get { return _credentialData; }
    		set
    		{
    			if (_credentialData != value )
    			{
    				_credentialData = value;
    				OnPropertyChanged(() => CredentialData);
    			}
    		}
    	}
    	
    	private CredentialH1030437Bit _credentialH1030437Bit;
    
    	[DataMember]
    	public virtual CredentialH1030437Bit CredentialH1030437Bit
    	{ 
    		get { return _credentialH1030437Bit; }
    		set
    		{
    			if (_credentialH1030437Bit != value )
    			{
    				_credentialH1030437Bit = value;
    				OnPropertyChanged(() => CredentialH1030437Bit);
    			}
    		}
    	}
    	
    	private CredentialPIV75Bit _credentialPIV75Bit;
    
    	[DataMember]
    	public virtual CredentialPIV75Bit CredentialPIV75Bit
    	{ 
    		get { return _credentialPIV75Bit; }
    		set
    		{
    			if (_credentialPIV75Bit != value )
    			{
    				_credentialPIV75Bit = value;
    				OnPropertyChanged(() => CredentialPIV75Bit);
    			}
    		}
    	}
    	
    	private CredentialXceedId40Bit _credentialXceedId40Bit;
    
    	[DataMember]
    	public virtual CredentialXceedId40Bit CredentialXceedId40Bit
    	{ 
    		get { return _credentialXceedId40Bit; }
    		set
    		{
    			if (_credentialXceedId40Bit != value )
    			{
    				_credentialXceedId40Bit = value;
    				OnPropertyChanged(() => CredentialXceedId40Bit);
    			}
    		}
    	}
    	
    	private ICollection<CredentialToLoadToCpu> _credentialToLoadToCpus;
    
    	[DataMember]
    	public virtual ICollection<CredentialToLoadToCpu> CredentialToLoadToCpus
    	{ 
    		get { return _credentialToLoadToCpus; }
    		set
    		{
    			if (_credentialToLoadToCpus != value )
    			{
    				_credentialToLoadToCpus = value;
    				OnPropertyChanged(() => CredentialToLoadToCpus);
    			}
    		}
    	}
    	
    	private CredentialH1030237Bit _credentialH1030237Bit;
    
    	[DataMember]
    	public virtual CredentialH1030237Bit CredentialH1030237Bit
    	{ 
    		get { return _credentialH1030237Bit; }
    		set
    		{
    			if (_credentialH1030237Bit != value )
    			{
    				_credentialH1030237Bit = value;
    				OnPropertyChanged(() => CredentialH1030237Bit);
    			}
    		}
    	}
    	
    	private CredentialSoftwareHouse37Bit _credentialSoftwareHouse37Bit;
    
    	[DataMember]
    	public virtual CredentialSoftwareHouse37Bit CredentialSoftwareHouse37Bit
    	{ 
    		get { return _credentialSoftwareHouse37Bit; }
    		set
    		{
    			if (_credentialSoftwareHouse37Bit != value )
    			{
    				_credentialSoftwareHouse37Bit = value;
    				OnPropertyChanged(() => CredentialSoftwareHouse37Bit);
    			}
    		}
    	}
    }
    
}
