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
    public partial class PersonClusterPermission : EntityBase, IIdentifiableEntity, IEquatable<PersonClusterPermission>, ITableEntityBase
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
        public partial class PersonClusterPermission
        {
        	public PersonClusterPermission()
        	{
        		Initialize();
        	}
        
        	public PersonClusterPermission(PersonClusterPermission e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.PersonAccessGroups = new HashSet<PersonAccessGroup>();
        	}
        
        	public void Initialize(PersonClusterPermission e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
        		this.PersonUid = e.PersonUid;
        		this.ClusterUid = e.ClusterUid;
        		this.PersonCredentialUid = e.PersonCredentialUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.CredentialClusterTourUid = e.CredentialClusterTourUid;
        		this.CredentialBits = e.CredentialBits;
        		this.PersonUidClusterUidCredentialUidCombined = e.PersonUidClusterUidCredentialUidCombined;
        		this.LastPanelImpactingChangeDate = e.LastPanelImpactingChangeDate;
        		this.IsExtended = e.IsExtended;
        		this.PersonAccessGroups = e.PersonAccessGroups.ToCollection();
        		
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
        
        	public PersonClusterPermission Clone(PersonClusterPermission e)
        	{
        		return new PersonClusterPermission(e);
        	}
        
        	public bool Equals(PersonClusterPermission other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(PersonClusterPermission other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.PersonClusterPermissionUid != this.PersonClusterPermissionUid )
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
    	public System.Guid PersonClusterPermissionUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid PersonUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid ClusterUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.Guid> PersonCredentialUid { get; set; }
    
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
    	public Nullable<System.Guid> CredentialClusterTourUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] CredentialBits { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PersonUidClusterUidCredentialUidCombined { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<System.DateTime> LastPanelImpactingChangeDate { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<bool> IsExtended { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Cluster Cluster { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<PersonAccessGroup> PersonAccessGroups { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public PersonCredential PersonCredential { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public PersonPersonalAccessGroup PersonPersonalAccessGroup { get; set; }
    
    }
}
