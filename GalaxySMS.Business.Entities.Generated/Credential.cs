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
    public partial class Credential : EntityBase, IIdentifiableEntity, IEquatable<Credential>, ITableEntityBase
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
        public partial class Credential
        {
        	public Credential()
        	{
        		Initialize();
        	}
        
        	public Credential(Credential e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.CredentialToLoadToCpus = new HashSet<CredentialToLoadToCpu>();
        	}
        
        	public void Initialize(Credential e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.CredentialUid = e.CredentialUid;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.CardNumber = e.CardNumber;
        		this.CardNumberIsHex = e.CardNumberIsHex;
        		this.CardBinaryData = e.CardBinaryData;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.BitCount = e.BitCount;
        		this.IsExtended = e.IsExtended;
        		this.CredentialToLoadToCpus = e.CredentialToLoadToCpus.ToCollection();
        		
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
        
        	public Credential Clone(Credential e)
        	{
        		return new Credential(e);
        	}
        
        	public bool Equals(Credential other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(Credential other)
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
    	public System.Guid CredentialFormatUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string CardNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool CardNumberIsHex { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public byte[] CardBinaryData { get; set; }
    
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
    	public short BitCount { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Nullable<bool> IsExtended { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public Credential26BitStandard Credential26BitStandard { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialBqt36Bit CredentialBqt36Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialCorporate1K35Bit CredentialCorporate1K35Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialCorporate1K48Bit CredentialCorporate1K48Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialFormat CredentialFormat { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialCypress37Bit CredentialCypress37Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialData CredentialData { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialH1030437Bit CredentialH1030437Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialPIV75Bit CredentialPIV75Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialXceedId40Bit CredentialXceedId40Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public ICollection<CredentialToLoadToCpu> CredentialToLoadToCpus { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialH1030237Bit CredentialH1030237Bit { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public CredentialSoftwareHouse37Bit CredentialSoftwareHouse37Bit { get; set; }
    
    }
}
