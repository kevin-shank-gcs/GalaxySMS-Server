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
	public partial class CredentialCypress37Bit : DbObjectBase, ITableEntityBase
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
        public partial class CredentialCypress37Bit
        {
        	public CredentialCypress37Bit() : base()
        	{
        		Initialize();
        	}
        
        	public CredentialCypress37Bit(CredentialCypress37Bit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(CredentialCypress37Bit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialUid = e.CredentialUid;
        		this.FacilityCode = e.FacilityCode;
        		this.IdCode = e.IdCode;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public CredentialCypress37Bit Clone(CredentialCypress37Bit e)
        	{
        		return new CredentialCypress37Bit(e);
        	}
        
        	public bool Equals(CredentialCypress37Bit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialCypress37Bit other)
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
    	
    	private int _facilityCode;
    
    	[DataMember]
    	public int FacilityCode
    	{ 
    		get { return _facilityCode; }
    		set
    		{
    			if (_facilityCode != value )
    			{
    				_facilityCode = value;
    				OnPropertyChanged(() => FacilityCode);
    			}
    		}
    	}
    	
    	private int _idCode;
    
    	[DataMember]
    	public int IdCode
    	{ 
    		get { return _idCode; }
    		set
    		{
    			if (_idCode != value )
    			{
    				_idCode = value;
    				OnPropertyChanged(() => IdCode);
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
    
    	
    	private Credential _credential;
    
    	[DataMember]
    	public virtual Credential Credential
    	{ 
    		get { return _credential; }
    		set
    		{
    			if (_credential != value )
    			{
    				_credential = value;
    				OnPropertyChanged(() => Credential);
    			}
    		}
    	}
    }
    
}
