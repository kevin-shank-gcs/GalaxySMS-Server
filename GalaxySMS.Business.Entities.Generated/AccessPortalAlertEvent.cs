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
    public partial class AccessPortalAlertEvent : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalAlertEvent>, ITableEntityBase
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
        public partial class AccessPortalAlertEvent
        {
        	public AccessPortalAlertEvent()
        	{
        		Initialize();
        	}
        
        	public AccessPortalAlertEvent(AccessPortalAlertEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalAlertEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalAlertEventUid = e.AccessPortalAlertEventUid;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
        		this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
        		this.ResponseInstructionsUid = e.ResponseInstructionsUid;
        		this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
        		this.OffsetIndex = e.OffsetIndex;
        		this.AcknowledgePriority = e.AcknowledgePriority;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
        		this.IsActive = e.IsActive;
        		this.ResponseRequired = e.ResponseRequired;
        		
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
        
        	public AccessPortalAlertEvent Clone(AccessPortalAlertEvent e)
        	{
        		return new AccessPortalAlertEvent(e);
        	}
        
        	public bool Equals(AccessPortalAlertEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalAlertEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalAlertEventUid != this.AccessPortalAlertEventUid )
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
    	public System.Guid AccessPortalAlertEventUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputOutputGroupUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AcknowledgeTimeScheduleUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> AudioBinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> ResponseInstructionsUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AccessPortalAlertEventTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short OffsetIndex { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int AcknowledgePriority { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string InsertName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> InsertDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string UpdateName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> UpdateDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> InputOutputGroupAssignmentUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsActive { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool ResponseRequired { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public AccessPortalAlertEventType AccessPortalAlertEventType { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public gcsBinaryResource gcsBinaryResource { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Note Note { get; set; }
    
    }
}
