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
	public partial class GalaxyPanelActivityEvent : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyPanelActivityEvent
        {
        	public GalaxyPanelActivityEvent() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelActivityEvent(GalaxyPanelActivityEvent e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyPanelActivityEvent e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
        		this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
        		this.GalaxyPanelUid = e.GalaxyPanelUid;
        		this.CredentialUid = e.CredentialUid;
        		this.PersonUid = e.PersonUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.ActivityDateTime = e.ActivityDateTime;
        		this.CpuUid = e.CpuUid;
        		this.CpuNumber = e.CpuNumber;
        		this.BufferIndex = e.BufferIndex;
        		this.InputOutputGroupNumber = e.InputOutputGroupNumber;
        		this.BoardNumber = e.BoardNumber;
        		this.InsertDate = e.InsertDate;
        		this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
        		this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
        		this.GalaxyHardwareModuleUid = e.GalaxyHardwareModuleUid;
        		this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
        		this.SectionNumber = e.SectionNumber;
        		this.ModuleNumber = e.ModuleNumber;
        		this.NodeNumber = e.NodeNumber;
        		this.ActivityDateTimeUTC = e.ActivityDateTimeUTC;
        		
        	}
        
        	public GalaxyPanelActivityEvent Clone(GalaxyPanelActivityEvent e)
        	{
        		return new GalaxyPanelActivityEvent(e);
        	}
        
        	public bool Equals(GalaxyPanelActivityEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyPanelActivityEvent other)
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
    	
    	private System.Guid _galaxyActivityEventTypeUid;
    
    	[DataMember]
    	public System.Guid GalaxyActivityEventTypeUid
    	{ 
    		get { return _galaxyActivityEventTypeUid; }
    		set
    		{
    			if (_galaxyActivityEventTypeUid != value )
    			{
    				_galaxyActivityEventTypeUid = value;
    				OnPropertyChanged(() => GalaxyActivityEventTypeUid);
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
    	
    	private Nullable<System.Guid> _credentialUid;
    
    	[DataMember]
    	public Nullable<System.Guid> CredentialUid
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
    	
    	private Nullable<System.Guid> _personUid;
    
    	[DataMember]
    	public Nullable<System.Guid> PersonUid
    	{ 
    		get { return _personUid; }
    		set
    		{
    			if (_personUid != value )
    			{
    				_personUid = value;
    				OnPropertyChanged(() => PersonUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _inputOutputGroupUid;
    
    	[DataMember]
    	public Nullable<System.Guid> InputOutputGroupUid
    	{ 
    		get { return _inputOutputGroupUid; }
    		set
    		{
    			if (_inputOutputGroupUid != value )
    			{
    				_inputOutputGroupUid = value;
    				OnPropertyChanged(() => InputOutputGroupUid);
    			}
    		}
    	}
    	
    	private System.DateTime _activityDateTime;
    
    	[DataMember]
    	public System.DateTime ActivityDateTime
    	{ 
    		get { return _activityDateTime; }
    		set
    		{
    			if (_activityDateTime != value )
    			{
    				_activityDateTime = value;
    				OnPropertyChanged(() => ActivityDateTime);
    			}
    		}
    	}
    	
    	private System.Guid _cpuUid;
    
    	[DataMember]
    	public System.Guid CpuUid
    	{ 
    		get { return _cpuUid; }
    		set
    		{
    			if (_cpuUid != value )
    			{
    				_cpuUid = value;
    				OnPropertyChanged(() => CpuUid);
    			}
    		}
    	}
    	
    	private short _cpuNumber;
    
    	[DataMember]
    	public short CpuNumber
    	{ 
    		get { return _cpuNumber; }
    		set
    		{
    			if (_cpuNumber != value )
    			{
    				_cpuNumber = value;
    				OnPropertyChanged(() => CpuNumber);
    			}
    		}
    	}
    	
    	private int _bufferIndex;
    
    	[DataMember]
    	public int BufferIndex
    	{ 
    		get { return _bufferIndex; }
    		set
    		{
    			if (_bufferIndex != value )
    			{
    				_bufferIndex = value;
    				OnPropertyChanged(() => BufferIndex);
    			}
    		}
    	}
    	
    	private Nullable<int> _inputOutputGroupNumber;
    
    	[DataMember]
    	public Nullable<int> InputOutputGroupNumber
    	{ 
    		get { return _inputOutputGroupNumber; }
    		set
    		{
    			if (_inputOutputGroupNumber != value )
    			{
    				_inputOutputGroupNumber = value;
    				OnPropertyChanged(() => InputOutputGroupNumber);
    			}
    		}
    	}
    	
    	private Nullable<int> _boardNumber;
    
    	[DataMember]
    	public Nullable<int> BoardNumber
    	{ 
    		get { return _boardNumber; }
    		set
    		{
    			if (_boardNumber != value )
    			{
    				_boardNumber = value;
    				OnPropertyChanged(() => BoardNumber);
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
    	
    	private Nullable<System.Guid> _galaxyInterfaceBoardUid;
    
    	[DataMember]
    	public Nullable<System.Guid> GalaxyInterfaceBoardUid
    	{ 
    		get { return _galaxyInterfaceBoardUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardUid != value )
    			{
    				_galaxyInterfaceBoardUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _galaxyInterfaceBoardSectionUid;
    
    	[DataMember]
    	public Nullable<System.Guid> GalaxyInterfaceBoardSectionUid
    	{ 
    		get { return _galaxyInterfaceBoardSectionUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionUid != value )
    			{
    				_galaxyInterfaceBoardSectionUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _galaxyHardwareModuleUid;
    
    	[DataMember]
    	public Nullable<System.Guid> GalaxyHardwareModuleUid
    	{ 
    		get { return _galaxyHardwareModuleUid; }
    		set
    		{
    			if (_galaxyHardwareModuleUid != value )
    			{
    				_galaxyHardwareModuleUid = value;
    				OnPropertyChanged(() => GalaxyHardwareModuleUid);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _galaxyInterfaceBoardSectionNodeUid;
    
    	[DataMember]
    	public Nullable<System.Guid> GalaxyInterfaceBoardSectionNodeUid
    	{ 
    		get { return _galaxyInterfaceBoardSectionNodeUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionNodeUid != value )
    			{
    				_galaxyInterfaceBoardSectionNodeUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionNodeUid);
    			}
    		}
    	}
    	
    	private Nullable<int> _sectionNumber;
    
    	[DataMember]
    	public Nullable<int> SectionNumber
    	{ 
    		get { return _sectionNumber; }
    		set
    		{
    			if (_sectionNumber != value )
    			{
    				_sectionNumber = value;
    				OnPropertyChanged(() => SectionNumber);
    			}
    		}
    	}
    	
    	private Nullable<int> _moduleNumber;
    
    	[DataMember]
    	public Nullable<int> ModuleNumber
    	{ 
    		get { return _moduleNumber; }
    		set
    		{
    			if (_moduleNumber != value )
    			{
    				_moduleNumber = value;
    				OnPropertyChanged(() => ModuleNumber);
    			}
    		}
    	}
    	
    	private Nullable<int> _nodeNumber;
    
    	[DataMember]
    	public Nullable<int> NodeNumber
    	{ 
    		get { return _nodeNumber; }
    		set
    		{
    			if (_nodeNumber != value )
    			{
    				_nodeNumber = value;
    				OnPropertyChanged(() => NodeNumber);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTimeOffset> _activityDateTimeUTC;
    
    	[DataMember]
    	public Nullable<System.DateTimeOffset> ActivityDateTimeUTC
    	{ 
    		get { return _activityDateTimeUTC; }
    		set
    		{
    			if (_activityDateTimeUTC != value )
    			{
    				_activityDateTimeUTC = value;
    				OnPropertyChanged(() => ActivityDateTimeUTC);
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
    	
    	private GalaxyPanelActivityAlarmEvent _galaxyPanelActivityAlarmEvent;
    
    	[DataMember]
    	public virtual GalaxyPanelActivityAlarmEvent GalaxyPanelActivityAlarmEvent
    	{ 
    		get { return _galaxyPanelActivityAlarmEvent; }
    		set
    		{
    			if (_galaxyPanelActivityAlarmEvent != value )
    			{
    				_galaxyPanelActivityAlarmEvent = value;
    				OnPropertyChanged(() => GalaxyPanelActivityAlarmEvent);
    			}
    		}
    	}
    }
    
}
