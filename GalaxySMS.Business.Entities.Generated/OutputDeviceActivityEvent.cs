//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class OutputDeviceActivityEvent : EntityBase, IIdentifiableEntity, IEquatable<OutputDeviceActivityEvent>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    using System.Runtime.Serialization;
    
    #if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
    #elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
    #else
    namespace GalaxySMS.Business.Entities
    #endif
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
        		this.ActivityDateTimeUTC = e.ActivityDateTimeUTC;
        		
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
    */
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid OutputDeviceActivityEventUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid GalaxyActivityEventTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid OutputDeviceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid CpuUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short CpuNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.DateTime ActivityDateTime { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int BufferIndex { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> InsertDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTimeOffset> ActivityDateTimeUTC { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public OutputDevice OutputDevice { get; set; }
    
    }
}
