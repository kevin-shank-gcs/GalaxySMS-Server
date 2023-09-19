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
	public partial class GalaxyPanelCommandAudit : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyPanelCommandAudit
        {
        	public GalaxyPanelCommandAudit() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelCommandAudit(GalaxyPanelCommandAudit e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyPanelCommandAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyPanelCommandAuditUid = e.GalaxyPanelCommandAuditUid;
        		this.GalaxyPanelCommandUid = e.GalaxyPanelCommandUid;
        		this.GalaxyPanelUid = e.GalaxyPanelUid;
        		this.UserId = e.UserId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyPanelCommandAudit Clone(GalaxyPanelCommandAudit e)
        	{
        		return new GalaxyPanelCommandAudit(e);
        	}
        
        	public bool Equals(GalaxyPanelCommandAudit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyPanelCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyPanelCommandAuditUid != this.GalaxyPanelCommandAuditUid )
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
    
    	
    	private System.Guid _galaxyPanelCommandAuditUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelCommandAuditUid
    	{ 
    		get { return _galaxyPanelCommandAuditUid; }
    		set
    		{
    			if (_galaxyPanelCommandAuditUid != value )
    			{
    				_galaxyPanelCommandAuditUid = value;
    				OnPropertyChanged(() => GalaxyPanelCommandAuditUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyPanelCommandUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelCommandUid
    	{ 
    		get { return _galaxyPanelCommandUid; }
    		set
    		{
    			if (_galaxyPanelCommandUid != value )
    			{
    				_galaxyPanelCommandUid = value;
    				OnPropertyChanged(() => GalaxyPanelCommandUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyPanelUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelUid
    	{ 
    		get { return _galaxyPanelUid; }
    		set
    		{
    			if (_galaxyPanelUid != value )
    			{
    				_galaxyPanelUid = value;
    				OnPropertyChanged(() => GalaxyPanelUid);
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
    
    	
    	private GalaxyPanel _galaxyPanel;
    
    	[DataMember]
    	public virtual GalaxyPanel GalaxyPanel
    	{ 
    		get { return _galaxyPanel; }
    		set
    		{
    			if (_galaxyPanel != value )
    			{
    				_galaxyPanel = value;
    				OnPropertyChanged(() => GalaxyPanel);
    			}
    		}
    	}
    	
    	private GalaxyPanelCommand _galaxyPanelCommand;
    
    	[DataMember]
    	public virtual GalaxyPanelCommand GalaxyPanelCommand
    	{ 
    		get { return _galaxyPanelCommand; }
    		set
    		{
    			if (_galaxyPanelCommand != value )
    			{
    				_galaxyPanelCommand = value;
    				OnPropertyChanged(() => GalaxyPanelCommand);
    			}
    		}
    	}
    	
    	private gcsUser _gcsUser;
    
    	[DataMember]
    	public virtual gcsUser gcsUser
    	{ 
    		get { return _gcsUser; }
    		set
    		{
    			if (_gcsUser != value )
    			{
    				_gcsUser = value;
    				OnPropertyChanged(() => gcsUser);
    			}
    		}
    	}
    }
    
}
