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
    public partial class gcsSystem : EntityBase, IIdentifiableEntity, IEquatable<gcsSystem>, ITableEntityBase
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
        public partial class gcsSystem
        {
        	public gcsSystem()
        	{
        		Initialize();
        	}
        
        	public gcsSystem(gcsSystem e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(gcsSystem e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.SystemId = e.SystemId;
        		this.License = e.License;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.SystemName = e.SystemName;
        		this.CompanyName = e.CompanyName;
        		this.SupportCompany = e.SupportCompany;
        		this.SupportContact = e.SupportContact;
        		this.SupportPhone = e.SupportPhone;
        		this.SupportEmail = e.SupportEmail;
        		this.SupportUrl = e.SupportUrl;
        		this.SupportImage = e.SupportImage;
        		this.SystemImage = e.SystemImage;
        		this.PublicKey = e.PublicKey;
        		
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
        
        	public gcsSystem Clone(gcsSystem e)
        	{
        		return new gcsSystem(e);
        	}
        
        	public bool Equals(gcsSystem other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(gcsSystem other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.SystemId != this.SystemId )
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
    	public System.Guid SystemId { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string License { get; set; }
    
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
    	public string SystemName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string CompanyName { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SupportCompany { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SupportContact { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SupportPhone { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SupportEmail { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string SupportUrl { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] SupportImage { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] SystemImage { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string PublicKey { get; set; }
    
    }
}
