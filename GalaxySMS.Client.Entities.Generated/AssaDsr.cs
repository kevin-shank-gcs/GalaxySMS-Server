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
	public partial class AssaDsr : DbObjectBase, ITableEntityBase
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
        public partial class AssaDsr
        {
        	public AssaDsr() : base()
        	{
        		Initialize();
        	}
        
        	public AssaDsr(AssaDsr e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.AssaDsrTimeScheduleMaps = new HashSet<AssaDsrTimeScheduleMap>();
        		this.AssaAccessPoints = new HashSet<AssaAccessPoint>();
        }
        
        	public void Initialize(AssaDsr e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AssaDsrUid = e.AssaDsrUid;
        		this.Name = e.Name;
        		this.ServerUrl = e.ServerUrl;
        		this.CallbackUrl = e.CallbackUrl;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.ServerIpAddress = e.ServerIpAddress;
        		this.ServerPort = e.ServerPort;
        		this.UseHttps = e.UseHttps;
        		this.EntityId = e.EntityId;
        		this.AssaDsrTimeScheduleMaps = e.AssaDsrTimeScheduleMaps.ToCollection();
        		this.AssaAccessPoints = e.AssaAccessPoints.ToCollection();
        		
        	}
        
        	public AssaDsr Clone(AssaDsr e)
        	{
        		return new AssaDsr(e);
        	}
        
        	public bool Equals(AssaDsr other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AssaDsr other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AssaDsrUid != this.AssaDsrUid )
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
    
    	
    	private System.Guid _assaDsrUid;
    
    	[DataMember]
    	public System.Guid AssaDsrUid
    	{ 
    		get { return _assaDsrUid; }
    		set
    		{
    			if (_assaDsrUid != value )
    			{
    				_assaDsrUid = value;
    				OnPropertyChanged(() => AssaDsrUid);
    			}
    		}
    	}
    	
    	private string _name;
    
    	[DataMember]
    	public string Name
    	{ 
    		get { return _name; }
    		set
    		{
    			if (_name != value )
    			{
    				_name = value;
    				OnPropertyChanged(() => Name);
    			}
    		}
    	}
    	
    	private string _serverUrl;
    
    	[DataMember]
    	public string ServerUrl
    	{ 
    		get { return _serverUrl; }
    		set
    		{
    			if (_serverUrl != value )
    			{
    				_serverUrl = value;
    				OnPropertyChanged(() => ServerUrl);
    			}
    		}
    	}
    	
    	private string _callbackUrl;
    
    	[DataMember]
    	public string CallbackUrl
    	{ 
    		get { return _callbackUrl; }
    		set
    		{
    			if (_callbackUrl != value )
    			{
    				_callbackUrl = value;
    				OnPropertyChanged(() => CallbackUrl);
    			}
    		}
    	}
    	
    	private bool _isActive;
    
    	[DataMember]
    	public bool IsActive
    	{ 
    		get { return _isActive; }
    		set
    		{
    			if (_isActive != value )
    			{
    				_isActive = value;
    				OnPropertyChanged(() => IsActive);
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
    	
    	private string _serverIpAddress;
    
    	[DataMember]
    	public string ServerIpAddress
    	{ 
    		get { return _serverIpAddress; }
    		set
    		{
    			if (_serverIpAddress != value )
    			{
    				_serverIpAddress = value;
    				OnPropertyChanged(() => ServerIpAddress);
    			}
    		}
    	}
    	
    	private int _serverPort;
    
    	[DataMember]
    	public int ServerPort
    	{ 
    		get { return _serverPort; }
    		set
    		{
    			if (_serverPort != value )
    			{
    				_serverPort = value;
    				OnPropertyChanged(() => ServerPort);
    			}
    		}
    	}
    	
    	private bool _useHttps;
    
    	[DataMember]
    	public bool UseHttps
    	{ 
    		get { return _useHttps; }
    		set
    		{
    			if (_useHttps != value )
    			{
    				_useHttps = value;
    				OnPropertyChanged(() => UseHttps);
    			}
    		}
    	}
    	
    	private System.Guid _entityId;
    
    	[DataMember]
    	public System.Guid EntityId
    	{ 
    		get { return _entityId; }
    		set
    		{
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
    			}
    		}
    	}
    
    	
    	private ICollection<AssaDsrTimeScheduleMap> _assaDsrTimeScheduleMaps;
    
    	[DataMember]
    	public virtual ICollection<AssaDsrTimeScheduleMap> AssaDsrTimeScheduleMaps
    	{ 
    		get { return _assaDsrTimeScheduleMaps; }
    		set
    		{
    			if (_assaDsrTimeScheduleMaps != value )
    			{
    				_assaDsrTimeScheduleMaps = value;
    				OnPropertyChanged(() => AssaDsrTimeScheduleMaps);
    			}
    		}
    	}
    	
    	private ICollection<AssaAccessPoint> _assaAccessPoints;
    
    	[DataMember]
    	public virtual ICollection<AssaAccessPoint> AssaAccessPoints
    	{ 
    		get { return _assaAccessPoints; }
    		set
    		{
    			if (_assaAccessPoints != value )
    			{
    				_assaAccessPoints = value;
    				OnPropertyChanged(() => AssaAccessPoints);
    			}
    		}
    	}
    }
    
}
