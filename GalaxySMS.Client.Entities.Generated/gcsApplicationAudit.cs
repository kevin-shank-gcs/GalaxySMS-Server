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
	public partial class gcsApplicationAudit : DbObjectBase, ITableEntityBase
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
        public partial class gcsApplicationAudit
        {
        	public gcsApplicationAudit() : base()
        	{
        		Initialize();
        	}
        
        	public gcsApplicationAudit(gcsApplicationAudit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(gcsApplicationAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AuditId = e.AuditId;
        		this.ApplicationAuditTypeId = e.ApplicationAuditTypeId;
        		this.TransactionId = e.TransactionId;
        		this.ApplicationId = e.ApplicationId;
        		this.UserId = e.UserId;
        		this.ApplicationName = e.ApplicationName;
        		this.ApplicationVersion = e.ApplicationVersion;
        		this.MachineName = e.MachineName;
        		this.LoginName = e.LoginName;
        		this.WindowsUserName = e.WindowsUserName;
        		this.AuditDetails = e.AuditDetails;
        		this.AuditXml = e.AuditXml;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		
        	}
        
        	public gcsApplicationAudit Clone(gcsApplicationAudit e)
        	{
        		return new gcsApplicationAudit(e);
        	}
        
        	public bool Equals(gcsApplicationAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsApplicationAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AuditId != this.AuditId )
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
    
    	
    	private System.Guid _auditId;
    
    	[DataMember]
    	public System.Guid AuditId
    	{ 
    		get { return _auditId; }
    		set
    		{
    			if (_auditId != value )
    			{
    				_auditId = value;
    				OnPropertyChanged(() => AuditId);
    			}
    		}
    	}
    	
    	private System.Guid _applicationAuditTypeId;
    
    	[DataMember]
    	public System.Guid ApplicationAuditTypeId
    	{ 
    		get { return _applicationAuditTypeId; }
    		set
    		{
    			if (_applicationAuditTypeId != value )
    			{
    				_applicationAuditTypeId = value;
    				OnPropertyChanged(() => ApplicationAuditTypeId);
    			}
    		}
    	}
    	
    	private System.Guid _transactionId;
    
    	[DataMember]
    	public System.Guid TransactionId
    	{ 
    		get { return _transactionId; }
    		set
    		{
    			if (_transactionId != value )
    			{
    				_transactionId = value;
    				OnPropertyChanged(() => TransactionId);
    			}
    		}
    	}
    	
    	private System.Guid _applicationId;
    
    	[DataMember]
    	public System.Guid ApplicationId
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
    	
    	private System.Guid _userId;
    
    	[DataMember]
    	public System.Guid UserId
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
    	
    	private string _applicationVersion;
    
    	[DataMember]
    	public string ApplicationVersion
    	{ 
    		get { return _applicationVersion; }
    		set
    		{
    			if (_applicationVersion != value )
    			{
    				_applicationVersion = value;
    				OnPropertyChanged(() => ApplicationVersion);
    			}
    		}
    	}
    	
    	private string _machineName;
    
    	[DataMember]
    	public string MachineName
    	{ 
    		get { return _machineName; }
    		set
    		{
    			if (_machineName != value )
    			{
    				_machineName = value;
    				OnPropertyChanged(() => MachineName);
    			}
    		}
    	}
    	
    	private string _loginName;
    
    	[DataMember]
    	public string LoginName
    	{ 
    		get { return _loginName; }
    		set
    		{
    			if (_loginName != value )
    			{
    				_loginName = value;
    				OnPropertyChanged(() => LoginName);
    			}
    		}
    	}
    	
    	private string _windowsUserName;
    
    	[DataMember]
    	public string WindowsUserName
    	{ 
    		get { return _windowsUserName; }
    		set
    		{
    			if (_windowsUserName != value )
    			{
    				_windowsUserName = value;
    				OnPropertyChanged(() => WindowsUserName);
    			}
    		}
    	}
    	
    	private string _auditDetails;
    
    	[DataMember]
    	public string AuditDetails
    	{ 
    		get { return _auditDetails; }
    		set
    		{
    			if (_auditDetails != value )
    			{
    				_auditDetails = value;
    				OnPropertyChanged(() => AuditDetails);
    			}
    		}
    	}
    	
    	private string _auditXml;
    
    	[DataMember]
    	public string AuditXml
    	{ 
    		get { return _auditXml; }
    		set
    		{
    			if (_auditXml != value )
    			{
    				_auditXml = value;
    				OnPropertyChanged(() => AuditXml);
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
    
    	
    	private gcsApplicationAuditType _gcsApplicationAuditType;
    
    	[DataMember]
    	public virtual gcsApplicationAuditType gcsApplicationAuditType
    	{ 
    		get { return _gcsApplicationAuditType; }
    		set
    		{
    			if (_gcsApplicationAuditType != value )
    			{
    				_gcsApplicationAuditType = value;
    				OnPropertyChanged(() => gcsApplicationAuditType);
    			}
    		}
    	}
    }
    
}
