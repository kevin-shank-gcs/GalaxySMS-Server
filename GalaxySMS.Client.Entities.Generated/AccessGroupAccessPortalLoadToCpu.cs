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
	public partial class AccessGroupAccessPortalLoadToCpu : DbObjectBase, ITableEntityBase
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
        public partial class AccessGroupAccessPortalLoadToCpu
        {
        	public AccessGroupAccessPortalLoadToCpu() : base()
        	{
        		Initialize();
        	}
        
        	public AccessGroupAccessPortalLoadToCpu(AccessGroupAccessPortalLoadToCpu e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessGroupAccessPortalLoadToCpu e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessGroupAccessPortalLoadToCpuUid = e.AccessGroupAccessPortalLoadToCpuUid;
        		this.AccessGroupAccessPortalUid = e.AccessGroupAccessPortalUid;
        		this.CpuUid = e.CpuUid;
        		this.LastLoadedDate = e.LastLoadedDate;
        		this.LastForceLoadDate = e.LastForceLoadDate;
        		
        	}
        
        	public AccessGroupAccessPortalLoadToCpu Clone(AccessGroupAccessPortalLoadToCpu e)
        	{
        		return new AccessGroupAccessPortalLoadToCpu(e);
        	}
        
        	public bool Equals(AccessGroupAccessPortalLoadToCpu other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessGroupAccessPortalLoadToCpu other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessGroupAccessPortalLoadToCpuUid != this.AccessGroupAccessPortalLoadToCpuUid )
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
    
    	
    	private System.Guid _accessGroupAccessPortalLoadToCpuUid;
    
    	[DataMember]
    	public System.Guid AccessGroupAccessPortalLoadToCpuUid
    	{ 
    		get { return _accessGroupAccessPortalLoadToCpuUid; }
    		set
    		{
    			if (_accessGroupAccessPortalLoadToCpuUid != value )
    			{
    				_accessGroupAccessPortalLoadToCpuUid = value;
    				OnPropertyChanged(() => AccessGroupAccessPortalLoadToCpuUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessGroupAccessPortalUid;
    
    	[DataMember]
    	public System.Guid AccessGroupAccessPortalUid
    	{ 
    		get { return _accessGroupAccessPortalUid; }
    		set
    		{
    			if (_accessGroupAccessPortalUid != value )
    			{
    				_accessGroupAccessPortalUid = value;
    				OnPropertyChanged(() => AccessGroupAccessPortalUid);
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
    	
    	private Nullable<System.DateTime> _lastLoadedDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> LastLoadedDate
    	{ 
    		get { return _lastLoadedDate; }
    		set
    		{
    			if (_lastLoadedDate != value )
    			{
    				_lastLoadedDate = value;
    				OnPropertyChanged(() => LastLoadedDate);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _lastForceLoadDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> LastForceLoadDate
    	{ 
    		get { return _lastForceLoadDate; }
    		set
    		{
    			if (_lastForceLoadDate != value )
    			{
    				_lastForceLoadDate = value;
    				OnPropertyChanged(() => LastForceLoadDate);
    			}
    		}
    	}
    
    	
    	private GalaxyCpu _galaxyCpu;
    
    	[DataMember]
    	public virtual GalaxyCpu GalaxyCpu
    	{ 
    		get { return _galaxyCpu; }
    		set
    		{
    			if (_galaxyCpu != value )
    			{
    				_galaxyCpu = value;
    				OnPropertyChanged(() => GalaxyCpu);
    			}
    		}
    	}
    }
    
}
