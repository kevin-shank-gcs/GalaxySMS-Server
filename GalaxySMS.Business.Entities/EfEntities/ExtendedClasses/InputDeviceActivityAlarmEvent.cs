    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
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
