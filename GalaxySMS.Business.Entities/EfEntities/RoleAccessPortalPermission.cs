//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    public partial class RoleAccessPortalPermission : EntityBase, IIdentifiableEntity, IEquatable<RoleAccessPortalPermission>, ITableEntityBase
    {
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class RoleAccessPortalPermission
        {
        	public RoleAccessPortalPermission()
        	{
        		Initialize();
        	}
        
        	public RoleAccessPortalPermission(RoleAccessPortalPermission e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(RoleAccessPortalPermission e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.RoleAccessPortalPermissionUid = e.RoleAccessPortalPermissionUid;
        		this.RoleAccessPortalUid = e.RoleAccessPortalUid;
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
        
        	public RoleAccessPortalPermission Clone(RoleAccessPortalPermission e)
        	{
        		return new RoleAccessPortalPermission(e);
        	}
        
        	public bool Equals(RoleAccessPortalPermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleAccessPortalPermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleAccessPortalPermissionUid != this.RoleAccessPortalPermissionUid )
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
    	public System.Guid RoleAccessPortalPermissionUid { get; set; }
    	public System.Guid RoleAccessPortalUid { get; set; }
    	public System.Guid PermissionId { get; set; }
    	public string InsertName { get; set; }
    	public System.DateTimeOffset InsertDate { get; set; }
    	public string UpdateName { get; set; }
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    	public gcsPermission gcsPermission { get; set; }
    	public RoleAccessPortal RoleAccessPortal { get; set; }
    
    }
}
