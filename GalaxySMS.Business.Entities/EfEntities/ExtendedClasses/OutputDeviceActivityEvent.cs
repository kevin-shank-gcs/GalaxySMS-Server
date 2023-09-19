    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class OutputDeviceActivityEvent
        {
        	public OutputDeviceActivityEvent()
        	{
        		Initialize();
        	}
        
        	public OutputDeviceActivityEvent(OutputDeviceActivityEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(OutputDeviceActivityEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.OutputDeviceActivityEventUid = e.OutputDeviceActivityEventUid;
        		this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
        		this.OutputDeviceUid = e.OutputDeviceUid;
        		this.CpuUid = e.CpuUid;
        		this.CpuNumber = e.CpuNumber;
        		this.ActivityDateTime = e.ActivityDateTime;
        		this.BufferIndex = e.BufferIndex;
        		this.InsertDate = e.InsertDate;
        		this.EventType = e.EventType;
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
        
        	public OutputDeviceActivityEvent Clone(OutputDeviceActivityEvent e)
        	{
        		return new OutputDeviceActivityEvent(e);
        	}
        
        	public bool Equals(OutputDeviceActivityEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(OutputDeviceActivityEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputDeviceActivityEventUid != this.OutputDeviceActivityEventUid )
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
