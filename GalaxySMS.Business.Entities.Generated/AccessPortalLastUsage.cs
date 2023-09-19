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
    public partial class AccessPortalLastUsage : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalLastUsage>, ITableEntityBase
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
        public partial class AccessPortalLastUsage
        {
        	public AccessPortalLastUsage()
        	{
        		Initialize();
        	}
        
        	public AccessPortalLastUsage(AccessPortalLastUsage e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(AccessPortalLastUsage e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalUid = e.AccessPortalUid;
        		this.LastActivityEventUid = e.LastActivityEventUid;
        		this.LastAccessGrantedActivityEventUid = e.LastAccessGrantedActivityEventUid;
        		
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
        
        	public AccessPortalLastUsage Clone(AccessPortalLastUsage e)
        	{
        		return new AccessPortalLastUsage(e);
        	}
        
        	public bool Equals(AccessPortalLastUsage other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalLastUsage other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalUid != this.AccessPortalUid )
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
    	public System.Guid AccessPortalUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> LastActivityEventUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> LastAccessGrantedActivityEventUid { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public AccessPortal AccessPortal { get; set; }
    
    }
}
