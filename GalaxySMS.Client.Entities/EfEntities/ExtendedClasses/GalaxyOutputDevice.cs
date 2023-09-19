    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyOutputDevice
        {
        	public GalaxyOutputDevice() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyOutputDevice(GalaxyOutputDevice e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.GalaxyOutputDeviceInputSources = new HashSet<GalaxyOutputDeviceInputSource>();
                this.GalaxyHardwareAddress = new OutputDeviceGalaxyHardwareAddress();
        }
        
        	public void Initialize(GalaxyOutputDevice e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.OutputDeviceUid = e.OutputDeviceUid;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.GalaxyOutputModeUid = e.GalaxyOutputModeUid;
        		this.GalaxyOutputInputSourceRelationshipUid = e.GalaxyOutputInputSourceRelationshipUid;
        		this.TimeoutDuration = e.TimeoutDuration;
        		this.Limit = e.Limit;
        		this.InvertOutput = e.InvertOutput;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
                if( e.GalaxyOutputDeviceInputSources != null)
        		    this.GalaxyOutputDeviceInputSources = e.GalaxyOutputDeviceInputSources.ToCollection();
                this.GalaxyHardwareAddress = e.GalaxyHardwareAddress;
	
        	}
        
        	public GalaxyOutputDevice Clone(GalaxyOutputDevice e)
        	{
        		return new GalaxyOutputDevice(e);
        	}
        
        	public bool Equals(GalaxyOutputDevice other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyOutputDevice other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputDeviceUid != this.OutputDeviceUid )
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
