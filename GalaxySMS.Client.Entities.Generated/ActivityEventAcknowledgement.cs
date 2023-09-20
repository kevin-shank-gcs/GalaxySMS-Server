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
	public partial class ActivityEventAcknowledgement : DbObjectBase, ITableEntityBase
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
        public partial class ActivityEventAcknowledgement
        {
        	public ActivityEventAcknowledgement() : base()
        	{
        		Initialize();
        	}
        
        	public ActivityEventAcknowledgement(ActivityEventAcknowledgement e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(ActivityEventAcknowledgement e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.ActivityEventAcknowledgementUid = e.ActivityEventAcknowledgementUid;
        		this.ActivityEventUid = e.ActivityEventUid;
        		this.DeviceEntityId = e.DeviceEntityId;
        		this.DeviceUid = e.DeviceUid;
        		this.ActivityEventCategory = e.ActivityEventCategory;
        		this.Response = e.Response;
        		this.AckedByUserId = e.AckedByUserId;
        		this.AckedByUserDisplayName = e.AckedByUserDisplayName;
        		this.AckedDateTime = e.AckedDateTime;
        		this.AckedUpdatedDateTime = e.AckedUpdatedDateTime;
        		
        	}
        
        	public ActivityEventAcknowledgement Clone(ActivityEventAcknowledgement e)
        	{
        		return new ActivityEventAcknowledgement(e);
        	}
        
        	public bool Equals(ActivityEventAcknowledgement other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(ActivityEventAcknowledgement other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ActivityEventAcknowledgementUid != this.ActivityEventAcknowledgementUid )
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
    
    	
    	private System.Guid _activityEventAcknowledgementUid;
    
    	[DataMember]
    	public System.Guid ActivityEventAcknowledgementUid
    	{ 
    		get { return _activityEventAcknowledgementUid; }
    		set
    		{
    			if (_activityEventAcknowledgementUid != value )
    			{
    				_activityEventAcknowledgementUid = value;
    				OnPropertyChanged(() => ActivityEventAcknowledgementUid);
    			}
    		}
    	}
    	
    	private System.Guid _activityEventUid;
    
    	[DataMember]
    	public System.Guid ActivityEventUid
    	{ 
    		get { return _activityEventUid; }
    		set
    		{
    			if (_activityEventUid != value )
    			{
    				_activityEventUid = value;
    				OnPropertyChanged(() => ActivityEventUid);
    			}
    		}
    	}
    	
    	private System.Guid _deviceEntityId;
    
    	[DataMember]
    	public System.Guid DeviceEntityId
    	{ 
    		get { return _deviceEntityId; }
    		set
    		{
    			if (_deviceEntityId != value )
    			{
    				_deviceEntityId = value;
    				OnPropertyChanged(() => DeviceEntityId);
    			}
    		}
    	}
    	
    	private System.Guid _deviceUid;
    
    	[DataMember]
    	public System.Guid DeviceUid
    	{ 
    		get { return _deviceUid; }
    		set
    		{
    			if (_deviceUid != value )
    			{
    				_deviceUid = value;
    				OnPropertyChanged(() => DeviceUid);
    			}
    		}
    	}
    	
    	private string _activityEventCategory;
    
    	[DataMember]
    	public string ActivityEventCategory
    	{ 
    		get { return _activityEventCategory; }
    		set
    		{
    			if (_activityEventCategory != value )
    			{
    				_activityEventCategory = value;
    				OnPropertyChanged(() => ActivityEventCategory);
    			}
    		}
    	}
    	
    	private string _response;
    
    	[DataMember]
    	public string Response
    	{ 
    		get { return _response; }
    		set
    		{
    			if (_response != value )
    			{
    				_response = value;
    				OnPropertyChanged(() => Response);
    			}
    		}
    	}
    	
    	private System.Guid _ackedByUserId;
    
    	[DataMember]
    	public System.Guid AckedByUserId
    	{ 
    		get { return _ackedByUserId; }
    		set
    		{
    			if (_ackedByUserId != value )
    			{
    				_ackedByUserId = value;
    				OnPropertyChanged(() => AckedByUserId);
    			}
    		}
    	}
    	
    	private string _ackedByUserDisplayName;
    
    	[DataMember]
    	public string AckedByUserDisplayName
    	{ 
    		get { return _ackedByUserDisplayName; }
    		set
    		{
    			if (_ackedByUserDisplayName != value )
    			{
    				_ackedByUserDisplayName = value;
    				OnPropertyChanged(() => AckedByUserDisplayName);
    			}
    		}
    	}
    	
    	private System.DateTimeOffset _ackedDateTime;
    
    	[DataMember]
    	public System.DateTimeOffset AckedDateTime
    	{ 
    		get { return _ackedDateTime; }
    		set
    		{
    			if (_ackedDateTime != value )
    			{
    				_ackedDateTime = value;
    				OnPropertyChanged(() => AckedDateTime);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTimeOffset> _ackedUpdatedDateTime;
    
    	[DataMember]
    	public Nullable<System.DateTimeOffset> AckedUpdatedDateTime
    	{ 
    		get { return _ackedUpdatedDateTime; }
    		set
    		{
    			if (_ackedUpdatedDateTime != value )
    			{
    				_ackedUpdatedDateTime = value;
    				OnPropertyChanged(() => AckedUpdatedDateTime);
    			}
    		}
    	}
    
    	
    	private ActivityEvent _activityEvent;
    
    	[DataMember]
    	public virtual ActivityEvent ActivityEvent
    	{ 
    		get { return _activityEvent; }
    		set
    		{
    			if (_activityEvent != value )
    			{
    				_activityEvent = value;
    				OnPropertyChanged(() => ActivityEvent);
    			}
    		}
    	}
    }
    
}
