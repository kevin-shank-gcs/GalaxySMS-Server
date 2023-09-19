    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleInputDevicePermission
        {
        	public RoleInputDevicePermission()
        	{
        		Initialize();
        	}
        
        	public RoleInputDevicePermission(RoleInputDevicePermission e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(RoleInputDevicePermission e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleInputDevicePermissionUid = e.RoleInputDevicePermissionUid;
        		this.RoleInputDeviceUid = e.RoleInputDeviceUid;
        		this.PermissionId = e.PermissionId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
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
        
        	public RoleInputDevicePermission Clone(RoleInputDevicePermission e)
        	{
        		return new RoleInputDevicePermission(e);
        	}
        
        	public bool Equals(RoleInputDevicePermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleInputDevicePermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleInputDevicePermissionUid != this.RoleInputDevicePermissionUid )
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
