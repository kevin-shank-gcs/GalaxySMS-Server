    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleAccessPortal
        {
        	public RoleAccessPortal()
        	{
        		Initialize();
        	}
        
        	public RoleAccessPortal(RoleAccessPortal e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.RoleAccessPortalPermissions = new HashSet<RoleAccessPortalPermission>();
        	}
        
        	public void Initialize(RoleAccessPortal e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleAccessPortalUid = e.RoleAccessPortalUid;
        		this.RoleId = e.RoleId;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleAccessPortalPermissions = e.RoleAccessPortalPermissions.ToCollection();
        		
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
        
        	public RoleAccessPortal Clone(RoleAccessPortal e)
        	{
        		return new RoleAccessPortal(e);
        	}
        
        	public bool Equals(RoleAccessPortal other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleAccessPortal other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleAccessPortalUid != this.RoleAccessPortalUid )
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
