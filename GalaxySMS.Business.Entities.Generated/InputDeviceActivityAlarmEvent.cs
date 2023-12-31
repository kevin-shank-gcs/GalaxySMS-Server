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
    public partial class InputDeviceActivityAlarmEvent : EntityBase, IIdentifiableEntity, IEquatable<InputDeviceActivityAlarmEvent>, ITableEntityBase
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
        public partial class InputDeviceActivityAlarmEvent
        {
        	public InputDeviceActivityAlarmEvent()
        	{
        		Initialize();
        	}
        
        	public InputDeviceActivityAlarmEvent(InputDeviceActivityAlarmEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.InputDeviceAlarmEventAcknowledgments = new HashSet<InputDeviceAlarmEventAcknowledgment>();
        	}
        
        	public void Initialize(InputDeviceActivityAlarmEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputDeviceActivityEventUid = e.InputDeviceActivityEventUid;
        		this.NoteUid = e.NoteUid;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.AlarmPriority = e.AlarmPriority;
        		this.ResponseRequired = e.ResponseRequired;
        		this.InputDeviceAlarmEventAcknowledgments = e.InputDeviceAlarmEventAcknowledgments.ToCollection();
        		
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
        
        	public InputDeviceActivityAlarmEvent Clone(InputDeviceActivityAlarmEvent e)
        	{
        		return new InputDeviceActivityAlarmEvent(e);
        	}
        
        	public bool Equals(InputDeviceActivityAlarmEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceActivityAlarmEvent other)
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
    */
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid InputDeviceActivityEventUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> NoteUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> BinaryResourceUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int AlarmPriority { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool ResponseRequired { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public InputDeviceActivityEvent InputDeviceActivityEvent { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<InputDeviceAlarmEventAcknowledgment> InputDeviceAlarmEventAcknowledgments { get; set; }
    
    }
}
