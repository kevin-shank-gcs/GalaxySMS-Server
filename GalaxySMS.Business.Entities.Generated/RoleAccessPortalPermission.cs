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
    public partial class RoleAccessPortalPermission : EntityBase, IIdentifiableEntity, IEquatable<RoleAccessPortalPermission>, ITableEntityBase
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
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid RoleAccessPortalPermissionUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid RoleAccessPortalUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PermissionId { get; set; }
    
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
    	public gcsPermission gcsPermission { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public RoleAccessPortal RoleAccessPortal { get; set; }
    
    }
}
