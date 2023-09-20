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
	public partial class AccessPortal : DbObjectBase, ITableEntityBase
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
        public partial class AccessPortal
        {
        	public AccessPortal() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortal(AccessPortal e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.AccessPortalGalaxyHardwareAddresses = new HashSet<AccessPortalGalaxyHardwareAddress>();
        		this.AccessPortalProperties = new HashSet<AccessPortalProperty>();
        		this.AccessPortalAreas = new HashSet<AccessPortalArea>();
        		this.AccessPortalTimeSchedules = new HashSet<AccessPortalTimeSchedule>();
        		this.AccessPortalAuxiliaryOutputs = new HashSet<AccessPortalAuxiliaryOutput>();
        		this.AccessPortalNotes = new HashSet<AccessPortalNote>();
        		this.PersonalAccessGroupAccessPortals = new HashSet<PersonalAccessGroupAccessPortal>();
        		this.AccessPortalCommandAudits = new HashSet<AccessPortalCommandAudit>();
        		this.RoleAccessPortals = new HashSet<RoleAccessPortal>();
        		this.AccessPortalActivityEvents = new HashSet<AccessPortalActivityEvent>();
        }
        
        	public void Initialize(AccessPortal e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.AccessPortalTypeUid = e.AccessPortalTypeUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.PortalName = e.PortalName;
        		this.Location = e.Location;
        		this.ServiceComment = e.ServiceComment;
        		this.CriticalityComment = e.CriticalityComment;
        		this.Comment = e.Comment;
        		this.IsTemplate = e.IsTemplate;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.SiteUid = e.SiteUid;
        		this.EntityId = e.EntityId;
        		this.IsEnabled = e.IsEnabled;
        		this.IsEnabledLastUpdated = e.IsEnabledLastUpdated;
        		this.IsBoundToHardware = e.IsBoundToHardware;
        		this.AlertEventsFlag = e.AlertEventsFlag;
        		this.AccessPortalGalaxyHardwareAddresses = e.AccessPortalGalaxyHardwareAddresses.ToCollection();
        		this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
        		this.AccessPortalAreas = e.AccessPortalAreas.ToCollection();
        		this.AccessPortalTimeSchedules = e.AccessPortalTimeSchedules.ToCollection();
        		this.AccessPortalAuxiliaryOutputs = e.AccessPortalAuxiliaryOutputs.ToCollection();
        		this.AccessPortalNotes = e.AccessPortalNotes.ToCollection();
        		this.PersonalAccessGroupAccessPortals = e.PersonalAccessGroupAccessPortals.ToCollection();
        		this.AccessPortalCommandAudits = e.AccessPortalCommandAudits.ToCollection();
        		this.RoleAccessPortals = e.RoleAccessPortals.ToCollection();
        		this.AccessPortalActivityEvents = e.AccessPortalActivityEvents.ToCollection();
        		
        	}
        
        	public AccessPortal Clone(AccessPortal e)
        	{
        		return new AccessPortal(e);
        	}
        
        	public bool Equals(AccessPortal other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortal other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalUid != this.AccessPortalUid )
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
    
    	
    	private System.Guid _accessPortalUid;
    
    	[DataMember]
    	public System.Guid AccessPortalUid
    	{ 
    		get { return _accessPortalUid; }
    		set
    		{
    			if (_accessPortalUid != value )
    			{
    				_accessPortalUid = value;
    				OnPropertyChanged(() => AccessPortalUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessPortalTypeUid;
    
    	[DataMember]
    	public System.Guid AccessPortalTypeUid
    	{ 
    		get { return _accessPortalTypeUid; }
    		set
    		{
    			if (_accessPortalTypeUid != value )
    			{
    				_accessPortalTypeUid = value;
    				OnPropertyChanged(() => AccessPortalTypeUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _binaryResourceUid;
    
    	[DataMember]
    	public Nullable<System.Guid> BinaryResourceUid
    	{ 
    		get { return _binaryResourceUid; }
    		set
    		{
    			if (_binaryResourceUid != value )
    			{
    				_binaryResourceUid = value;
    				OnPropertyChanged(() => BinaryResourceUid);
    			}
    		}
    	}
    	
    	private string _portalName;
    
    	[DataMember]
    	public string PortalName
    	{ 
    		get { return _portalName; }
    		set
    		{
    			if (_portalName != value )
    			{
    				_portalName = value;
    				OnPropertyChanged(() => PortalName);
    			}
    		}
    	}
    	
    	private string _location;
    
    	[DataMember]
    	public string Location
    	{ 
    		get { return _location; }
    		set
    		{
    			if (_location != value )
    			{
    				_location = value;
    				OnPropertyChanged(() => Location);
    			}
    		}
    	}
    	
    	private string _serviceComment;
    
    	[DataMember]
    	public string ServiceComment
    	{ 
    		get { return _serviceComment; }
    		set
    		{
    			if (_serviceComment != value )
    			{
    				_serviceComment = value;
    				OnPropertyChanged(() => ServiceComment);
    			}
    		}
    	}
    	
    	private string _criticalityComment;
    
    	[DataMember]
    	public string CriticalityComment
    	{ 
    		get { return _criticalityComment; }
    		set
    		{
    			if (_criticalityComment != value )
    			{
    				_criticalityComment = value;
    				OnPropertyChanged(() => CriticalityComment);
    			}
    		}
    	}
    	
    	private string _comment;
    
    	[DataMember]
    	public string Comment
    	{ 
    		get { return _comment; }
    		set
    		{
    			if (_comment != value )
    			{
    				_comment = value;
    				OnPropertyChanged(() => Comment);
    			}
    		}
    	}
    	
    	private bool _isTemplate;
    
    	[DataMember]
    	public bool IsTemplate
    	{ 
    		get { return _isTemplate; }
    		set
    		{
    			if (_isTemplate != value )
    			{
    				_isTemplate = value;
    				OnPropertyChanged(() => IsTemplate);
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
    	
    	private System.Guid _siteUid;
    
    	[DataMember]
    	public System.Guid SiteUid
    	{ 
    		get { return _siteUid; }
    		set
    		{
    			if (_siteUid != value )
    			{
    				_siteUid = value;
    				OnPropertyChanged(() => SiteUid);
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
    	
    	private Nullable<System.DateTimeOffset> _isEnabledLastUpdated;
    
    	[DataMember]
    	public Nullable<System.DateTimeOffset> IsEnabledLastUpdated
    	{ 
    		get { return _isEnabledLastUpdated; }
    		set
    		{
    			if (_isEnabledLastUpdated != value )
    			{
    				_isEnabledLastUpdated = value;
    				OnPropertyChanged(() => IsEnabledLastUpdated);
    			}
    		}
    	}
    	
    	private Nullable<bool> _isBoundToHardware;
    
    	[DataMember]
    	public Nullable<bool> IsBoundToHardware
    	{ 
    		get { return _isBoundToHardware; }
    		set
    		{
    			if (_isBoundToHardware != value )
    			{
    				_isBoundToHardware = value;
    				OnPropertyChanged(() => IsBoundToHardware);
    			}
    		}
    	}
    	
    	private Nullable<int> _alertEventsFlag;
    
    	[DataMember]
    	public Nullable<int> AlertEventsFlag
    	{ 
    		get { return _alertEventsFlag; }
    		set
    		{
    			if (_alertEventsFlag != value )
    			{
    				_alertEventsFlag = value;
    				OnPropertyChanged(() => AlertEventsFlag);
    			}
    		}
    	}
    
    	
    	private gcsBinaryResource _gcsBinaryResource;
    
    	[DataMember]
    	public virtual gcsBinaryResource gcsBinaryResource
    	{ 
    		get { return _gcsBinaryResource; }
    		set
    		{
    			if (_gcsBinaryResource != value )
    			{
    				_gcsBinaryResource = value;
    				OnPropertyChanged(() => gcsBinaryResource);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalGalaxyHardwareAddress> _accessPortalGalaxyHardwareAddresses;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalGalaxyHardwareAddress> AccessPortalGalaxyHardwareAddresses
    	{ 
    		get { return _accessPortalGalaxyHardwareAddresses; }
    		set
    		{
    			if (_accessPortalGalaxyHardwareAddresses != value )
    			{
    				_accessPortalGalaxyHardwareAddresses = value;
    				OnPropertyChanged(() => AccessPortalGalaxyHardwareAddresses);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalProperty> _accessPortalProperties;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalProperty> AccessPortalProperties
    	{ 
    		get { return _accessPortalProperties; }
    		set
    		{
    			if (_accessPortalProperties != value )
    			{
    				_accessPortalProperties = value;
    				OnPropertyChanged(() => AccessPortalProperties);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalArea> _accessPortalAreas;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalArea> AccessPortalAreas
    	{ 
    		get { return _accessPortalAreas; }
    		set
    		{
    			if (_accessPortalAreas != value )
    			{
    				_accessPortalAreas = value;
    				OnPropertyChanged(() => AccessPortalAreas);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalTimeSchedule> _accessPortalTimeSchedules;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalTimeSchedule> AccessPortalTimeSchedules
    	{ 
    		get { return _accessPortalTimeSchedules; }
    		set
    		{
    			if (_accessPortalTimeSchedules != value )
    			{
    				_accessPortalTimeSchedules = value;
    				OnPropertyChanged(() => AccessPortalTimeSchedules);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalAuxiliaryOutput> _accessPortalAuxiliaryOutputs;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalAuxiliaryOutput> AccessPortalAuxiliaryOutputs
    	{ 
    		get { return _accessPortalAuxiliaryOutputs; }
    		set
    		{
    			if (_accessPortalAuxiliaryOutputs != value )
    			{
    				_accessPortalAuxiliaryOutputs = value;
    				OnPropertyChanged(() => AccessPortalAuxiliaryOutputs);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalNote> _accessPortalNotes;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalNote> AccessPortalNotes
    	{ 
    		get { return _accessPortalNotes; }
    		set
    		{
    			if (_accessPortalNotes != value )
    			{
    				_accessPortalNotes = value;
    				OnPropertyChanged(() => AccessPortalNotes);
    			}
    		}
    	}
    	
    	private ICollection<PersonalAccessGroupAccessPortal> _personalAccessGroupAccessPortals;
    
    	[DataMember]
    	public virtual ICollection<PersonalAccessGroupAccessPortal> PersonalAccessGroupAccessPortals
    	{ 
    		get { return _personalAccessGroupAccessPortals; }
    		set
    		{
    			if (_personalAccessGroupAccessPortals != value )
    			{
    				_personalAccessGroupAccessPortals = value;
    				OnPropertyChanged(() => PersonalAccessGroupAccessPortals);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalCommandAudit> _accessPortalCommandAudits;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalCommandAudit> AccessPortalCommandAudits
    	{ 
    		get { return _accessPortalCommandAudits; }
    		set
    		{
    			if (_accessPortalCommandAudits != value )
    			{
    				_accessPortalCommandAudits = value;
    				OnPropertyChanged(() => AccessPortalCommandAudits);
    			}
    		}
    	}
    	
    	private ICollection<RoleAccessPortal> _roleAccessPortals;
    
    	[DataMember]
    	public virtual ICollection<RoleAccessPortal> RoleAccessPortals
    	{ 
    		get { return _roleAccessPortals; }
    		set
    		{
    			if (_roleAccessPortals != value )
    			{
    				_roleAccessPortals = value;
    				OnPropertyChanged(() => RoleAccessPortals);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalActivityEvent> _accessPortalActivityEvents;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalActivityEvent> AccessPortalActivityEvents
    	{ 
    		get { return _accessPortalActivityEvents; }
    		set
    		{
    			if (_accessPortalActivityEvents != value )
    			{
    				_accessPortalActivityEvents = value;
    				OnPropertyChanged(() => AccessPortalActivityEvents);
    			}
    		}
    	}
    	
    	private AccessPortalLastUsage _accessPortalLastUsage;
    
    	[DataMember]
    	public virtual AccessPortalLastUsage AccessPortalLastUsage
    	{ 
    		get { return _accessPortalLastUsage; }
    		set
    		{
    			if (_accessPortalLastUsage != value )
    			{
    				_accessPortalLastUsage = value;
    				OnPropertyChanged(() => AccessPortalLastUsage);
    			}
    		}
    	}
    }
    
}
