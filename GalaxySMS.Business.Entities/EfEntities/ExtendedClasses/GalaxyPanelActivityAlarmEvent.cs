    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class GalaxyPanelActivityAlarmEvent
        {
        	public GalaxyPanelActivityAlarmEvent()
        	{
        		Initialize();
        	}
        
        	public GalaxyPanelActivityAlarmEvent(GalaxyPanelActivityAlarmEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.GalaxyPanelAlarmEventAcknowledgments = new HashSet<GalaxyPanelAlarmEventAcknowledgment>();
        	}
        
        	public void Initialize(GalaxyPanelActivityAlarmEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.GalaxyPanelActivityEventUid = e.GalaxyPanelActivityEventUid;
        		this.NoteUid = e.NoteUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.AlarmPriority = e.AlarmPriority;
        		this.GalaxyPanelAlarmEventAcknowledgments = e.GalaxyPanelAlarmEventAcknowledgments.ToCollection();
        		
        	}
        
        	public bool IsAnythingDirty
        	{
        		get
        		{
        			//foreach( var o in InterfaceBoardSections)
        			//{
        			//	if (o.IsAnythingDirty == true)
        			//		return true;
        			//}
        			return IsDirty;                
        		}
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
