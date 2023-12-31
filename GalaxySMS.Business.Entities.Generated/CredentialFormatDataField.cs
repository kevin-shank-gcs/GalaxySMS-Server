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
    public partial class CredentialFormatDataField : EntityBase, IIdentifiableEntity, IEquatable<CredentialFormatDataField>, ITableEntityBase
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
        public partial class CredentialFormatDataField
        {
        	public CredentialFormatDataField()
        	{
        		Initialize();
        	}
        
        	public CredentialFormatDataField(CredentialFormatDataField e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(CredentialFormatDataField e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.CredentialFormatDataFieldUid = e.CredentialFormatDataFieldUid;
        		this.CredentialFormatUid = e.CredentialFormatUid;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.FieldName = e.FieldName;
        		this.Display = e.Display;
        		this.Description = e.Description;
        		this.StartsAt = e.StartsAt;
        		this.BitLength = e.BitLength;
        		this.MinimumValue = e.MinimumValue;
        		this.MaximumValue = e.MaximumValue;
        		this.FieldNumber = e.FieldNumber;
        		this.IsReadOnly = e.IsReadOnly;
        		this.IsVisible = e.IsVisible;
        		this.DefaultValue = e.DefaultValue;
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
        
        	public CredentialFormatDataField Clone(CredentialFormatDataField e)
        	{
        		return new CredentialFormatDataField(e);
        	}
        
        	public bool Equals(CredentialFormatDataField other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(CredentialFormatDataField other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CredentialFormatDataFieldUid != this.CredentialFormatDataFieldUid )
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
    	public System.Guid CredentialFormatDataFieldUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid CredentialFormatUid { get; set; }
    
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
    	public string FieldName { get; set; }
    
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
    	public short StartsAt { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short BitLength { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int MinimumValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int MaximumValue { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public short FieldNumber { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsReadOnly { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public bool IsVisible { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public int DefaultValue { get; set; }
    
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
    	public CredentialFormat CredentialFormat { get; set; }
    
    }
}
