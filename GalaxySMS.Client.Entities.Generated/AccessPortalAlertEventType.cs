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
	public partial class AccessPortalAlertEventType : DbObjectBase, ITableEntityBase
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
        public partial class AccessPortalAlertEventType
        {
        	public AccessPortalAlertEventType() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortalAlertEventType(AccessPortalAlertEventType e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.AccessPortalAlertEvents = new HashSet<AccessPortalAlertEvent>();
        		this.AccessPortalAuxiliaryOutputTriggeringEvents = new HashSet<AccessPortalAuxiliaryOutputTriggeringEvent>();
        }
        
        	public void Initialize(AccessPortalAlertEventType e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.Tag = e.Tag;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.CanAcknowledge = e.CanAcknowledge;
        		this.CanHaveInputOutputGroupOffset = e.CanHaveInputOutputGroupOffset;
        		this.CanHaveSchedule = e.CanHaveSchedule;
        		this.CanHaveAudio = e.CanHaveAudio;
        		this.CanHaveInstructions = e.CanHaveInstructions;
        		this.Flag = e.Flag;
        		this.AccessPortalAlertEvents = e.AccessPortalAlertEvents.ToCollection();
        		this.AccessPortalAuxiliaryOutputTriggeringEvents = e.AccessPortalAuxiliaryOutputTriggeringEvents.ToCollection();
        		
        	}
        
        	public AccessPortalAlertEventType Clone(AccessPortalAlertEventType e)
        	{
        		return new AccessPortalAlertEventType(e);
        	}
        
        	public bool Equals(AccessPortalAlertEventType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalAlertEventType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalAlertEventTypeUid != this.AccessPortalAlertEventTypeUid )
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
    
    	
    	private System.Guid _accessPortalAlertEventTypeUid;
    
    	[DataMember]
    	public System.Guid AccessPortalAlertEventTypeUid
    	{ 
    		get { return _accessPortalAlertEventTypeUid; }
    		set
    		{
    			if (_accessPortalAlertEventTypeUid != value )
    			{
    				_accessPortalAlertEventTypeUid = value;
    				OnPropertyChanged(() => AccessPortalAlertEventTypeUid);
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
    	
    	private string _tag;
    
    	[DataMember]
    	public string Tag
    	{ 
    		get { return _tag; }
    		set
    		{
    			if (_tag != value )
    			{
    				_tag = value;
    				OnPropertyChanged(() => Tag);
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
    	
    	private bool _canAcknowledge;
    
    	[DataMember]
    	public bool CanAcknowledge
    	{ 
    		get { return _canAcknowledge; }
    		set
    		{
    			if (_canAcknowledge != value )
    			{
    				_canAcknowledge = value;
    				OnPropertyChanged(() => CanAcknowledge);
    			}
    		}
    	}
    	
    	private bool _canHaveInputOutputGroupOffset;
    
    	[DataMember]
    	public bool CanHaveInputOutputGroupOffset
    	{ 
    		get { return _canHaveInputOutputGroupOffset; }
    		set
    		{
    			if (_canHaveInputOutputGroupOffset != value )
    			{
    				_canHaveInputOutputGroupOffset = value;
    				OnPropertyChanged(() => CanHaveInputOutputGroupOffset);
    			}
    		}
    	}
    	
    	private bool _canHaveSchedule;
    
    	[DataMember]
    	public bool CanHaveSchedule
    	{ 
    		get { return _canHaveSchedule; }
    		set
    		{
    			if (_canHaveSchedule != value )
    			{
    				_canHaveSchedule = value;
    				OnPropertyChanged(() => CanHaveSchedule);
    			}
    		}
    	}
    	
    	private bool _canHaveAudio;
    
    	[DataMember]
    	public bool CanHaveAudio
    	{ 
    		get { return _canHaveAudio; }
    		set
    		{
    			if (_canHaveAudio != value )
    			{
    				_canHaveAudio = value;
    				OnPropertyChanged(() => CanHaveAudio);
    			}
    		}
    	}
    	
    	private bool _canHaveInstructions;
    
    	[DataMember]
    	public bool CanHaveInstructions
    	{ 
    		get { return _canHaveInstructions; }
    		set
    		{
    			if (_canHaveInstructions != value )
    			{
    				_canHaveInstructions = value;
    				OnPropertyChanged(() => CanHaveInstructions);
    			}
    		}
    	}
    	
    	private int _flag;
    
    	[DataMember]
    	public int Flag
    	{ 
    		get { return _flag; }
    		set
    		{
    			if (_flag != value )
    			{
    				_flag = value;
    				OnPropertyChanged(() => Flag);
    			}
    		}
    	}
    
    	
    	private ICollection<AccessPortalAlertEvent> _accessPortalAlertEvents;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalAlertEvent> AccessPortalAlertEvents
    	{ 
    		get { return _accessPortalAlertEvents; }
    		set
    		{
    			if (_accessPortalAlertEvents != value )
    			{
    				_accessPortalAlertEvents = value;
    				OnPropertyChanged(() => AccessPortalAlertEvents);
    			}
    		}
    	}
    	
    	private ICollection<AccessPortalAuxiliaryOutputTriggeringEvent> _accessPortalAuxiliaryOutputTriggeringEvents;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalAuxiliaryOutputTriggeringEvent> AccessPortalAuxiliaryOutputTriggeringEvents
    	{ 
    		get { return _accessPortalAuxiliaryOutputTriggeringEvents; }
    		set
    		{
    			if (_accessPortalAuxiliaryOutputTriggeringEvents != value )
    			{
    				_accessPortalAuxiliaryOutputTriggeringEvents = value;
    				OnPropertyChanged(() => AccessPortalAuxiliaryOutputTriggeringEvents);
    			}
    		}
    	}
    }
    
}
