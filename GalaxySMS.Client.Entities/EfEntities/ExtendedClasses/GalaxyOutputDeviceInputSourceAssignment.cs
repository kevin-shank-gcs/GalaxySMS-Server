    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyOutputDeviceInputSourceAssignment
        {
        	public GalaxyOutputDeviceInputSourceAssignment() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyOutputDeviceInputSourceAssignment(GalaxyOutputDeviceInputSourceAssignment e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyOutputDeviceInputSourceAssignment e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyOutputDeviceInputSourceAssignmentUid = e.GalaxyOutputDeviceInputSourceAssignmentUid;
        		this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
        		this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyOutputDeviceInputSourceAssignment Clone(GalaxyOutputDeviceInputSourceAssignment e)
        	{
        		return new GalaxyOutputDeviceInputSourceAssignment(e);
        	}
        
        	public bool Equals(GalaxyOutputDeviceInputSourceAssignment other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSourceAssignment other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyOutputDeviceInputSourceAssignmentUid != this.GalaxyOutputDeviceInputSourceAssignmentUid )
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
