    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleInputOutputGroupPermission
        {
        	public RoleInputOutputGroupPermission()
        	{
        		Initialize();
        	}
        
        	public RoleInputOutputGroupPermission(RoleInputOutputGroupPermission e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(RoleInputOutputGroupPermission e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleInputOutputGroupPermissionUid = e.RoleInputOutputGroupPermissionUid;
        		this.RoleInputOutputGroupUid = e.RoleInputOutputGroupUid;
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
        
        	public RoleInputOutputGroupPermission Clone(RoleInputOutputGroupPermission e)
        	{
        		return new RoleInputOutputGroupPermission(e);
        	}
        
        	public bool Equals(RoleInputOutputGroupPermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleInputOutputGroupPermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleInputOutputGroupPermissionUid != this.RoleInputOutputGroupPermissionUid )
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
