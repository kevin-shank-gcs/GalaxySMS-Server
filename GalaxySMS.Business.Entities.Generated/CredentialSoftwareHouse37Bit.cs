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
    public partial class CredentialSoftwareHouse37Bit : EntityBase, IIdentifiableEntity, IEquatable<CredentialSoftwareHouse37Bit>, ITableEntityBase
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
        public partial class CredentialSoftwareHouse37Bit
        {
        	public CredentialSoftwareHouse37Bit()
        	{
        		Initialize();
        	}
        
        	public CredentialSoftwareHouse37Bit(CredentialSoftwareHouse37Bit e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(CredentialSoftwareHouse37Bit e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.CredentialUid = e.CredentialUid;
        		this.FacilityCode = e.FacilityCode;
        		this.SiteCode = e.SiteCode;
        		this.IDCode = e.IDCode;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.IdCode = e.IdCode;
        		
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
        
        	public CredentialSoftwareHouse37Bit Clone(CredentialSoftwareHouse37Bit e)
        	{
        		return new CredentialSoftwareHouse37Bit(e);
        	}
        
        	public bool Equals(CredentialSoftwareHouse37Bit other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialSoftwareHouse37Bit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialUid != this.CredentialUid )
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
    	public System.Guid CredentialUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int FacilityCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short SiteCode { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int IDCode { get; set; }
    
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
    	public int IdCode { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Credential Credential { get; set; }
    
    }
}
