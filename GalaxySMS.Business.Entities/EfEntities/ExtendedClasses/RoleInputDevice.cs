    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleInputDevice
        {
        	public RoleInputDevice()
        	{
        		Initialize();
        	}
        
        	public RoleInputDevice(RoleInputDevice e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.RoleInputDevicePermissions = new HashSet<RoleInputDevicePermission>();
        	}
        
        	public void Initialize(RoleInputDevice e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleInputDeviceUid = e.RoleInputDeviceUid;
        		this.RoleId = e.RoleId;
        		this.InputDeviceUid = e.InputDeviceUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleInputDevicePermissions = e.RoleInputDevicePermissions.ToCollection();
        		
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
        
        	public RoleInputDevice Clone(RoleInputDevice e)
        	{
        		return new RoleInputDevice(e);
        	}
        
        	public bool Equals(RoleInputDevice other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleInputDevice other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleInputDeviceUid != this.RoleInputDeviceUid )
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
