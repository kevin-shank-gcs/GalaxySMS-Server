    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyOutputDeviceInputSourceInputOutputGroup
        {
        	public GalaxyOutputDeviceInputSourceInputOutputGroup() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyOutputDeviceInputSourceInputOutputGroup(GalaxyOutputDeviceInputSourceInputOutputGroup e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyOutputDeviceInputSourceInputOutputGroupUid = e.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
        		this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyOutputDeviceInputSourceInputOutputGroup Clone(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        	{
        		return new GalaxyOutputDeviceInputSourceInputOutputGroup(e);
        	}
        
        	public bool Equals(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyOutputDeviceInputSourceInputOutputGroupUid != this.GalaxyOutputDeviceInputSourceInputOutputGroupUid )
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
