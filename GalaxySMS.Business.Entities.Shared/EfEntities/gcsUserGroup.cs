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
    public partial class gcsUserGroup : EntityBase, IIdentifiableEntity, IEquatable<gcsUserGroup>, ITableEntityBase
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
        public partial class gcsUserGroup
        {
        	public gcsUserGroup()
        	{
        		Initialize();
        	}
        
        	public gcsUserGroup(gcsUserGroup e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.gcsUserGroupEntities = new HashSet<gcsUserGroupEntity>();
        		this.gcsUserUserGroups = new HashSet<gcsUserUserGroup>();
        	}
        
        	public void Initialize(gcsUserGroup e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.UserGroupId = e.UserGroupId;
        		this.Name = e.Name;
        		this.Description = e.Description;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.gcsUserGroupEntities = e.gcsUserGroupEntities.ToCollection();
        		this.gcsUserUserGroups = e.gcsUserUserGroups.ToCollection();
        		
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
        
        	public gcsUserGroup Clone(gcsUserGroup e)
        	{
        		return new gcsUserGroup(e);
        	}
        
        	public bool Equals(gcsUserGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsUserGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.UserGroupId != this.UserGroupId )
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
        
        	public bool Equals(gcsUserGroup other)
            {
                throw new NotImplementedException();
            }
        }
    }
    */
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid UserGroupId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Name { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Description { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string InsertName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.DateTimeOffset InsertDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string UpdateName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<short> ConcurrencyValue { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsUserGroupEntity> gcsUserGroupEntities { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<gcsUserUserGroup> gcsUserUserGroups { get; set; }
    
    }
}
