    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class AccessPortalLoadToCpu
        {
        	public AccessPortalLoadToCpu() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortalLoadToCpu(AccessPortalLoadToCpu e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessPortalLoadToCpu e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalLoadToCpuUid = e.AccessPortalLoadToCpuUid;
        		this.AccessPortalGalaxyHardwareAddressUid = e.AccessPortalGalaxyHardwareAddressUid;
        		this.CpuUid = e.CpuUid;
        		this.LastForceLoadDate = e.LastForceLoadDate;
        		this.LastLoadedDate = e.LastLoadedDate;
        		
        	}
        
        	public AccessPortalLoadToCpu Clone(AccessPortalLoadToCpu e)
        	{
        		return new AccessPortalLoadToCpu(e);
        	}
        
        	public bool Equals(AccessPortalLoadToCpu other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalLoadToCpu other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalLoadToCpuUid != this.AccessPortalLoadToCpuUid )
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
