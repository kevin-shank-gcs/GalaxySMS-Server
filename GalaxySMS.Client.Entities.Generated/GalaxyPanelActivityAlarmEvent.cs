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
	public partial class GalaxyPanelActivityAlarmEvent : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyPanelActivityAlarmEvent
        {
        	public GalaxyPanelActivityAlarmEvent() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelActivityAlarmEvent(GalaxyPanelActivityAlarmEvent e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.GalaxyPanelAlarmEventAcknowledgments = new HashSet<GalaxyPanelAlarmEventAcknowledgment>();
        }
        
        	public void Initialize(GalaxyPanelActivityAlarmEvent e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
        		this.NoteUid = e.NoteUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.AlarmPriority = e.AlarmPriority;
        		this.ResponseRequired = e.ResponseRequired;
        		this.GalaxyPanelAlarmEventAcknowledgments = e.GalaxyPanelAlarmEventAcknowledgments.ToCollection();
        		
        	}
        
        	public GalaxyPanelActivityAlarmEvent Clone(GalaxyPanelActivityAlarmEvent e)
        	{
        		return new GalaxyPanelActivityAlarmEvent(e);
        	}
        
        	public bool Equals(GalaxyPanelActivityAlarmEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyPanelActivityAlarmEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyPanelActivityEventUid != this.GalaxyPanelActivityEventUid )
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
    
    	
    	private System.Guid _galaxyPanelActivityEventUid;
    
    	[DataMember]
    	public System.Guid GalaxyPanelActivityEventUid
    	{ 
    		get { return _galaxyPanelActivityEventUid; }
    		set
    		{
    			if (_galaxyPanelActivityEventUid != value )
    			{
    				_galaxyPanelActivityEventUid = value;
    				OnPropertyChanged(() => GalaxyPanelActivityEventUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _noteUid;
    
    	[DataMember]
    	public Nullable<System.Guid> NoteUid
    	{ 
    		get { return _noteUid; }
    		set
    		{
    			if (_noteUid != value )
    			{
    				_noteUid = value;
    				OnPropertyChanged(() => NoteUid);
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
    	
    	private int _alarmPriority;
    
    	[DataMember]
    	public int AlarmPriority
    	{ 
    		get { return _alarmPriority; }
    		set
    		{
    			if (_alarmPriority != value )
    			{
    				_alarmPriority = value;
    				OnPropertyChanged(() => AlarmPriority);
    			}
    		}
    	}
    	
    	private bool _responseRequired;
    
    	[DataMember]
    	public bool ResponseRequired
    	{ 
    		get { return _responseRequired; }
    		set
    		{
    			if (_responseRequired != value )
    			{
    				_responseRequired = value;
    				OnPropertyChanged(() => ResponseRequired);
    			}
    		}
    	}
    
    	
    	private GalaxyPanelActivityEvent _galaxyPanelActivityEvent;
    
    	[DataMember]
    	public virtual GalaxyPanelActivityEvent GalaxyPanelActivityEvent
    	{ 
    		get { return _galaxyPanelActivityEvent; }
    		set
    		{
    			if (_galaxyPanelActivityEvent != value )
    			{
    				_galaxyPanelActivityEvent = value;
    				OnPropertyChanged(() => GalaxyPanelActivityEvent);
    			}
    		}
    	}
    	
    	private ICollection<GalaxyPanelAlarmEventAcknowledgment> _galaxyPanelAlarmEventAcknowledgments;
    
    	[DataMember]
    	public virtual ICollection<GalaxyPanelAlarmEventAcknowledgment> GalaxyPanelAlarmEventAcknowledgments
    	{ 
    		get { return _galaxyPanelAlarmEventAcknowledgments; }
    		set
    		{
    			if (_galaxyPanelAlarmEventAcknowledgments != value )
    			{
    				_galaxyPanelAlarmEventAcknowledgments = value;
    				OnPropertyChanged(() => GalaxyPanelAlarmEventAcknowledgments);
    			}
    		}
    	}
    }
    
}
