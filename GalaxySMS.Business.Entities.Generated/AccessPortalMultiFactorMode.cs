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
    public partial class AccessPortalMultiFactorMode : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalMultiFactorMode>, ITableEntityBase
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
        public partial class AccessPortalMultiFactorMode
        {
        	public AccessPortalMultiFactorMode()
        	{
        		Initialize();
        	}
        
        	public AccessPortalMultiFactorMode(AccessPortalMultiFactorMode e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.AccessPortalProperties = new HashSet<AccessPortalProperty>();
        	}
        
        	public void Initialize(AccessPortalMultiFactorMode e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.AccessPortalMultiFactorModeUid = e.AccessPortalMultiFactorModeUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.Code = e.Code;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
        		
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
        
        	public AccessPortalMultiFactorMode Clone(AccessPortalMultiFactorMode e)
        	{
        		return new AccessPortalMultiFactorMode(e);
        	}
        
        	public bool Equals(AccessPortalMultiFactorMode other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalMultiFactorMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalMultiFactorModeUid != this.AccessPortalMultiFactorModeUid )
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
    	public System.Guid AccessPortalMultiFactorModeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DisplayResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> DescriptionResourceKey { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Display { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short Code { get; set; }
    
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
    	public ICollection<AccessPortalProperty> AccessPortalProperties { get; set; }
    
    }
}
