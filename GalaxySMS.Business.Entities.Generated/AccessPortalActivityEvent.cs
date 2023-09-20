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
    public partial class AccessPortalActivityEvent : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalActivityEvent>, ITableEntityBase
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
        public partial class AccessPortalActivityEvent
        {
        	public AccessPortalActivityEvent()
        	{
        		Initialize();
        	}
        
        	public AccessPortalActivityEvent(AccessPortalActivityEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalActivityEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalActivityEventUid = e.AccessPortalActivityEventUid;
        		this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.CredentialUid = e.CredentialUid;
        		this.PersonUid = e.PersonUid;
        		this.CpuUid = e.CpuUid;
        		this.ActivityDateTime = e.ActivityDateTime;
        		this.BufferIndex = e.BufferIndex;
        		this.InsertDate = e.InsertDate;
        		this.CpuNumber = e.CpuNumber;
        		this.CredentialBytes = e.CredentialBytes;
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
        
        	public AccessPortalActivityEvent Clone(AccessPortalActivityEvent e)
        	{
        		return new AccessPortalActivityEvent(e);
        	}
        
        	public bool Equals(AccessPortalActivityEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalActivityEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalActivityEventUid != this.AccessPortalActivityEventUid )
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
    	public System.Guid AccessPortalActivityEventUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid GalaxyActivityEventTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> CredentialUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> PersonUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid CpuUid { get; set; }
    
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
    	public short CpuNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] CredentialBytes { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTimeOffset> ActivityDateTimeUTC { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public AccessPortal AccessPortal { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public AccessPortalActivityAlarmEvent AccessPortalActivityAlarmEvent { get; set; }
    
    }
}
