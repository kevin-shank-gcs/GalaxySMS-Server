    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class InputDeviceActivityEvent
        {
        	public InputDeviceActivityEvent() : base()
        	{
        		Initialize();
        	}
        
        	public InputDeviceActivityEvent(InputDeviceActivityEvent e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(InputDeviceActivityEvent e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
        		this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.CpuUid = e.CpuUid;
        		this.CpuNumber = e.CpuNumber;
        		this.ActivityDateTime = e.ActivityDateTime;
        		this.BufferIndex = e.BufferIndex;
        		this.InsertDate = e.InsertDate;
        		
        	}
        
        	public InputDeviceActivityEvent Clone(InputDeviceActivityEvent e)
        	{
        		return new InputDeviceActivityEvent(e);
        	}
        
        	public bool Equals(InputDeviceActivityEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceActivityEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceActivityEventUid != this.InputDeviceActivityEventUid )
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