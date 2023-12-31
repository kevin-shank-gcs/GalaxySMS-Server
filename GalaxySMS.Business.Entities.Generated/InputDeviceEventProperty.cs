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
    public partial class InputDeviceEventProperty : EntityBase, IIdentifiableEntity, IEquatable<InputDeviceEventProperty>, ITableEntityBase
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
        public partial class InputDeviceEventProperty
        {
        	public InputDeviceEventProperty()
        	{
        		Initialize();
        	}
        
        	public InputDeviceEventProperty(InputDeviceEventProperty e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(InputDeviceEventProperty e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputDeviceEventPropertiesUid = e.InputDeviceEventPropertiesUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
        		this.UserInstructionsNoteUid = e.UserInstructionsNoteUid;
        		this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
        		this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
        		this.AcknowledgePriority = e.AcknowledgePriority;
        		this.Tag = e.Tag;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.ResponseInstructionsUid = e.ResponseInstructionsUid;
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
        
        	public InputDeviceEventProperty Clone(InputDeviceEventProperty e)
        	{
        		return new InputDeviceEventProperty(e);
        	}
        
        	public bool Equals(InputDeviceEventProperty other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceEventProperty other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceEventPropertiesUid != this.InputDeviceEventPropertiesUid )
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
    	public System.Guid InputDeviceEventPropertiesUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputDeviceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> AudioBinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> UserInstructionsNoteUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid AcknowledgeTimeScheduleUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputDeviceAlertEventTypeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int AcknowledgePriority { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Tag { get; set; }
    
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
    	public Nullable<System.Guid> ResponseInstructionsUid { get; set; }
    
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
    	public InputDevice InputDevice { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public InputDeviceAlertEventType InputDeviceAlertEventType { get; set; }
    
    }
}
