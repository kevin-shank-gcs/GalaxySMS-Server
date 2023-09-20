    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
    {
        public partial class InputDeviceAlertEvent
        {
        	public InputDeviceAlertEvent()
        	{
        		Initialize();
        	}
        
        	public InputDeviceAlertEvent(InputDeviceAlertEvent e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputDeviceAlertEvent e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputDeviceAlertEventUid = e.InputDeviceAlertEventUid;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
        		this.Tag = e.Tag;
                this.AcknowledgePriority = e.AcknowledgePriority;
                this.IsActive = e.IsActive;
                this.ResponseRequired = e.ResponseRequired;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
        		this.InputOutputGroupNumber = e.InputOutputGroupNumber;
                this.InputOutputGroupName = e.InputOutputGroupName;
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
        
        	public InputDeviceAlertEvent Clone(InputDeviceAlertEvent e)
        	{
        		return new InputDeviceAlertEvent(e);
        	}
        
        	public bool Equals(InputDeviceAlertEvent other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputDeviceAlertEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceAlertEventUid != this.InputDeviceAlertEventUid )
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

                    
#if NetCoreApi
#else
            [DataMember]
#endif
            public int InputOutputGroupNumber { get; set; }

#if NetCoreApi
#else
            [DataMember]
#endif
            public string InputOutputGroupName { get; set; }

        }
    }
