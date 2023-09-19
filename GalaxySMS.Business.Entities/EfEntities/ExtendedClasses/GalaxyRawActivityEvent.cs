    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class GalaxyRawActivityEvent
        {
        	public GalaxyRawActivityEvent()
        	{
        		Initialize();
        	}
        
        	public GalaxyRawActivityEvent(GalaxyRawActivityEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(GalaxyRawActivityEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.GalaxyRawActivityEventUid = e.GalaxyRawActivityEventUid;
        		this.CpuUid = e.CpuUid;
        		this.InsertDate = e.InsertDate;
        		this.ClusterGroupId = e.ClusterGroupId;
        		this.ClusterNumber = e.ClusterNumber;
        		this.PanelNumber = e.PanelNumber;
        		this.CpuNumber = e.CpuNumber;
        		this.EventDateTime = e.EventDateTime;
        		this.EventType = e.EventType;
        		this.BufferIndex = e.BufferIndex;
        		this.CredentialBytes = e.CredentialBytes;
        		this.Pin = e.Pin;
        		this.BitCount = e.BitCount;
        		this.InputOutputGroupNumber = e.InputOutputGroupNumber;
        		this.BoardNumber = e.BoardNumber;
        		this.SectionNumber = e.SectionNumber;
        		this.NodeNumber = e.NodeNumber;
        		this.RawData = e.RawData;
        		this.UniqueEventId = e.UniqueEventId;
        		
        	}
        
       
        	public GalaxyRawActivityEvent Clone(GalaxyRawActivityEvent e)
        	{
        		return new GalaxyRawActivityEvent(e);
        	}
        
        	public bool Equals(GalaxyRawActivityEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyRawActivityEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyRawActivityEventUid != this.GalaxyRawActivityEventUid )
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
