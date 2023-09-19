    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleClusterPermission
        {
        	public RoleClusterPermission()
        	{
        		Initialize();
        	}
        
        	public RoleClusterPermission(RoleClusterPermission e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(RoleClusterPermission e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleClusterPermissionUid = e.RoleClusterPermissionUid;
        		this.RoleClusterUid = e.RoleClusterUid;
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
        
        	public RoleClusterPermission Clone(RoleClusterPermission e)
        	{
        		return new RoleClusterPermission(e);
        	}
        
        	public bool Equals(RoleClusterPermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleClusterPermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleClusterPermissionUid != this.RoleClusterPermissionUid )
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
