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
	public partial class gcsLog : DbObjectBase, ITableEntityBase
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
        public partial class gcsLog
        {
        	public gcsLog() : base()
        	{
        		Initialize();
        	}
        
        	public gcsLog(gcsLog e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(gcsLog e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.LogId = e.LogId;
        		this.ApplicationId = e.ApplicationId;
        		this.ApplicationName = e.ApplicationName;
        		this.EntityId = e.EntityId;
        		this.EntityName = e.EntityName;
        		this.UserId = e.UserId;
        		this.UserName = e.UserName;
        		this.LogType = e.LogType;
        		this.ServerName = e.ServerName;
        		this.ClientName = e.ClientName;
        		this.ResourceName = e.ResourceName;
        		this.ResourceKey = e.ResourceKey;
        		this.LogInfo = e.LogInfo;
        		this.SystemInfo = e.SystemInfo;
        		this.ExtraInfo = e.ExtraInfo;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public gcsLog Clone(gcsLog e)
        	{
        		return new gcsLog(e);
        	}
        
        	public bool Equals(gcsLog other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsLog other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.LogId != this.LogId )
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
    
    	
    	private System.Guid _logId;
    
    	[DataMember]
    	public System.Guid LogId
    	{ 
    		get { return _logId; }
    		set
    		{
    			if (_logId != value )
    			{
    				_logId = value;
    				OnPropertyChanged(() => LogId);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _applicationId;
    
    	[DataMember]
    	public Nullable<System.Guid> ApplicationId
    	{ 
    		get { return _applicationId; }
    		set
    		{
    			if (_applicationId != value )
    			{
    				_applicationId = value;
    				OnPropertyChanged(() => ApplicationId);
    			}
    		}
    	}
    	
    	private string _applicationName;
    
    	[DataMember]
    	public string ApplicationName
    	{ 
    		get { return _applicationName; }
    		set
    		{
    			if (_applicationName != value )
    			{
    				_applicationName = value;
    				OnPropertyChanged(() => ApplicationName);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _entityId;
    
    	[DataMember]
    	public Nullable<System.Guid> EntityId
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
    	
    	private string _entityName;
    
    	[DataMember]
    	public string EntityName
    	{ 
    		get { return _entityName; }
    		set
    		{
    			if (_entityName != value )
    			{
    				_entityName = value;
    				OnPropertyChanged(() => EntityName);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _userId;
    
    	[DataMember]
    	public Nullable<System.Guid> UserId
    	{ 
    		get { return _userId; }
    		set
    		{
    			if (_userId != value )
    			{
    				_userId = value;
    				OnPropertyChanged(() => UserId);
    			}
    		}
    	}
    	
    	private string _userName;
    
    	[DataMember]
    	public string UserName
    	{ 
    		get { return _userName; }
    		set
    		{
    			if (_userName != value )
    			{
    				_userName = value;
    				OnPropertyChanged(() => UserName);
    			}
    		}
    	}
    	
    	private string _logType;
    
    	[DataMember]
    	public string LogType
    	{ 
    		get { return _logType; }
    		set
    		{
    			if (_logType != value )
    			{
    				_logType = value;
    				OnPropertyChanged(() => LogType);
    			}
    		}
    	}
    	
    	private string _serverName;
    
    	[DataMember]
    	public string ServerName
    	{ 
    		get { return _serverName; }
    		set
    		{
    			if (_serverName != value )
    			{
    				_serverName = value;
    				OnPropertyChanged(() => ServerName);
    			}
    		}
    	}
    	
    	private string _clientName;
    
    	[DataMember]
    	public string ClientName
    	{ 
    		get { return _clientName; }
    		set
    		{
    			if (_clientName != value )
    			{
    				_clientName = value;
    				OnPropertyChanged(() => ClientName);
    			}
    		}
    	}
    	
    	private string _resourceName;
    
    	[DataMember]
    	public string ResourceName
    	{ 
    		get { return _resourceName; }
    		set
    		{
    			if (_resourceName != value )
    			{
    				_resourceName = value;
    				OnPropertyChanged(() => ResourceName);
    			}
    		}
    	}
    	
    	private string _resourceKey;
    
    	[DataMember]
    	public string ResourceKey
    	{ 
    		get { return _resourceKey; }
    		set
    		{
    			if (_resourceKey != value )
    			{
    				_resourceKey = value;
    				OnPropertyChanged(() => ResourceKey);
    			}
    		}
    	}
    	
    	private string _logInfo;
    
    	[DataMember]
    	public string LogInfo
    	{ 
    		get { return _logInfo; }
    		set
    		{
    			if (_logInfo != value )
    			{
    				_logInfo = value;
    				OnPropertyChanged(() => LogInfo);
    			}
    		}
    	}
    	
    	private string _systemInfo;
    
    	[DataMember]
    	public string SystemInfo
    	{ 
    		get { return _systemInfo; }
    		set
    		{
    			if (_systemInfo != value )
    			{
    				_systemInfo = value;
    				OnPropertyChanged(() => SystemInfo);
    			}
    		}
    	}
    	
    	private string _extraInfo;
    
    	[DataMember]
    	public string ExtraInfo
    	{ 
    		get { return _extraInfo; }
    		set
    		{
    			if (_extraInfo != value )
    			{
    				_extraInfo = value;
    				OnPropertyChanged(() => ExtraInfo);
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
    }
    
}
