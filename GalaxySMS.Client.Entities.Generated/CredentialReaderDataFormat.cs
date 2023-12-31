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
	public partial class CredentialReaderDataFormat : DbObjectBase, ITableEntityBase
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
        public partial class CredentialReaderDataFormat
        {
        	public CredentialReaderDataFormat() : base()
        	{
        		Initialize();
        	}
        
        	public CredentialReaderDataFormat(CredentialReaderDataFormat e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.CredentialReaderTypes = new HashSet<CredentialReaderType>();
        }
        
        	public void Initialize(CredentialReaderDataFormat e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CredentialReaderDataFormatUid = e.CredentialReaderDataFormatUid;
        		this.DataFormatName = e.DataFormatName;
        		this.PanelDataFormatCode = e.PanelDataFormatCode;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.CredentialReaderTypes = e.CredentialReaderTypes.ToCollection();
        		
        	}
        
        	public CredentialReaderDataFormat Clone(CredentialReaderDataFormat e)
        	{
        		return new CredentialReaderDataFormat(e);
        	}
        
        	public bool Equals(CredentialReaderDataFormat other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialReaderDataFormat other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialReaderDataFormatUid != this.CredentialReaderDataFormatUid )
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
    
    	
    	private System.Guid _credentialReaderDataFormatUid;
    
    	[DataMember]
    	public System.Guid CredentialReaderDataFormatUid
    	{ 
    		get { return _credentialReaderDataFormatUid; }
    		set
    		{
    			if (_credentialReaderDataFormatUid != value )
    			{
    				_credentialReaderDataFormatUid = value;
    				OnPropertyChanged(() => CredentialReaderDataFormatUid);
    			}
    		}
    	}
    	
    	private string _dataFormatName;
    
    	[DataMember]
    	public string DataFormatName
    	{ 
    		get { return _dataFormatName; }
    		set
    		{
    			if (_dataFormatName != value )
    			{
    				_dataFormatName = value;
    				OnPropertyChanged(() => DataFormatName);
    			}
    		}
    	}
    	
    	private int _panelDataFormatCode;
    
    	[DataMember]
    	public int PanelDataFormatCode
    	{ 
    		get { return _panelDataFormatCode; }
    		set
    		{
    			if (_panelDataFormatCode != value )
    			{
    				_panelDataFormatCode = value;
    				OnPropertyChanged(() => PanelDataFormatCode);
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
    
    	
    	private ICollection<CredentialReaderType> _credentialReaderTypes;
    
    	[DataMember]
    	public virtual ICollection<CredentialReaderType> CredentialReaderTypes
    	{ 
    		get { return _credentialReaderTypes; }
    		set
    		{
    			if (_credentialReaderTypes != value )
    			{
    				_credentialReaderTypes = value;
    				OnPropertyChanged(() => CredentialReaderTypes);
    			}
    		}
    	}
    }
    
}
